using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace asrlive
{
    class Program
    {
        static void Main(string[] args)
        {
            const int BUFFER_SIZE = 16000;
            string baseUrl = "wss://api.amerandish.com/v1";
            string actionUrl = "/speech/asrlive";
            string authKey = "<YOUR_API_KEY>";

            string filePath = @"<YOUR_WAV_FILE_PATH>";

            string url = baseUrl+actionUrl +"?jwt=" + authKey;

            var bytes = File.ReadAllBytes(filePath);
            var base64 = Convert.ToBase64String(bytes);
            var exitEvent = new ManualResetEvent(false);
            var factory = new Func<ClientWebSocket>(() =>
            {
                var client = new ClientWebSocket
                {
                    Options =
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(5),
                    }
                };
                return client;
            });
            using (var client = new WebsocketClient(new Uri(url),factory)){
                client.ReconnectTimeout = TimeSpan.FromSeconds(30);
                client.MessageReceived.Subscribe(msg => {
                    try
                    {
                        var model = ResponseModel.FromJson(msg.ToString());
                        Console.WriteLine(model.ToJson());
                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });

                client.Start().Wait();
                for(int index=0;index<base64.Length;index+=BUFFER_SIZE)
                    {
                        if(index+BUFFER_SIZE<base64.Length){
                            Console.WriteLine(string.Format("send {0} -> {1}", index, index+BUFFER_SIZE));
                            client.Send(Encoding.UTF8.GetBytes(base64.Substring(index, BUFFER_SIZE)));
                        }else{
                            Console.WriteLine(string.Format("send {0} -> {1}", index, base64.Length));
                            client.Send(Encoding.UTF8.GetBytes(base64.Substring(index)));
                        }
                    }
                exitEvent.WaitOne();
            }
        }
    }
}
