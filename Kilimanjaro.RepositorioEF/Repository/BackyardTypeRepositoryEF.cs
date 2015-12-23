using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using Kilimanjaro.RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF.Repository
{
    public class BackyardTypeRepositoryEF : IRepository<BackyardType>
    {
        private readonly Context context;

        public BackyardTypeRepositoryEF()
        {
            context = new Context();
        }

        public void Save(BackyardType entity)
        {
            if (entity.Id > 0)
            {
                var backyardTypeUpdate = context.BackyardTypes.First(x => x.Id == entity.Id);
                backyardTypeUpdate.Description = entity.Description;
            }
            else
            {
                context.BackyardTypes.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(BackyardType entity)
        {
            var backyardTypeDelete = context.BackyardTypes.First(x => x.Id == entity.Id);
            context.Set<BackyardType>().Remove(backyardTypeDelete);
            context.SaveChanges();
        }

        public IEnumerable<BackyardType> ListAll()
        {
            return context.BackyardTypes.ToList();
        }

        public BackyardType ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.BackyardTypes.First(x => x.Id == idInt);
        }
    }
}