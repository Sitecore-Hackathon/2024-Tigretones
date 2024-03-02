using Hackaton.AI.SEO.BusinessLogic;
using Hackaton.AI.SEO.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackaton.AI.SEO.API
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IGeminiManager _GeminiManager;

        public ClientController(IGeminiManager geminiManager)
        {
            _GeminiManager = geminiManager;
        }

        [Route("api/seo")]
        [HttpPost]
        public async Task<IActionResult> GenerateSEO([FromBody] ApiRequest request)
        {
            var geminiResponses = new List<Tuple<RequestType, GeminiResponse>>();

            try
            {
                var geminiRequests = _GeminiManager.ParseRequest(request);

                foreach (var geminiRequest in geminiRequests)
                {
                    var apiResult = await _GeminiManager.SendRequest(geminiRequest.Item1, geminiRequest.Item2);

                    // Check if request was not successful
                    if (apiResult == null || apiResult.Item2 == null)
                    {
                        return BadRequest();
                    }

                    if (apiResult.Item2.IsSuccessStatusCode)
                    {
                        // Read and process the response
                        var geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(await apiResult.Item2.Content.ReadAsStringAsync());

                        if (geminiResponse != null)
                            geminiResponses.Add(Tuple.Create(apiResult.Item1, geminiResponse));
                    }
                    else
                    {
                        // Handle unsuccessful request
                        return BadRequest("Error: " + apiResult.Item2.ReasonPhrase);
                    }

                    Thread.Sleep(30);
                }

                var jsonResponse = JsonConvert.SerializeObject(_GeminiManager.ParseResponse(geminiResponses));
                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return StatusCode(500, "Error: " + ex.Message);
            }
        }
    }
}
