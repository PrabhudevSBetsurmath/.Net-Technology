#pragma checksum "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d7f0da199172650bb3825b0c91a0443e6c4c1cc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Software_DeleteSoftware), @"mvc.1.0.view", @"/Views/Software/DeleteSoftware.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d7f0da199172650bb3825b0c91a0443e6c4c1cc", @"/Views/Software/DeleteSoftware.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c79aa51e37bc5b40d71c2b54724aa3912b6a1ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Software_DeleteSoftware : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AssetManagement.Models.Software>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>DeleteSoftwareLicense</h1>\r\n");
#nullable restore
#line 3 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 8 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
       Write(Html.LabelFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"editor-label\">\r\n            ");
#nullable restore
#line 11 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
       Write(Html.EditorFor(model => model.id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 12 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
       Write(Html.ValidationMessageFor(model => model.id, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <br />\r\n        <input type=\"submit\" class=\"btn btn-primary\" value=\"Delete\" />\r\n    </fieldset>\r\n");
#nullable restore
#line 17 "D:\submission\AssetManagement\AssetManagement\Views\Software\DeleteSoftware.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AssetManagement.Models.Software> Html { get; private set; }
    }
}
#pragma warning restore 1591
