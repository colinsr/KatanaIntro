using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

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
            app.Use<HelloWorldComponent>();
        }
    }

    public class HelloWorldComponent
    {
        private AppFunc _next;

        public HelloWorldComponent(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            var respone = environment["owin.ResponseBody"] as Stream;
            using (var writer = new StreamWriter(respone))
            {
                return writer.WriteAsync("Hello!!");
            }
        }
    }
}
