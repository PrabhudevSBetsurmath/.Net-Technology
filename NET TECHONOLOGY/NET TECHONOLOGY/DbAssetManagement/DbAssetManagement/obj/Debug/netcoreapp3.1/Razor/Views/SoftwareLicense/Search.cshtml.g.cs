#pragma checksum "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d72084167f106242f244dea1e14e34b268e58393"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SoftwareLicense_Search), @"mvc.1.0.view", @"/Views/SoftwareLicense/Search.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d72084167f106242f244dea1e14e34b268e58393", @"/Views/SoftwareLicense/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f8a168f52e0a0ae9cbf156435f9f16c2a6c5f0", @"/Views/_ViewImports.cshtml")]
    public class Views_SoftwareLicense_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DbAssetManagement.Models.SoftwareLicense>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>SearchSoftware</h1>\r\n");
#nullable restore
#line 3 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 8 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
       Write(Html.LabelFor(model => model.SerialNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 11 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
       Write(Html.EditorFor(model => model.SerialNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 12 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
       Write(Html.ValidationMessageFor(model => model.SerialNo, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <br />\r\n        <input type=\"submit\" class=\"btn btn-primary\" value=\"Search\" />\r\n    </fieldset>\r\n");
#nullable restore
#line 17 "D:\ASP\DbAssetManagement\DbAssetManagement\Views\SoftwareLicense\Search.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DbAssetManagement.Models.SoftwareLicense> Html { get; private set; }
    }
}
#pragma warning restore 1591