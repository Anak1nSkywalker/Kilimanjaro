using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationBackyardType
    {
        private readonly IRepository<BackyardType> repository;

        public ApplicationBackyardType(IRepository<BackyardType> repository)
        {
            this.repository = repository;
        }

        public void Save(BackyardType backyardType)
        {
            repository.Save(backyardType);
        }

        public void Delete(BackyardType backyardType)
        {
            repository.Delete(backyardType);
        }

        public IEnumerable<BackyardType> ListAll()
        {
            return repository.ListAll();
        }

        public BackyardType ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
