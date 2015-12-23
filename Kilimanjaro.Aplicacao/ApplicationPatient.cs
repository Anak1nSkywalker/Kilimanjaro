using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationPatient
    {
        private readonly IRepository<Patient> repository;

        public ApplicationPatient(IRepository<Patient> repository)
        {
            this.repository = repository;
        }

        public void Save(Patient patient)
        {
            repository.Save(patient);
        }

        public void Delete(Patient patient)
        {
            repository.Delete(patient);
        }

        public IEnumerable<Patient> ListAll()
        {
            return repository.ListAll();
        }

        public Patient ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
