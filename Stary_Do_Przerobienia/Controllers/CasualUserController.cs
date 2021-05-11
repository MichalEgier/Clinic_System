using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        }

        // GET: Start
        [Route("CasualUser/Start")]
        [HttpGet]
        public async Task<IActionResult> Index()        
        {
            System.Diagnostics.Debug.WriteLine("przed");
            var id = _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)).Result.AccountOwnerID;
            var models = await _db.Visits.Where(model => model.Patient.PatientID == id).ToListAsync();
            return View(models);
        }

    }
}
