using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Http.Controllers;

namespace MyRestService {


    [ModelBinder(typeof(WebApiDataSourceLoadOptionsBinder))]
    public class WebApiDataSourceLoadOptions : DataSourceLoadOptionsBase {
    }


    public class WebApiDataSourceLoadOptionsBinder : IModelBinder {

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext) {
            var loadOptions = new WebApiDataSourceLoadOptions();

            DataSourceLoadOptionsParser.Parse(loadOptions, key => {
                var value = bindingContext.ValueProvider.GetValue(key);
                if(value != null)
                    return value.AttemptedValue;
                return null;
            });

            bindingContext.Model = loadOptions;
            return true;
        }

    }


}