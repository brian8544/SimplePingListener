// Simple service that listens the selected port, so you are able to ping it with an uptime monitoring service such as https://uptimerobot.com
// Do not forget to forward the selected port in your firewall and network devices!

using System.Text;
using System.Net;

namespace PingListenerMain
{
    class WebServer
    {
        public static HttpListener PingListener;
        public static string url = "http://localhost:8544/";
        public static int pageViews = 0;
        public static int requestCount = 0;
        public static string pageData =

            "<!DOCTYPE>" +
            "<html>" +
            "<head>" +

            "<title>SimplePingListener</title>" +

            "</head>" +
            "<body>" +

            "<h1>SimplePingListener is <span style=\"color: #00ff00;\">working</span>!</h1>" +
            "<b><a href=\"https://github.com/brian8544\">Made by: Brian8544</a></b>" +

            "</body>" +
            "</html>";


        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            // Keep running the service until the user terminates the application.
            while (runServer)
            {
                // Wait for request...
                HttpListenerContext ctx = await PingListener.GetContextAsync();

                // Get requests and responses
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Give server/console information from client requesting TCP connection
                Console.WriteLine("TCP REQUEST ACCEPTED {0}", ++requestCount);
                Console.WriteLine();
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                // Create HTML page
                byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Print HTML page asynchronous to client
                await resp.OutputStream.WriteAsync(data, 0, data.Length);
                resp.Close();
            }
        }


        public static void Main(string[] args)
        {
            // Start listening on configured IP & port configured above
            PingListener = new HttpListener();
            PingListener.Prefixes.Add(url);
            PingListener.Start();
            Console.WriteLine("Listening for connections on {0}", url);
            Console.WriteLine("To stop PingListener, press CTRL + C");

            // Request handler
            Task listenTask = HandleIncomingConnections();
            listenTask.GetAwaiter().GetResult();

            // Exit Code 0, termination by user input.
            PingListener.Close();
        }
    }
}