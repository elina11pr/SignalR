using System.Net;

namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();
            Console.WriteLine("Listening on port 5000...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))

                {
                    string requestBody = reader.ReadToEnd();
                    Console.WriteLine($"Request body: {requestBody}");
                }
            }

        }
    }
}