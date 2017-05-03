using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationCustomer
    {
        private readonly IRepository<Customer> repository;

        public ApplicationCustomer(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        public void Save(Customer customer)
        {
            repository.Save(customer);
        }

        public void Delete(Customer customer)
        {
            repository.Delete(customer);
        }

        public IEnumerable<Customer> ListAll()
        {
            return repository.ListAll();
        }

        public Customer ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
