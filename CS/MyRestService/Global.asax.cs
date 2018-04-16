using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyRestService {
    public class MvcApplication : System.Web.HttpApplication {
        static void EnableCrossDomain() {
            string origin = HttpContext.Current.Request.Headers["Origin"];
            if (string.IsNullOrEmpty(origin)) return;
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
            string method = HttpContext.Current.Request.Headers["Access-Control-Request-Method"];
            if (!string.IsNullOrEmpty(method))
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", method);
            string headers = HttpContext.Current.Request.Headers["Access-Control-Request-Headers"];
            if (!string.IsNullOrEmpty(headers))
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", headers);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS") {
                HttpContext.Current.Response.StatusCode = 204;
                HttpContext.Current.Response.End();
            }
        }
        private void Generate(TestDataEntities context) {
            var random = new Random();
            for (var i = 0; i < 10000; i++) {
                var data = new Category();
                data.CategoryName = "Cat " + (i % 100);
                data.Count = (random.Next() % 20) + 1;
                data.Price = (decimal)(random.NextDouble() * 1000);
                var month = random.Next();
                var day = random.Next();
                data.RegisterDate = new DateTime(2015, (month % 12) + 1, (day % 28) + 1);
                context.Categories.Add(data);
            }
            context.SaveChanges();
        }
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            TestDataEntities context = new TestDataEntities();
            if(context.Categories.Count() == 0) {
                Generate(context);
            }
            
        }
        protected void Application_BeginRequest(object sender, EventArgs e) {
            EnableCrossDomain();
        }
    }
}