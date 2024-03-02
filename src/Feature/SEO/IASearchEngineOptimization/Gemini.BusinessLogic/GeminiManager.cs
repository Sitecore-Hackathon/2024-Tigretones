﻿using Hackaton.AI.SEO.BusinessLogic.Extensions;
using Hackaton.AI.SEO.Models;
using Newtonsoft.Json;
using System.Text;

namespace Hackaton.AI.SEO.BusinessLogic
{
    public enum RequestType
    {
        Title,
        MetaDescription,
        Keywords
    }

    public class GeminiManager : IGeminiManager
    {
        private readonly IHttpClientWrapper _HttpClient;

        public GeminiManager(IHttpClientWrapper httpClient)
        {
            _HttpClient = httpClient;
        }

        #region Public Methods

        public List<Tuple<RequestType, GeminiRequest>> ParseRequest(ApiRequest originalRequest)
        {
            var requests = new List<Tuple<RequestType, GeminiRequest>>();

            AddGeneratedRequest(RequestType.Title, originalRequest.TitleTag, originalRequest.TitlePrompt, originalRequest.Content, requests);
            AddGeneratedRequest(RequestType.MetaDescription, originalRequest.MetaDescription, originalRequest.MetaDescriptionPrompt, originalRequest.Content, requests);
            AddGeneratedRequest(RequestType.Keywords, originalRequest.Keyword, originalRequest.KeywordPrompt, originalRequest.Content, requests);

            return requests;
        }        

        public ApiResponse ParseResponse(List<Tuple<RequestType, GeminiResponse>> geminiResponses)
        {
            var apiResponse = new ApiResponse();

            foreach (var geminiResponse in geminiResponses)
            {
                var generatedText = geminiResponse?.Item2?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text;

                switch (geminiResponse?.Item1)
                {
                    case RequestType.Title: apiResponse.TitleTag = generatedText?.GetHtmlTag(RequestType.Title); break;
                    case RequestType.MetaDescription: apiResponse.MetaDescriptionTag = generatedText?.GetHtmlTag(RequestType.MetaDescription); break;
                    case RequestType.Keywords: apiResponse.KeywordsTag = generatedText?.GetHtmlTag(RequestType.Keywords); break;
                    default: break;
                }
            }

            return apiResponse;
        }

        public async Task<Tuple<RequestType, HttpResponseMessage?>> SendRequest(RequestType type, GeminiRequest request)
        {
            // Serialize the model to JSON
            var json = JsonConvert.SerializeObject(request);

            // API endpoint URL
            string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key=AIzaSyCYoIyYnd9UkKxaFsGc4anVrcZLjxvKcSM";


            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the request and get the response
            return Tuple.Create(type, _HttpClient != null ? await _HttpClient.PostAsync(apiUrl, content) : null);
        }

        #endregion

        #region Private Methods

        private void AddGeneratedRequest(RequestType type, string? flag, string? prompt, string? content, List<Tuple<RequestType, GeminiRequest>> requests)
        {
            _ = bool.TryParse(flag, out bool generate);

            if (generate && !string.IsNullOrWhiteSpace(prompt) && !string.IsNullOrWhiteSpace(content))
                requests.Add(Tuple.Create(type, GenerateRequest($"{prompt}\r\n{content}")));
        }

        private GeminiRequest GenerateRequest(string prompt) => new()
        {
            contents =
            [
                new Content
                {
                    parts =
                    [
                        new Part { text = prompt }
                    ]
                }
            ]
        };

        #endregion
    }
}