using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Data.Entity;
using System.Web.Mvc;
using System.Net;
using System.Web;
using DevExtreme.AspNet.Data;
using System.Net.Http.Formatting;

namespace MyRestService.Controllers {
    public class CategoriesController : ApiController {
        private TestDataEntities _context;
        public CategoriesController() {
            _context = new TestDataEntities();
        }
        public HttpResponseMessage Get(WebApiDataSourceLoadOptions loadOptions) {
            return Request.CreateResponse(
                HttpStatusCode.OK, 
                DataSourceLoader.Load(_context.Categories, loadOptions)
            );
        }
        public int Post(FormDataCollection form) {
            var values = form.Get("values");

            var newCategory = new Category();
            JsonConvert.PopulateObject(values, newCategory);
            _context.Categories.Add(newCategory);
            return _context.SaveChanges();
        }
        public int Put(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");

            var category = _context.Categories.Find(key);
            JsonConvert.PopulateObject(values, category);
            return _context.SaveChanges();
        }
        public int Delete(FormDataCollection form) {
            var key = Convert.ToInt32(form.Get("key"));

            var cat = _context.Categories.Find(key);
            _context.Categories.Remove(cat);
            return _context.SaveChanges();
        }
    }
}
;