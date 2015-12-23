using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class RecordStatusRepositoryEF : IRepository<RecordStatus>
    {
        private readonly Context context;

        public RecordStatusRepositoryEF()
        {
            context = new Context();
        }

        public void Save(RecordStatus entity)
        {
            if (entity.Id > 0)
            {
                var recordStatusUpdate = context.RecordStatuss.First(x => x.Id == entity.Id);
                recordStatusUpdate.Description = entity.Description;
            }
            else
            {
                context.RecordStatuss.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(RecordStatus entity)
        {
            var recordStatusDelete = context.RecordStatuss.First(x => x.Id == entity.Id);
            context.Set<RecordStatus>().Remove(recordStatusDelete);
            context.SaveChanges();
        }

        public IEnumerable<RecordStatus> ListAll()
        {
            return context.RecordStatuss.ToList();
        }

        public RecordStatus ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.RecordStatuss.First(x => x.Id == idInt);
        }
    }
}
