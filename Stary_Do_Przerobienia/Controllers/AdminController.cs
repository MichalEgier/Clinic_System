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
            var models = await _db.Doctors.Include(model => model.Specializations).ToListAsync();
            return View(models);
        }

        // GET: Start/Details/5
        [Route("AdminController/Details/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(_db.Doctors.Include(model => model.Specializations).ToList().Where(model => model.DoctorID == id).FirstOrDefault());
        }



        // GET: Start/Create
        [Route("AdminController/Create")]
        [HttpGet]
        public ActionResult Create()
        {
            //ViewData["CategoryName"] = new SelectList(_db.Categories.ToList(), "Name", "Name");
            return View();
        }

        /*
        // POST: Start/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Create")]
        public ActionResult Create(Doctor doctor, IFormCollection collection)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    System.Diagnostics.Debug.WriteLine("\n\n\n MODEL IS VALID \n\n\n");

                    Doctor model = new Doctor();
                    model.Name = modelCreate.Name;
                    model.Price = Double.Parse(modelCreate.Price, CultureInfo.InvariantCulture);
                    model.Image = modelCreate.Image;
                    model.Category = new Category(modelCreate.Category);

                    Category cat = model.Category;
                    Category inSet = _db.Categories.ToList().FirstOrDefault(category => category.Name.Equals(cat.Name));
                    if (inSet != null)
                    {
                        model.Category = inSet;
                    }
                    else
                        _db.Categories.Add(cat);
                    System.Diagnostics.Debug.WriteLine("\n\n\n AFTER ADDING CATEGORY \n\n\n");
                    string uploadFolder = Path.Combine(_hostenv.WebRootPath, "upload");
                    string filename = DateTime.Now.ToString("MM_dd_yyyy_HH_mm") + ".jpg";
                    string filePath = Path.Combine(uploadFolder, filename);           //tutaj zmienic na te stemple czasowe
                    System.Diagnostics.Debug.WriteLine(filePath);
                    using (Stream filestr = new FileStream(filePath, FileMode.Create))
                    {
                        if (model.Image != null)
                        {
                            model.Image.CopyTo(target: filestr);
                            model.Filepath = Path.Combine("\\upload", filename);
                            model.AbsoluteFilepath = filePath;
                            model.Image = null;
                            model.OwnFile = true;
                        }
                        else
                        {
                            model.Filepath = Path.Combine("\\default", "plik.jpg");
                            model.OwnFile = false;
                        }
                    }
                    _db.Add(model);
                    _db.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("\n\n\n AFTER ADDING FILE \n\n\n");
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
            var model = _db.Doctors.Include(model => model.Specializations).ToList().First(model => model.DoctorID == id);
            ViewData["Filepath"] = model.Filepath;
            ViewData["Name"] = model.Name;
            ViewData["Category"] = model.Category.Name;
            ViewData["Price"] = model.Price;
            return View();
        }

        // POST: Start/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Edit/{id}")]
        public ActionResult Edit(int id, MyModelCreate modelCr, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Doctor model = new Doctor();
                    model.Name = modelCr.Name;
                    model.Price = Double.Parse(modelCr.Price, CultureInfo.InvariantCulture);
                    model.Category = new Category(modelCr.Category);

                    model.Filepath = _db.MyModels.First(model => model.Id==id).Filepath;
                    model.AbsoluteFilepath = _db.MyModels.First(model => model.Id == id).AbsoluteFilepath;
                    model.OwnFile = _db.MyModels.First(model => model.Id == id).OwnFile;
                    _db.UpdateModel(id, model);
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
            return View(_db.MyModels.Include(model => model.Category).ToList().Where(model => model.Id == id).FirstOrDefault());
        }

        // POST: Start/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Route("AdminController/Delete/{id}")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Doctor model = _db.MyModels.FirstOrDefault(mod => mod.Id == id);
                if (model != null && model.OwnFile)
                    try
                    {
                        System.IO.File.Delete(model.AbsoluteFilepath);
                    }
                    catch(System.IO.IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                _db.DeleteModel(id);
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
            return View(_db.Categories.ToList());
        }

        [HttpGet]
        public ActionResult Find(string name)
        {
            List<Doctor> modelsInCategory = _db.MyModels.Include(model => model.Category).ToList().Where(model => model.Category.Name.Equals(name)).ToList();
            LinkedList<Doctor> linkedList = new LinkedList<Doctor>(modelsInCategory);
       //     ViewData["LastView"] = View("Index", linkedList);
       //     return (ActionResult) ViewData["LastView"];
            return View("Index", linkedList);
        }


        public Dictionary<Doctor, int> ToProductQuantityDict(Cart cart)
        {
            Dictionary<Doctor, int> result = new Dictionary<Doctor, int>();
            foreach (var x in cart.ProductsInCart.Keys)
            {
                result.Add(_db.MyModels.Include(model => model.Category).Where(model => model.Id == x).First(), cart.ProductsInCart[x]);
            }
            return result;
        }

        public double CountCartCost(Cart cart)
        {
            double cost = 0.0;
            foreach (var item in ToProductQuantityDict(cart))
            {
                cost += item.Key.Price * item.Value;    //price * quantity
            }
            return cost;
        }

        */
    }
}
