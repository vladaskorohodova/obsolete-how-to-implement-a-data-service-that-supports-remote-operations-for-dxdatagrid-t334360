Imports DevExtreme.AspNet.Data
Imports DevExtreme.AspNet.Data.Helpers
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http.ModelBinding
Imports System.Web.Http.Controllers

Namespace MyRestService
    <ModelBinder(GetType(WebApiDataSourceLoadOptionsBinder))>
    Public Class WebApiDataSourceLoadOptions
        Inherits DataSourceLoadOptionsBase
    End Class


    Public Class WebApiDataSourceLoadOptionsBinder
        Implements IModelBinder

        Public Function BindModel(actionContext As HttpActionContext, bindingContext As ModelBindingContext) As Boolean Implements IModelBinder.BindModel
            Dim loadOptions = New WebApiDataSourceLoadOptions()
            DataSourceLoadOptionsParser.Parse(loadOptions, Function(key)
                                                               Dim value = bindingContext.ValueProvider.GetValue(key)
                                                               If value IsNot Nothing Then
                                                                   Return value.AttemptedValue
                                                               End If
                                                               Return Nothing
                                                           End Function)
            bindingContext.Model = loadOptions
            Return True
        End Function

    End Class
End Namespace

