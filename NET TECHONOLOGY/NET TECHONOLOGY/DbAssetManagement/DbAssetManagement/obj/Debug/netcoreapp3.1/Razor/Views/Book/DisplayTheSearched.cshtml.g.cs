#pragma checksum "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee816bb4eb265b24dd4a852dafbe8deca1e5c77a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_DisplayTheSearched), @"mvc.1.0.view", @"/Views/Book/DisplayTheSearched.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\_ViewImports.cshtml"
using DbAssetManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\_ViewImports.cshtml"
using DbAssetManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee816bb4eb265b24dd4a852dafbe8deca1e5c77a", @"/Views/Book/DisplayTheSearched.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f8a168f52e0a0ae9cbf156435f9f16c2a6c5f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_DisplayTheSearched : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DbAssetManagement.Controllers.BookController>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
  
    ViewBag.Title = "bookAsset";
    dynamic bookAsset = ViewBag.bookAsset;


#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>List of all Books</h1>\r\n\r\n<table class=\"table\">\r\n    ");
#nullable restore
#line 10 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <thead>
        <tr>
            <th> Asset Id</th>
            <th> Name</th>
            <th> Author</th>
            <th> Edition</th>
            <th> Date Of Publish</th>
        </tr>
    </thead>
    <tbody>


        <tr>
            <td>");
#nullable restore
#line 24 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
           Write(bookAsset.SerialNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
           Write(bookAsset.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
           Write(bookAsset.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
           Write(bookAsset.Edition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\Book\DisplayTheSearched.cshtml"
           Write(bookAsset.DateOfPublish.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n    <tfoot></tfoot>\r\n    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DbAssetManagement.Controllers.BookController>> Html { get; private set; }
    }
}
#pragma warning restore 1591
