#pragma checksum "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b43d4c4a2cdc55869da3cf390a63eb338d9bd58"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_Index), @"mvc.1.0.view", @"/Views/Admin/Index.cshtml")]
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
#line 1 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b43d4c4a2cdc55869da3cf390a63eb338d9bd58", @"/Views/Admin/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Doctor>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n");
#nullable restore
#line 9 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml"
Write(Html.ActionLink("Create", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
#nullable restore
#line 10 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml"
Write(Html.ActionLink("Search", "Search"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n<table>\r\n");
#nullable restore
#line 12 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Admin\Index.cshtml"
     foreach (var item in Model)
    {
        //Html.RenderPartial("_DoctorPartial", item);
        await Html.RenderPartialAsync("_DoctorPartial", item);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Doctor>> Html { get; private set; }
    }
}
#pragma warning restore 1591
