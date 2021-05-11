using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<PatientAccount> _signInManager;
        private readonly UserManager<PatientAccount> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private ClinicDbContext _db;

        public RegisterModel(
            UserManager<PatientAccount> userManager,
            SignInManager<PatientAccount> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ClinicDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Surname { get; set; }

            [Required]
            [RegularExpression(@"[0-9]{11}", ErrorMessage = "Pesel must be in 11 digits format!")]
            public string Pesel { get; set; }


            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            
            [Phone]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone number")]
            [RegularExpression(@"[0-9]{9}", ErrorMessage = "Phone number must be in 9 digits format!")]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
           // System.Diagnostics.Debugger.Break();
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {


                /*
                 Tutaj cala logika odpowiadajaca za rejestracje pacjenta - czyli polaczenie go z odpowiednim klientem jezeli wszystko sie
                zgadza, stworzenie nowego klienta jezeli nie ma klienta z takim peselem, lub powiadomienie o bledzie jezeli jest ktos juz
                o takim peselu, ale nie zgadzaja sie imie badz nazwisko
                 */

                Patient existingPatientWithPesel = _db.GetPatientByPesel(Input.Pesel);
             //   System.Diagnostics.Debugger.Break();
                if (existingPatientWithPesel == null)
                {    //then create new patient
               //     System.Diagnostics.Debugger.Break();
                    _db.Add(new Patient { Name = Input.Name, Surname = Input.Surname, Pesel = Input.Pesel });
                    _db.SaveChanges();
                    foreach(var x in _db.GetPatients())
                        Console.WriteLine($"Name = {x.Name} Surname = {x.Surname}");
                  //  System.Diagnostics.Debugger.Break();
                    existingPatientWithPesel = _db.GetPatientByPesel(Input.Pesel);  //to find out new patient index
                //    System.Diagnostics.Debugger.Break();
                }
                else if (!existingPatientWithPesel.Name.Equals(Input.Name) || !existingPatientWithPesel.Surname.Equals(Input.Surname)){
                    //then patient with specified pesel already exists but something is wrong - he is with another name or surname!

                    return Page();  //TUTAJ TAK NAPRAWDE TRZEBA BEDZIE ZMIENIC ZEBY TO POKAZYWALO FAKTYCZNIE TO CO POWINNO!
                                    //zeby bardziej ekspresywne byly te komunikaty
                                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                }
               
                //else patient with specified pesel exists and everything is ok

                var user = new PatientAccount { UserName = Input.Email, Email = Input.Email, AccountOwnerID=existingPatientWithPesel.PatientID,
                TelephoneNumber = Input.PhoneNumber};

                //========================================================================================

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
