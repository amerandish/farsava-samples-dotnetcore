using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace health
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://api.amerandish.com/v1";
            string actionUrl = "/speech/healthcheck";
            string authKey = "<YOUR_API_KEY>";

            string url = baseUrl+actionUrl;

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", string.Format("bearer {0}", authKey));
            var client = new HttpClient();
            var response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode){
                // success response
                var jsonStr = await response.Content.ReadAsStringAsync();
                var model = HealthModel.FromJson(jsonStr);
                Console.WriteLine(model);
            }else{
                // failure response
                var jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
    }
}
