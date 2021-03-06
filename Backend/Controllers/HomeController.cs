using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{                                       
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ClinicDbContext _db;
        private UserManager<PatientAccount> _userManager;

        public HomeController(ILogger<HomeController> logger, ClinicDbContext db, UserManager<PatientAccount> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
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

        [Route("Home/Visit/{year}/{month}/{day}/{hour}/{minute}/{doctorID}")]
        [HttpGet]
        public async Task<ActionResult> Visit(int year, int month, int day, int hour, int minute, int doctorID)
        {
            //            VisitAvailability visitAvailability = null;
            //           if (visitAvailabilityID != null)
            //               visitAvailability = _db.VisitAvailability.Where(model => model.Id == visitAvailabilityID).FirstOrDefault();
            //          if (visitAvailability != null)
            //            {
            //               ViewData["Date"] = visitAvailability.Date;
            //               ViewData["VisitAvailabilityID"] = visitAvailabilityID;
            //           }
          //  visitAval = _db.VisitAvailability.
          //      Where(model => model.Id == visitAval.Id).FirstOrDefault();    //fetching visit aval values

          //  ViewData["Date"] = visitAval.Date;

            PatientAccount currentUser = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("Admin"))
                return View();
            ViewData["PhoneNumber"] = User.Identity.Name != null && !User.Identity.Name.Equals("") ? currentUser.PhoneNumber : "";
            ViewData["Pesel"] = User.Identity.Name != null && !User.Identity.Name.Equals("") ? 
                                            _db.GetPatient(currentUser.AccountOwnerID).Pesel : "";
            ViewData["Name"] = User.Identity.Name != null && !User.Identity.Name.Equals("") ?
                                            _db.GetPatient(currentUser.AccountOwnerID).Name : "";
            ViewData["Surname"] = User.Identity.Name != null && !User.Identity.Name.Equals("") ?
                                            _db.GetPatient(currentUser.AccountOwnerID).Surname : "";

            //tutaj cos trzeba zrobic zeby zablokowac opcje jednak bez wyboru lekarza
            //            if (year != null && month != null && day != null && hour != null && minute != null && doctorID != null)
            //            {
            DateTime date = new DateTime(year, month, day, hour, minute, 0);
                return View(new VisitDTO() { VisitDate = date, DoctorID = doctorID });
 //           }

            return View();
        }

        [Route("Home/Visit/{year}/{month}/{day}/{hour}/{minute}/{doctorID}")]
        [HttpPost]
        public ActionResult Visit(VisitDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Patient existingPatientWithPesel = _db.GetPatientByPesel(model.Pesel);
                    if (existingPatientWithPesel == null)
                    {
                        _db.Add(new Patient { Name = model.Name, Surname = model.Surname, Pesel = model.Pesel });
                        _db.SaveChanges();
                        existingPatientWithPesel = _db.GetPatientByPesel(model.Pesel);
                    }
                    else if (!existingPatientWithPesel.Name.Equals(model.Name) || !existingPatientWithPesel.Surname.Equals(model.Surname))
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "There is currently patient with such a pesel number in database, but the name or the surname are different than" +
            "                               specified in form! Please contact clinic via mail or phone to solve this problem or try to register again";
                        return View("MessageView");
                    }

                    // if a visit is taken before patient finishes registration redirects to message page
                    if (_db.Visits.Where(visit => visit.Doctor.DoctorID == model.DoctorID && visit.VisitDate.CompareTo(model.VisitDate) == 0).Count() != 0)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "Someone has already registered for this visit";
                        return View("MessageView");
                    }
                    // if there is a visit in the same time redirects to message page
                    else if(_db.Visits.Where(visit => visit.Patient.Pesel.Equals(model.Pesel) && visit.VisitDate.CompareTo(model.VisitDate) == 0)
                        .Count()!= 0)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "You have already registered for a visit during this time. Pick another hour or day";
                        return View("MessageView");
                    }
                    Visit newVisit = new Visit();
                    //newVisit.VisitID = _db.Visits.Max(visit => visit.VisitID) + 1;
                    newVisit.VisitDate = model.VisitDate;
                    newVisit.Doctor = _db.Doctors.Where(doc => doc.DoctorID == model.DoctorID).FirstOrDefault();
                    if(newVisit.Doctor is null)
                    {
                        ViewData["valid"] = "text-danger";
                        ViewData["msg"] = "Doctor with given id doesn't exist";
                        return View("MessageView");
                    }
                    newVisit.PatientPrevisitNote = model.PatientPrevisitNote;
                    newVisit.Patient = _db.Patients.Where(patient => patient.Pesel.Equals(model.Pesel)).FirstOrDefault();

                    newVisit.TelephoneNumber = model.TelephoneNumber;

                    ViewData["valid"] = "text-success";
                    ViewData["msg"] = "Registered new visit!";
                    _db.AddVisit(newVisit);
                    _db.SaveChanges();
                }

                //tutaj do ViewData wpakujemy cos zeby wyswietlilo ten pop up
                return View("MessageView");   //redirecting to index  //tutaj jeszcze pop up trzeba by bylo
                                //View("Start") dla przekierowania na index
            }
            catch
            {
                return View();
            }
        }

        [Route("Home/Specializations")]
        [HttpGet]
        public async Task<ActionResult> Specializations()
        {
            var specializations = _db.Specializations.ToList();
            foreach (var spec in specializations)
                spec.DoctorsWithSpecialization = await _db.GetDoctorsWithSpecializationAsync(spec.SpecializationName);
            return View(specializations);
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

        [Route("Home/DoctorVisits/{doctorID}")]
        [HttpGet]
        public ActionResult DoctorVisits(int doctorID)
        {
            ViewData["TimetableInfo"] = "Doctor: " + _db.GetDoctor(doctorID).DoctorLabel;
            return View("Timetable", (_db.GetVisitAvailabilitiesDoctor(doctorID, DateTime.Now).Result));
        }


        [Route("Home/SpecifyVisit")]
        [HttpGet]
        public ActionResult SpecifyVisit()
        {
            List<String> specs = _db.Specializations.Select(spec => spec.SpecializationName).ToList<String>();
            ViewData["Specializations"] = specs;
            return View();
        }

        [Route("Home/SpecifyVisit")]
        [HttpPost]
        public ActionResult SpecifyVisit(SpecifyVisit sv)
        {
            System.Diagnostics.Debug.WriteLine(sv.Specialization + " " + sv.Date);
            ViewData["TimetableInfo"] = "Specialization: " + sv.Specialization;
            System.Diagnostics.Debug.WriteLine(sv.Date.Year + "/" + sv.Date.Month + "/" + sv.Date.Day);
            return View("Timetable", (_db.GetVisitAvailabilitiesForSpecification(sv.Specialization, sv.Date).Result));
        }

        [Route("Home/Timetable")]
        [HttpGet]
        public ActionResult Timetable(IEnumerable<VisitAvailability> visitAvailabilities)
        {
            return View(visitAvailabilities);
        }
    }
}
