#pragma checksum "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8f15097036d60454e3985b60a94b036b40a15968"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Timetable), @"mvc.1.0.view", @"/Views/Home/Timetable.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\_ViewImports.cshtml"
using WebApp1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f15097036d60454e3985b60a94b036b40a15968", @"/Views/Home/Timetable.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Timetable : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApp1.Models.VisitAvailability>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
  
    ViewData["Title"] = "Timetable";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Timetable</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f15097036d60454e3985b60a94b036b40a159683985", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Monday
            </th>
            <th>
                Tuesday
            </th>
            <th>
                Wednesday
            </th>
            <th>
                Thursday
            </th>
            <th>
                Friday
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 36 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
 for (int i = 0; i < Model.Count() / 5; i++) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n");
#nullable restore
#line 38 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
             for(int j = 0; j < 5; j++)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n                ");
#nullable restore
#line 41 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
           Write(Html.RenderPartialAsync("_SingleVisitAvailability", Model.ElementAt(i + (Model.Count() / 5)*j)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n            </td>\r\n");
#nullable restore
#line 43 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\pppkw\source\repos\WebowkaProjekt\Clinic_System\Backend\Views\Home\Timetable.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApp1.Models.VisitAvailability>> Html { get; private set; }
    }
}
#pragma warning restore 1591
