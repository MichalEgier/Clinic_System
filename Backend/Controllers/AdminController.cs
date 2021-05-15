using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    [Authorize (Roles = "Admin")]
    public class AdminController : Controller
    {

        private IHostingEnvironment _hostenv;

        private ClinicDbContext _db;

        public AdminController(IHostingEnvironment hostenv, ClinicDbContext db)
        {
            this._hostenv = hostenv;
            this._db = db;
        }

     
                // GET: Start
        [Route("AdminController/Start")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _db.GetDoctorsAsync();
            return View(models);
        }

        // GET: Start/Details/5
        [Route("AdminController/Details/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_db.GetDoctor(id));
        }



        // GET: Start/Create
        [Route("AdminController/Create")]
        [HttpGet]
        public ActionResult Create()
        {
            //ViewData["CategoryName"] = new SelectList(_db.Categories.ToList(), "Name", "Name");
            return View();
        }

        
        // POST: Start/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Create")]
        public ActionResult Create(DoctorDTO doctorDTO, IFormCollection collection)
        {
            
            try
            {
                if (ModelState.IsValid)
                {

                    Doctor doctor = new Doctor();
                    doctor.Name = doctorDTO.Name;
                    doctor.Surname = doctorDTO.Surname;
                    doctor.Title = doctorDTO.Title;

                    doctor.Specializations = new LinkedList<Specialization>();
                    //Specializations parsing

                    var specializationStrings = doctorDTO.SpecializationsString.Trim().Split(" ");
                    foreach (var specializationStr in specializationStrings)
                        doctor.Specializations.Add(new Specialization() { SpecializationName = specializationStr });

                    _db.AddDoctor(doctor);
                    _db.SaveChanges(); 
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Start/Edit/5
        [Route("AdminController/Edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _db.GetDoctor(id);
          //  ViewData["Filepath"] = model.Filepath;
          //  ViewData["Name"] = model.Name;
          //  ViewData["Category"] = model.Category.Name;
          //  ViewData["Price"] = model.Price;
            return View();
        }

        // POST: Start/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Edit/{id}")]
        public ActionResult Edit(int id, DoctorDTO doctorDTO, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Doctor doctor = new Doctor();
                    doctor.Name = doctorDTO.Name;
                    doctor.Surname = doctorDTO.Surname;
                    doctor.Title = doctorDTO.Title;

                    doctor.Specializations = new LinkedList<Specialization>();
                    //Specializations parsing

                    var specializationStrings = doctorDTO.SpecializationsString.Trim().Split(" ");
                    foreach(var specializationStr in specializationStrings)
                        doctor.Specializations.Add(new Specialization() { SpecializationName = specializationStr });

                    _db.UpdateDoctor(id, doctor);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Start/Delete/5
        [Route("AdminController/Delete/{id}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_db.GetDoctor(id));
        }

        // POST: Start/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Delete/{id}")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _db.DeleteDoctor(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        [HttpGet]
        public ActionResult Search()
        {
            return View(_db.Specializations.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> Find(string name)
        {
            var doctorsWithSpec = await _db.GetDoctorsWithSpecializationAsync(name);
            LinkedList<Doctor> linkedList = new LinkedList<Doctor>(doctorsWithSpec);
       //     ViewData["LastView"] = View("Index", linkedList);
       //     return (ActionResult) ViewData["LastView"];
            return View("Index", linkedList);
        }
        
    }
}
