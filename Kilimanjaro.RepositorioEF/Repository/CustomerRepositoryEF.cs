using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class CustomerRepositoryEF : IRepository<Customer>
    //public class CustomerRepositoryEF
    {
        //private readonly Context context;
        public Context context;

        public CustomerRepositoryEF()
        {
            context = new Context();
        }

        public void Save(Customer entity)
        {
            if (entity.Id > 0)
            {
                var customerUpdate = context.Customers.First(x => x.Id == entity.Id);
                customerUpdate.Name = entity.Name;
                customerUpdate.Birthdate = entity.Birthdate;
                customerUpdate.Cpf = entity.Cpf;
                customerUpdate.Ddd = entity.Ddd;
                customerUpdate.Fone = entity.Fone;
                customerUpdate.Email = entity.Email;
                customerUpdate.Password = entity.Password;
                customerUpdate.LastChangeDate = DateTime.Now;
            }
            else
            {
                entity.CreationDate = DateTime.Now;
                context.Customers.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            var customerDelete = context.Customers.First(x => x.Id == entity.Id);
            context.Set<Customer>().Remove(customerDelete);
            context.SaveChanges();
        }

        public IEnumerable<Customer> ListAll()
        {
            return context.Customers.ToList();
        }

        public Customer ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.Customers.First(x => x.Id == idInt);
        }
    }
}
