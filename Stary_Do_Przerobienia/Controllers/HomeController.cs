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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ClinicDbContext _db;

        public HomeController(ILogger<HomeController> logger, ClinicDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public ViewResult Index() => View("Start");

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

        [Route("Home/Visit")]
        [HttpGet]
        public ActionResult Visit()
        {
            return View();
        }

        [Route("Home/Visit")]
        [HttpPost]
        public ActionResult Visit(VisitDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine(model.VisitDate);
                    if (_db.Visits.Where(visit => visit.Doctor.DoctorID == model.DoctorID && visit.VisitDate.CompareTo(model.VisitDate) == 0).Count() != 0)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "Someone has already registered for this visit";
                        return View();
                    }
                    Visit newVisit = new Visit();
                    //newVisit.VisitID = _db.Visits.Max(visit => visit.VisitID) + 1;
                    newVisit.VisitDate = model.VisitDate;
                    newVisit.Doctor = _db.Doctors.Where(doc => doc.DoctorID == model.DoctorID).FirstOrDefault();
                    if(newVisit.Doctor is null)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "Doctor with given id doesn't exist";
                        return View();
                    }
                    newVisit.PatientPrevisitNote = model.PatientPrevisitNote;
                    newVisit.Patient = _db.Patients.Where(patient => patient.Pesel.Equals(model.Pesel)).FirstOrDefault();
                    if (newVisit.Patient is null)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "Patient with given pesel doesn't exist";
                        return View();
                    }

                    newVisit.TelephoneNumber = model.TelephoneNumber;

                    ViewData["valid"] = "text-success";
                    ViewData["msg"] = "Registered new visit!";
                    _db.AddVisit(newVisit);
                    _db.SaveChanges();
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [Route("Home/Specializations")]
        [HttpGet]
        public ActionResult Specializations()
        {
            return View(_db.Specializations);
        }

        [Route("Home/Gallery")]
        [HttpGet]
        public ActionResult Gallery()
        {
            return View();
        }

        [Route("Home/Contact")]
        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("Home/Pricelist")]
        [HttpGet]
        public ActionResult Pricelist()
        {
            return View();
        }
    }
}
