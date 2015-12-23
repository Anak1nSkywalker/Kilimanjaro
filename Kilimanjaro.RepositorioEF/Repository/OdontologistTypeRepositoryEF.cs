using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class OdontologistTypeRepositoryEF : IRepository<OdontologistType>
    {
        private readonly Context context;

        public OdontologistTypeRepositoryEF()
        {
            context = new Context();
        }

        public void Save(OdontologistType entity)
        {
            if (entity.Id > 0)
            {
                var odontologistTypeUpdate = context.OdontologistTypes.First(x => x.Id == entity.Id);
                odontologistTypeUpdate.Description = entity.Description;
            }
            else
            {
                context.OdontologistTypes.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(OdontologistType entity)
        {
            var odontologistTypeDelete = context.OdontologistTypes.First(x => x.Id == entity.Id);
            context.Set<OdontologistType>().Remove(odontologistTypeDelete);
            context.SaveChanges();
        }

        public IEnumerable<OdontologistType> ListAll()
        {
            return context.OdontologistTypes.ToList();
        }

        public OdontologistType ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.OdontologistTypes.First(x => x.Id == idInt);
        }
    }
}
