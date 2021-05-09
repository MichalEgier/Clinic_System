using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{                                   //Klasa odpowiadajaca za polaczenie z baza danych, tutaj sa zdefiniowane te data sety, ktore sa w bazie
    public class ClinicDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SpecializationDoctorBridge> SpecializationDoctorBridges { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
           
        }

        public void DeleteDoctor(int id)
        {
            Doctor model = Doctors.Include(model => model.Specializations).ToList().FirstOrDefault(model => model.DoctorID == id);
            if (model == null)
                return;


            //To jeszcze zostanie dodane
            //Removing Specialiation if no longer used
            //List<Doctor> modelsWithSpecialiation = this.Doctors.Include(model => model.Specialiations).ToList().Where(mod => mod.Specialiation.Name.Equals(model.Specialiation.Name)).ToList();

            //if (modelsWithSpecialiation.Count == 1)
            //    Categories.Remove(Categories.ToList().First(cat => cat.Name == model.Specialiation.Name));

            Doctors.Remove(model);

            this.SaveChanges();
        }

        public void UpdateDoctor(int id, Doctor doctor)
        {
            DeleteDoctor(id);

            //Tutaj trzeba bedzie zrobic ze DLA KAZDEJ specjalizacji w Specializations wywolac to co tutaj jest wywolywane
            //Specialiation cat = doctor.Specialiation;
            //Specialiation inSet = this.Categories.ToList().FirstOrDefault(Specialiation => Specialiation.Name.Equals(cat.Name));
            //if (inSet != null)
            //{
            //    doctor.Specialiation = inSet;
            //}
            //else
            //    Categories.Add(cat);

            Doctors.Add(doctor);
            this.SaveChanges();
        }

    }
}
