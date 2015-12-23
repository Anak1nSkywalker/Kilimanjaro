using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class AddressRepositoryEF : IRepository<Address>
    {
        private readonly Context context;

        public AddressRepositoryEF()
        {
            context = new Context();
        }

        public void Save(Address entity)
        {
            if (entity.Id > 0)
            {
                var addressUpdater = context.Addresss.First(x => x.Id == entity.Id);
                addressUpdater.Backyard = entity.Backyard;
                addressUpdater.Number = entity.Number;
                addressUpdater.Complement = entity.Complement;
                addressUpdater.Neighborhood = entity.Neighborhood;
                addressUpdater.City = entity.City;
                addressUpdater.ZipCode = entity.ZipCode;
            }
            else
            {
                context.Addresss.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(Address entity)
        {
            var addressDelete = context.Addresss.First(x => x.Id == entity.Id);
            context.Set<Address>().Remove(addressDelete);
            context.SaveChanges();
        }

        public IEnumerable<Address> ListAll()
        {
            return context.Addresss.ToList();
        }

        public Address ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.Addresss.First(x => x.Id == idInt);
        }
    }
}
