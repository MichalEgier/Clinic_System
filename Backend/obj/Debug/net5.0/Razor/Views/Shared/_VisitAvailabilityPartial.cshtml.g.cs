#pragma checksum "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6534dcc0269f9f31b890f2de5b09755787f385e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__VisitAvailabilityPartial), @"mvc.1.0.view", @"/Views/Shared/_VisitAvailabilityPartial.cshtml")]
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
#line 2 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\_ViewImports.cshtml"
using WebApp1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6534dcc0269f9f31b890f2de5b09755787f385e3", @"/Views/Shared/_VisitAvailabilityPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__VisitAvailabilityPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp1.Models.VisitAvailability>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Visit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: black"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    .Visit {
        height: 100%;
        padding: 8px;
        padding-left: 16px;
        padding-right: 16px;
    }

    .red {
        background-color: red;
    }

    .lightgray {
        background-color: lightgrey;
    }

    .lightgreen {
        background-color: lightgreen;
        transition: transform .2s;
        margin: 0 auto;
    }
        /*behavior on mouse hover*/
        .lightgreen:hover {
            -ms-transform: scale(1.2); /* IE 9 */
            -webkit-transform: scale(1.2); /* Safari 3-8 */
            transform: scale(1.2); /*enlarge in scale 1.2*/
            background-color: lawngreen; /*change color to lawngreen*/
        }
</style>
<td>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6534dcc0269f9f31b890f2de5b09755787f385e35000", async() => {
                WriteLiteral("\r\n        <!--Html.ActionLink(\" Register\", \"Visit\" , \"HomeController\" , null, null, null, new VisitAvailability { Id=(Model.Id) }, null)-->\r\n");
#nullable restore
#line 41 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
         if (Model.VisitAvailable)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6534dcc0269f9f31b890f2de5b09755787f385e35769", async() => {
                    WriteLiteral("\r\n                ");
#nullable restore
#line 44 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
           Write(Html.DisplayFor(modelItem => (Model.Date)));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                <div>\r\n                    Doctors available:\r\n                </div>\r\n                <strong>\r\n                    ");
#nullable restore
#line 49 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
               Write(Html.DisplayFor(modelItem => Model.DoctorsAvailable));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n                </strong>\r\n            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 52 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
       Write(Html.DisplayFor(modelItem => (Model.Date)));

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div>\r\n                Doctors available:\r\n            </div>\r\n            <strong>\r\n                ");
#nullable restore
#line 60 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
           Write(Html.DisplayFor(modelItem => Model.DoctorsAvailable));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </strong>\r\n");
#nullable restore
#line 62 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 932, "Visit", 932, 5, true);
#nullable restore
#line 39 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_VisitAvailabilityPartial.cshtml"
AddHtmlAttributeValue(" ", 937, Model.VisitAvailabilityColor, 938, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</td>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp1.Models.VisitAvailability> Html { get; private set; }
    }
}
#pragma warning restore 1591
