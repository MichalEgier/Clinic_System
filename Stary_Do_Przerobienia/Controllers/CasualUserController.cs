using System;
using System.Collections.Generic;
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

    public class CasualUserController : Controller
    {
        private IHostingEnvironment _hostenv;

        private ClinicDbContext _db;

        public CasualUserController(IHostingEnvironment hostenv, ClinicDbContext db)
        {
            this._hostenv = hostenv;
            this._db = db;

        }

        // GET: Start
        [Route("CasualUserController/Start")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var models = await _db.Doctors.Include(model => model.Specializations).ToListAsync();
            return View(models);
        }

        // GET: Start/Details/5
        [Route("CasualUserController/Details/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_db.Doctors.Include(model => model.Specializations).ToList().Where(model => model.DoctorID == id).FirstOrDefault());
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View(_db.Specializations.ToList());
        }


        //Metoda od wyszukiwania lekarzy z konkretna specjalizacja

        [HttpGet]
        public ActionResult Find(string name)
        {
            //Tutaj trzeba bedzie jakos to zrobic znowu jako kolekcje nie pojedynczy
            //         List<Doctor> modelsInCategory = _db.Doctors.Include(model => model.Specializations).ToList().Where(model => model.Specializations.Equals(name)).ToList();

            //     LinkedList<Doctor> linkedList = new LinkedList<Doctor>(modelsInCategory);
            //     ViewData["LastView"] = View("Index", linkedList);
            //     return (ActionResult) ViewData["LastView"];
            //            return View("Index", linkedList);
            return View();
        }

    }
}
