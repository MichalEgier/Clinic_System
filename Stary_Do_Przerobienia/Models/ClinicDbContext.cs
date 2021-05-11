using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.Data;

namespace WebApp1.Models
{                                   //Klasa odpowiadajaca za polaczenie z baza danych, tutaj sa zdefiniowane te data sety, ktore sa w bazie
    public class ClinicDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SpecializationDoctorBridge> SpecializationDoctorBridges { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

//        public DbSet<Cabinet> Cabinets { get; set; }
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {
           
        }



        public void SeedData()
        {
            MyClinicDbInitializer.SeedData(this);
        }

        //Niektore metody sa async niektore nie! To ewentualnie do poprawy jak bedzie czas

        //Always use AddDoctor to add doctor! Don't add doctor manually, because of problems with specializations atribute!
        //Also use DeleteDoctor to delete doctor for the same reasons!
        public void AddDoctor(Doctor doctor)
        {
        //    int nextId = 0;           //TUTAJ AUTOMATYCZNIE WSADZI TEZ ID - NIE MOZNA RECZNIE BO BEDZIE EXCEPTION!
      //      if (Doctors.Count() != 0)
      //          nextId = Doctors.Select(doct => doct.DoctorID).Max() + 1;
       //     doctor.DoctorID = nextId;
            Doctors.Add(doctor);
//            this.SaveChanges(); //to find out new id - im not sure if this gonna work
            
            foreach(Specialization specialization in doctor.Specializations)
            {
                Specialization specializationFound = this.Specializations
                    .Where(model => model.SpecializationName.Equals(specialization.SpecializationName)).FirstOrDefault();
                if (specializationFound == null)
                {
                    this.Specializations.Add(specialization);
                    SpecializationDoctorBridges.Add(new SpecializationDoctorBridge() { Doctor = doctor, Specialization = specialization });
                }
                else
                    SpecializationDoctorBridges.Add(new SpecializationDoctorBridge() { Doctor = doctor, Specialization = specializationFound }); 
            }
            this.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return GetDoctors().Where(model => model.DoctorID == id).FirstOrDefault();
        }

       // public Task<Doctor> GetDoctorAsync(int id)
       // {
        //}

        public ICollection<Doctor> GetDoctors()
        {
            ICollection<Doctor> doctors = Doctors.ToList();
            foreach(Doctor model in doctors)
                model.Specializations = SpecializationDoctorBridges.Include(m => m.Doctor)
                .Where(bridge => bridge.Doctor.DoctorID == model.DoctorID).Include(m => m.Specialization).Select(m => m.Specialization).ToList();
            return doctors;
        }

        public async Task<ICollection<Doctor>> GetDoctorsAsync()
        {
            var doctors = await Doctors.ToListAsync();
            foreach(var model in doctors)
                model.Specializations = await SpecializationDoctorBridges.Include(m => m.Doctor)
                .Where(bridge => bridge.Doctor.DoctorID == model.DoctorID).Include(m => m.Specialization).Select(m => m.Specialization).ToListAsync();
            return doctors;
        }


        public async Task<List<Doctor>> GetDoctorsWithSpecializationAsync(string specializationName)
        {
            //not completely effective way to do this but it won't be a problem with only a few doctors
            var doctors = await Doctors.Where(model => SpecializationDoctorBridges
                                                    .Where(bridge => bridge.Specialization.SpecializationName.Equals(specializationName)
                                                    && bridge.Doctor.DoctorID == model.DoctorID).FirstOrDefault() != null)
                                                        .ToListAsync();
            foreach (var model in doctors)
                model.Specializations = await SpecializationDoctorBridges.Include(m => m.Doctor)
                .Where(bridge => bridge.Doctor.DoctorID == model.DoctorID).Include(m => m.Specialization).Select(m => m.Specialization).ToListAsync();
            return doctors;
        }

        //Delete doctor only using this method! Not manually!
        public void DeleteDoctor(int id)
        {
            Doctor model = Doctors.FirstOrDefault(model => model.DoctorID == id);
            if (model == null)
                return;

            ICollection<SpecializationDoctorBridge> toRemove = SpecializationDoctorBridges.Where(bridge => bridge.Doctor.Equals(model)).ToList();

            foreach (var bridge in toRemove)
                SpecializationDoctorBridges.Remove(bridge);

            Doctors.Remove(model);

            this.SaveChanges();
        }


        //nw czy to tak moze zostac ze usuwac i dodawac po prostu, czy nie bedzie z tym problemow w przyszlosci
        public void UpdateDoctor(int id, Doctor doctor)
        {
            DeleteDoctor(id);

            Doctors.Add(doctor);
            this.SaveChanges();
        }


        public Visit GetVisit(int id)
        {
            //tutaj jeszcze trzeba bedzie chyba zaimplementowac te klucze obce dla visit
            return Visits.Where(model => model.VisitID == id).FirstOrDefault();
        }

        public ICollection<Visit> GetVisits()
        {
            //tutaj jeszcze trzeba bedzie chyba zaimplementowac te klucze obce dla visit
            return Visits.ToList();
        }

      /*  //no need to care about patient ID - method will handle this and will set correct id to patient before adding to db
        public void AddPatient(Patient patient)
        {
            
        }
*/
        public Patient GetPatientByPesel(string pesel)
        {
            return Patients.Where(model => model.Pesel.Equals(pesel)).FirstOrDefault();
        }
        public Patient GetPatient(int id)
        {
            return Patients.Where(model => model.PatientID == id).FirstOrDefault();
        }
        public ICollection<Patient> GetPatients()
        {
            return Patients.ToList();
        }

        
        //only for testing purposes, later won't be usefull
        public void DeleteSpecialization(int id)
        {
            var spec = Specializations.FirstOrDefault(model => model.SpecializationID == id);
            if (spec == null)
                return;
            this.Specializations.Remove(spec);
        }

    }
}
