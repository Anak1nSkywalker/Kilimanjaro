using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationAddress
    {

        private readonly IRepository<Address> repository;

        public ApplicationAddress(IRepository<Address> repository)
        {
            this.repository = repository;
        }

        public void Save(Address address)
        {
            repository.Save(address);
        }

        public void Delete(Address address)
        {
            repository.Delete(address);
        }

        public IEnumerable<Address> ListAll()
        {
            return repository.ListAll();
        }

        public Address ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
