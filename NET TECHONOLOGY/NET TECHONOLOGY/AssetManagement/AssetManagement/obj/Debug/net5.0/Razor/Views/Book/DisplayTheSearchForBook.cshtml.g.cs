#pragma checksum "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f3af522d2bc8cf0b77ffe46bbb102ee868866a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_DisplayTheSearchForBook), @"mvc.1.0.view", @"/Views/Book/DisplayTheSearchForBook.cshtml")]
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
#line 1 "D:\submission\AssetManagement\AssetManagement\Views\_ViewImports.cshtml"
using AssetManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\submission\AssetManagement\AssetManagement\Views\_ViewImports.cshtml"
using AssetManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f3af522d2bc8cf0b77ffe46bbb102ee868866a5", @"/Views/Book/DisplayTheSearchForBook.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c79aa51e37bc5b40d71c2b54724aa3912b6a1ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_DisplayTheSearchForBook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AssetManagement.Controllers.BookController>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
  
    ViewBag.Title = "bookAsset";
    dynamic bookAsset = ViewBag.bookAsset;


#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>List of all Books</h1>\r\n\r\n<table class=\"table\">\r\n ");
#nullable restore
#line 10 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
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
#line 24 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
           Write(bookAsset.id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
           Write(bookAsset.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
           Write(bookAsset.author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
           Write(bookAsset.edition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "D:\submission\AssetManagement\AssetManagement\Views\Book\DisplayTheSearchForBook.cshtml"
           Write(bookAsset.dateOfPublish.ToString("dd/MM/yyyy"));

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AssetManagement.Controllers.BookController>> Html { get; private set; }
    }
}
#pragma warning restore 1591
