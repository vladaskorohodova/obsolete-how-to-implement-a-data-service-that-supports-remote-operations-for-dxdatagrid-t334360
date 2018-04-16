Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing

Namespace MyRestService
    Public Class MvcApplication
        Inherits System.Web.HttpApplication

        Private Shared Sub EnableCrossDomain()
            Dim origin As String = HttpContext.Current.Request.Headers("Origin")
            If String.IsNullOrEmpty(origin) Then
                Return
            End If
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin)
            Dim method As String = HttpContext.Current.Request.Headers("Access-Control-Request-Method")
            If Not String.IsNullOrEmpty(method) Then
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", method)
            End If
            Dim headers As String = HttpContext.Current.Request.Headers("Access-Control-Request-Headers")
            If Not String.IsNullOrEmpty(headers) Then
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", headers)
            End If
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true")
            If HttpContext.Current.Request.HttpMethod = "OPTIONS" Then
                HttpContext.Current.Response.StatusCode = 204
                HttpContext.Current.Response.End()
            End If
        End Sub
        Private Sub Generate(context As TestDataEntities)
            Dim random = New Random()
            For i = 0 To 10000
                Dim data = New Category()
                data.CategoryName = "Cat " & (i Mod 100).ToString()
                data.Count = (random.Next() Mod 20) + 1
                data.Price = Convert.ToDecimal(random.NextDouble() * 1000)
                Dim month = random.Next()
                Dim day = random.Next()
                data.RegisterDate = New DateTime(2015, (month Mod 12) + 1, (day Mod 28) + 1)
                context.Categories.Add(data)
            Next i
            context.SaveChanges()
        End Sub
        Protected Sub Application_Start()
            AreaRegistration.RegisterAllAreas()

            WebApiConfig.Register(GlobalConfiguration.Configuration)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            Dim context As TestDataEntities = New TestDataEntities()
            If (context.Categories.Count() = 0) Then
                Generate(context)
            End If
        End Sub
        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            EnableCrossDomain()
        End Sub
    End Class
End Namespace