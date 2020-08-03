using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace asr
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string baseUrl = "https://api.amerandish.com/v1";
            string actionUrl = "/speech/asr";
            string authKey = "<YOUR_API_KEY>";


            string filePath = @"<YOUR_WAV_FILE_PATH>";

            string url = baseUrl+actionUrl;

            var bytes = File.ReadAllBytes(filePath);
            var base64 = Convert.ToBase64String(bytes);

            var payload = new RequestModel();
            payload.Audio = new Audio(base64);
            payload.Config = new Config("LINEAR16",16000,"fa",1,true,"default","general");

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(payload.ToJson(), Encoding.UTF8);
            request.Headers.Add("Authorization", string.Format("bearer {0}", authKey));

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode){
                // success response
                var jsonStr = await response.Content.ReadAsStringAsync();
                var model = ResponseModel.FromJson(jsonStr);
                Console.WriteLine(model);
            }else{
                // failure response
                var jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);
            }
        }
    }
}
