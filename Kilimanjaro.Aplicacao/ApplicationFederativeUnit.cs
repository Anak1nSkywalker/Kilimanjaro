using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationFederativeUnit
    {
        private readonly IRepository<FederativeUnit> repository;

        public ApplicationFederativeUnit(IRepository<FederativeUnit> repository)
        {
            this.repository = repository;
        }

        public void Save(FederativeUnit federativeUnit)
        {
            repository.Save(federativeUnit);
        }

        public void Delete(FederativeUnit federativeUnit)
        {
            repository.Delete(federativeUnit);
        }

        public IEnumerable<FederativeUnit> ListAll()
        {
            return repository.ListAll();
        }

        public FederativeUnit ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
