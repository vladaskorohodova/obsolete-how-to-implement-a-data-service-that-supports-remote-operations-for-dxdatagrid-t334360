<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128583341/15.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T334360)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to implement a data service that supports remote operations for dxDataGrid

<!-- default file list -->
*Files to look at*:

* [WebApiConfig.cs](./CS/MyRestService/App_Start/WebApiConfig.cs) (VB: [WebApiConfig.vb](./VB/MyRestService/App_Start/WebApiConfig.vb))
* [Category.cs](./CS/MyRestService/Category.cs) (VB: [Category.vb](./VB/MyRestService/Category.vb))
* **[CategoriesController.cs](./CS/MyRestService/Controllers/CategoriesController.cs) (VB: [CategoriesController.vb](./VB/MyRestService/Controllers/CategoriesController.vb))**
* [Global.asax.cs](./CS/MyRestService/Global.asax.cs) (VB: [Global.asax.vb](./VB/MyRestService/Global.asax.vb))
* [WebApiDataSourceLoadOptions.cs](./CS/MyRestService/WebApiDataSourceLoadOptions.cs) (VB: [WebApiDataSourceLoadOptions.vb](./VB/MyRestService/WebApiDataSourceLoadOptions.vb))
<!-- default file list end -->



<p>This example demonstrates how to implement a data service based on ASP.NET WebAPI that supports remote operations for the dxDataGrid widget. The main idea is to get all parameters passed from the client side and use them when loading data from a data base to prepare data in the required manner. We performed the following steps to implement data loading:<br><br>1. Include the <a href="https://github.com/DevExpress/DevExtreme.AspNet.Data">DevExtreme.AspNet.Data</a> library into our project. You can do this using the <a href="https://www.nuget.org/packages/DevExtreme.AspNet.Data/1.0.0">NuGet</a> package manager.<br>2. Get parameters from the GET request using a custom binder - see the <strong>WebApiDataSourceLoadOptionsBinder</strong> class.<br>3. Pass these parameters with the required <strong>DbContext</strong> to the <strong>DataSourceLoader.Load</strong> method.<br><br>In addition, please refer to the <a href="http://js.devexpress.com/Documentation/Guide/UI_Widgets/Data_Grid/Use_Custom_Store/?version=15_2#Remote_Operations">Use Custom Store - Remote Operations</a> help topic to learn more about all supported remote operations of dxDataGrid. You can see an implementation of a custom store for dxDataGrid in the <a href="https://www.devexpress.com/Support/Center/p/T137724">dxDataGrid - How to implement a custom store with CRUD operations</a> example.</p>
If you wish to implement the same scenario based on PHP, use the <a href="https://github.com/DevExpress/DevExtreme-PHP-Data">DevExtreme-PHP-Data</a> library.<br><br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E4462">How to implement the Rest service based on an ASP.NET WebAPI application</a>

<br/>


