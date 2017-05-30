using Kilimanjaro.Application.Model;
using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using Kilimanjaro.RepositoryEF;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationCustomer
    {
        private readonly IRepository<Customer> repository;
        //private readonly CustomerRepositoryEF repository;

        public ApplicationCustomer(IRepository<Customer> repository)
        //public ApplicationCustomer(CustomerRepositoryEF repository)
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
            
            /*
            List<AccountTest> list = new List<AccountTest>
            {
                new AccountTest
                {
                    AccountNumber ="0001",
                    BankName ="Dummy Bank",
                    CustomerAddress = new AddressTest
                    {
                        Address1="address1",
                        Address2 ="address2",
                        Country ="US",
                        PostalCode ="20877",
                        State ="MD"
                    },
                    CustomerId ="Customer001",
                    CustomerName ="John Sherman"
                },
                new AccountTest{ AccountNumber="0002",
                    BankName ="Dummy Bank",
                    CustomerAddress = new AddressTest
                    {
                        Address1="address3",
                        Address2 ="address4",
                        Country ="US",
                        PostalCode ="20877",
                        State ="MD"
                    },
                    CustomerId ="Customer002",
                    CustomerName ="Marie Curie"
                }
            };
            IEnumerable<AccountTest> ienumerable = list as IEnumerable<AccountTest>;
            return ienumerable;
            */
        }

        public Customer ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
