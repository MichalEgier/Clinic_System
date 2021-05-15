using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class MyClinicDbInitializer
    {
                        //use very carefully only for early testing purposes!
        public static void ClearDoctorsAndSpecializations(ClinicDbContext db)
        {
            List<int> ids = db.Doctors.Select(model => model.DoctorID).ToList();
            foreach (var id in ids)
                db.DeleteDoctor(id);        //always use DeleteDoctor method to delete doctor! Don't do this manually because of problems
            ids = db.Specializations.Select(model => model.SpecializationID).ToList();
            foreach (var id in ids)
                db.DeleteSpecialization(id);
            db.SaveChanges();                               //with specializations!
        }

        public static void SeedData(ClinicDbContext db)         //tutaj by tak naprawde mozna zrobic te metody async ale dobra juz
        {
            Doctor doctor1 = new Doctor() { Name = "Maciej", Surname = "Kowalski", Title = "Doktor" };
            var specialization1 = new LinkedList<Specialization>();
            specialization1.AddLast(new Specialization() { SpecializationName = "Ginekolog" });
            specialization1.AddLast(new Specialization() { SpecializationName = "Endokrynolog" });
            doctor1.Specializations = specialization1;

            Doctor doctor2 = new Doctor() { Name = "Marcin", Surname = "Nowak", Title = "Profesor" };
            var specialization2 = new LinkedList<Specialization>();
            specialization2.AddLast(new Specialization() { SpecializationName = "Ginekolog" });
            specialization2.AddLast(new Specialization() { SpecializationName = "Proktolog" });
            doctor2.Specializations = specialization2;

            Doctor doctor3 = new Doctor() { Name = "Małgorzata", Surname = "Wróbel", Title = "Doktor" };
            var specialization3 = new LinkedList<Specialization>();
            specialization3.AddLast(new Specialization() { SpecializationName = "Kardiolog" });
            specialization3.AddLast(new Specialization() { SpecializationName = "Pulmonolog" });
            doctor3.Specializations = specialization3;

            if (db.GetDoctors().Count() == 0) { 
                db.AddDoctor(doctor1);      //use add doctor, not just Doctor! db context will handle doctor specializations in this method
                db.AddDoctor(doctor2);
                db.AddDoctor(doctor3);
            }

            db.SaveChanges();
        }


    }
}
