using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Controllers
{
        
                                                //TAK NAPRAWDE TEN KONTROLER BEDZIE MIAL JEDNO ZADANIE I JEDEN TYLKO WIDOK
                                                //a mianowicie przegladanie przez klienta jego historycznych wizyt, wiec i jedna metoda
                                                //tutaj wystarczy
    public class CasualUserController : Controller
    {
        private IHostingEnvironment _hostenv;

        private ClinicDbContext _db;

        private UserManager<PatientAccount> _userManager;
                                                                                    //nie jestem pewien czy dokladnie ta klasa
        public CasualUserController(IHostingEnvironment hostenv, ClinicDbContext db, UserManager<PatientAccount> userManager)
        {
            this._hostenv = hostenv;
            this._db = db;
            this._userManager = userManager;
//            _userManager.GetUserAsync();
        }

        // GET: Start
        [Route("CasualUserController/Start")]
        [HttpGet]
        public async Task<IActionResult> Index()        
        {
            //for testing purposes
               
            //
     //       _db.GetPatient((await _userManager.GetUserAsync()).Result.AccountOwnerID)
    //            _db.GetVisitsOfPatient(patient^)
//            var models = await _db.Doctors.Include(model => model.Specializations).ToListAsync();
            return View();
        }

    }
}
