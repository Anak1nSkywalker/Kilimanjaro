using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class RecordRepositoryEF : IRepository<Record>
    {
        private readonly Context context;

        public RecordRepositoryEF()
        {
            context = new Context();
        }

        public void Save(Record entity)
        {
            if (entity.Id > 0)
            {
                var recordUpdate = context.Records.First(x => x.Id == entity.Id);
                recordUpdate.LastChangeDate = DateTime.Now;
                recordUpdate.TreatmentDate = entity.TreatmentDate;
                recordUpdate.Description = entity.Description;
                recordUpdate.Observation = entity.Observation;
            }
            else
            {
                context.Records.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(Record entity)
        {
            var recordDelete = context.Records.First(x => x.Id == entity.Id);
            context.Set<Record>().Remove(recordDelete);
            context.SaveChanges();
        }

        public IEnumerable<Record> ListAll()
        {
            return context.Records.ToList();
        }

        public Record ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.Records.First(x => x.Id == idInt);
        }
    }
}
