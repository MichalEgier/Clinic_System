#pragma checksum "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86e20a3bde80f5e134c5604acd5f6b3cc98d436e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DoctorPartial), @"mvc.1.0.view", @"/Views/Shared/_DoctorPartial.cshtml")]
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
#nullable restore
#line 7 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86e20a3bde80f5e134c5604acd5f6b3cc98d436e", @"/Views/Shared/_DoctorPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6545200b2b1f984d3aecce45fd26db78e2f32d9d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__DoctorPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Doctor>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("<tr>\r\n    <td>\r\n        Id=");
#nullable restore
#line 14 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
      Write(Model.DoctorID);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        Name=");
#nullable restore
#line 17 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        Surname=");
#nullable restore
#line 20 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
           Write(Model.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        Title=");
#nullable restore
#line 23 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
         Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n        Specializations=");
#nullable restore
#line 26 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
                   Write(Model.CommaSeparatedSpecializations);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n    <td>\r\n");
#nullable restore
#line 29 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
         if (SignInManager.IsSignedIn(User) && User.IsInRole("Admin"))
        {
            
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
       Write(Html.ActionLink(" --Details-- ", "Details", "AdminController", new { id = Model.DoctorID }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
                                                                                                        ;
            
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
       Write(Html.ActionLink(" --Delete-- ", "Delete", "AdminController", new { id = Model.DoctorID }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
                                                                                                      ;
            
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
       Write(Html.ActionLink(" --Edit-- ", "Edit", "AdminController", new { id = Model.DoctorID }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
                                                                                                  ;
            
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
       Write(Html.ActionLink(" --Visits-- ", "DoctorVisits", "AdminController", new { id = Model.DoctorID }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\egier\Desktop\Workspace\Semestr 6\Zaawansowane_Techniki_Webowe\ProjektKoncowy\Przychodnia\Przychodnia_Backend\Clinic_System\Backend\Views\Shared\_DoctorPartial.cshtml"
                                                                                                            

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td>\r\n</tr>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<PatientAccount> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<PatientAccount> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Doctor> Html { get; private set; }
    }
}
#pragma warning restore 1591
