using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class FederativeUnitRepositoryEF : IRepository<FederativeUnit>
    {
        private readonly Context context;

        public FederativeUnitRepositoryEF()
        {
            context = new Context();
        }

        public void Save(FederativeUnit entity)
        {
            if (entity.Id > 0)
            {
                var federativeUnitUpdate = context.FederativeUnits.First(x => x.Id == entity.Id);
                federativeUnitUpdate.Acronym = entity.Acronym;
                federativeUnitUpdate.Description = entity.Description;
            }
            else
            {
                context.FederativeUnits.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(FederativeUnit entity)
        {
            var federativeUnitDelete = context.FederativeUnits.First(x => x.Id == entity.Id);
            context.Set<FederativeUnit>().Remove(federativeUnitDelete);
            context.SaveChanges();
        }

        public IEnumerable<FederativeUnit> ListAll()
        {
            return context.FederativeUnits.ToList();
        }

        public FederativeUnit ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.FederativeUnits.First(x => x.Id == idInt);
        }
    }
}
