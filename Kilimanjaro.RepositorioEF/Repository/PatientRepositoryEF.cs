using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class PatientyRepositoryEF : IRepository<Patient>
    {
        private readonly Context context;

        public PatientyRepositoryEF()
        {
            context = new Context();
        }

        public void Save(Patient entity)
        {
            if (entity.Id > 0)
            {
                var patientUpdate = context.Patients.First(x => x.Id == entity.Id);
                patientUpdate.Name = entity.Name;
                patientUpdate.Gender = entity.Gender;
                patientUpdate.Birthdate = entity.Birthdate;
                patientUpdate.Rg = entity.Rg;
                patientUpdate.Cpf = entity.Cpf;
                patientUpdate.MotherName = entity.MotherName;
                patientUpdate.PrimaryDdd = entity.PrimaryDdd;
                patientUpdate.PrimaryFone = entity.PrimaryFone;
                patientUpdate.SecundaryDdd = entity.SecundaryDdd;
                patientUpdate.SecundaryFone = entity.SecundaryFone;
                patientUpdate.Email = entity.Email;
                patientUpdate.LastChangeDate = DateTime.Now;
            }
            else
            {
                context.Patients.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(Patient entity)
        {
            var patientDelete = context.Patients.First(x => x.Id == entity.Id);
            context.Set<Patient>().Remove(patientDelete);
            context.SaveChanges();
        }

        public IEnumerable<Patient> ListAll()
        {
            return context.Patients.ToList();
        }

        public Patient ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.Patients.First(x => x.Id == idInt);
        }
    }
}
