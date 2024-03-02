process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';
const response = await fetch('https://hackathon2024sc.dev.local/sitecore/api/layout/render?item={A14ED611-C4BA-4BC3-A001-AF87E6D73636}&sc_apikey={C8733B5B-20E1-418E-8F23-221691031882}', {
  method: 'GET',
  headers: { 'Content-Type': 'application/json' },
});
const data = await response.json();

export { data };