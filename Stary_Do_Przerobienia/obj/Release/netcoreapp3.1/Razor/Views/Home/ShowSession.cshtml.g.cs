#pragma checksum "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09848ea4656a6013234b4490143dae07edccaa21"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowSession), @"mvc.1.0.view", @"/Views/Home/ShowSession.cshtml")]
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
#line 1 "C:\Users\user\source\repos\WebApp1\Views\_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\WebApp1\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
using System.Drawing;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09848ea4656a6013234b4490143dae07edccaa21", @"/Views/Home/ShowSession.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowSession : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
  
    ViewData["Title"] = "Show Session";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Show session</h1>\r\n    <ul>\r\n        <li>\r\n            Name: ");
#nullable restore
#line 10 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
             Write(ViewData["name"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n        <li>\r\n            Age: ");
#nullable restore
#line 13 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
            Write(ViewData["age"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n        <li>\r\n            Point.X: ");
#nullable restore
#line 16 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
                Write(ViewData["x"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n        <li>\r\n            Point.Y: ");
#nullable restore
#line 19 "C:\Users\user\source\repos\WebApp1\Views\Home\ShowSession.cshtml"
                Write(ViewData["y"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </li>\r\n    </ul>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
