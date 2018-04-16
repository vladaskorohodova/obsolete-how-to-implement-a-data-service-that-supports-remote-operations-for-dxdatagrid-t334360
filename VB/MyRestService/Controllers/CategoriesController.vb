Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http
Imports System.Web.Http
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Reflection
Imports System.Net
Imports DevExtreme.AspNet.Data


Namespace MyRestService.Controllers
    Public Class CategoriesController
        Inherits ApiController

        Private _context As TestDataEntities
        Public Sub New()
            _context = New TestDataEntities()
        End Sub
        Public Function [Get](loadOptions As WebApiDataSourceLoadOptions) As HttpResponseMessage
            Return Request.CreateResponse(
                HttpStatusCode.OK,
                DataSourceLoader.Load(_context.Categories, loadOptions)
            )
        End Function
        Public Function Post(<FromBody> ByVal data As Category) As Integer
            _context.Categories.Add(data)
            Return _context.SaveChanges()
        End Function
        Public Function Put(<FromBody> ByVal category As String) As Integer
            Dim options As JObject = JObject.Parse(category)

            Dim key As Integer = CType(options.Item("key"), Integer)
            Dim Data As Category = _context.Categories.Find(key)

            Dim newData As Category = options.Item("values").ToObject(Of Category)()
            For Each jProperty As JProperty In CType(options.Item("values"), JObject).Properties()
                Dim prop As PropertyInfo = Data.GetType().GetProperty(jProperty.Name)
                prop.SetValue(Data, prop.GetValue(newData))
            Next

            Return _context.SaveChanges()
        End Function
        Public Function Delete(<FromBody> ByVal key As String) As Integer
            Dim cat As Category = _context.Categories.Find(Int32.Parse(key))
            _context.Categories.Remove(cat)
            Return _context.SaveChanges()
        End Function
    End Class
End Namespace