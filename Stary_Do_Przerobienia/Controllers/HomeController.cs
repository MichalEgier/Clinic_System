using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{
                                        //Ten kontroler ma wykonywac routing pomiedzy tymi wszelkimi stronami statycznymi
                                        //dostepnymi dla kazdego pacjenta, np kontakt, galeria itp itd ...
                                        //TUTAJ NALEZY ZAIMPLEMENTOWAC TEN ROUTING ORAZ JAKIES POCZATKOWE BARDZO PRYMITYWNE WIDOKI DO TEGO
                                        //np dla kontaktu tylko na srodku napis StronkaKontakt
                                        //Poniewaz te stronki beda statyczne a frontend dopiero pozniej bedziemy robic

                                        //jedyne co juz jako tako trzeba bedzie zrobic to ta rejestracja sie pacjenta na konkretny termin
                                        
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ClinicDbContext _db;

        public HomeController(ILogger<HomeController> logger, ClinicDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public ViewResult Index() => View();

        //[Authorize(Roles = "Admin")]
        [Route("Start")]
        [HttpGet]
        public IActionResult Start()
        {

                                        //Database initializing with sample data here
//            Data.MyClinicDbInitializer.ClearDoctorsAndSpecializations(_db);   //to see adding process
            System.Diagnostics.Debug.WriteLine("Before data seed!");
            //for testing purposes
            _db.SeedData();
            System.Diagnostics.Debug.WriteLine("After data seed!");
            //          Console.WriteLine("Data seeded!");
            foreach (Doctor doctor in _db.GetDoctors())
                System.Diagnostics.Debug.WriteLine(doctor.ToString());
            System.Diagnostics.Debug.WriteLine("Before Specializations!");
            foreach (Specialization spec in _db.Specializations)
                System.Diagnostics.Debug.WriteLine(spec.SpecializationName);
            System.Diagnostics.Debug.WriteLine("Before Bridges!");
            foreach (SpecializationDoctorBridge bridge in _db.SpecializationDoctorBridges)
                System.Diagnostics.Debug.WriteLine("Doctor = " + bridge.Doctor.Surname + " Specialization = " + bridge.Specialization.SpecializationName);
            //  

            return View();
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize(Roles = "Admin")]
        [Route("admin")]
        [HttpGet]
        public IActionResult GoAdminMode()
        {
            return RedirectToAction("Start", "AdminController");
        }

        [AllowAnonymous]
        [Route("user")]
        [HttpGet]
        public IActionResult GoShopping()
        {
            return RedirectToAction("Start", "CasualUserController");
        }
    }
}
