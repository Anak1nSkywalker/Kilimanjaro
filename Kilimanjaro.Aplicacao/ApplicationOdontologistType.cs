using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationOdontologistType
    {
        private readonly IRepository<OdontologistType> repository;

        public ApplicationOdontologistType(IRepository<OdontologistType> repository)
        {
            this.repository = repository;
        }

        public void Save(OdontologistType odontologistType)
        {
            repository.Save(odontologistType);
        }

        public void Delete(OdontologistType odontologistType)
        {
            repository.Delete(odontologistType);
        }

        public IEnumerable<OdontologistType> ListAll()
        {
            return repository.ListAll();
        }

        public OdontologistType ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
