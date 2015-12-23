using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationOdontologist
    {
        private readonly IRepository<Odontologist> repository;

        public ApplicationOdontologist(IRepository<Odontologist> repository)
        {
            this.repository = repository;
        }

        public void Save(Odontologist odontologist)
        {
            repository.Save(odontologist);
        }

        public void Delete(Odontologist odontologist)
        {
            repository.Delete(odontologist);
        }

        public IEnumerable<Odontologist> ListAll()
        {
            return repository.ListAll();
        }

        public Odontologist ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
