using System;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";

            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Server started on port 8080.");
                Console.ReadKey();
                Console.WriteLine("Server stopped");
                Console.ReadKey();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(ctx => ctx.Response.WriteAsync("Hello world!"));
        }
    }
}
