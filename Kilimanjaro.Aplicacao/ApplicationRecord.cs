using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationRecord
    {
        private readonly IRepository<Record> repository;

        public ApplicationRecord(IRepository<Record> repository)
        {
            this.repository = repository;
        }

        public void Save(Record record)
        {
            repository.Save(record);
        }

        public void Delete(Record record)
        {
            repository.Delete(record);
        }

        public IEnumerable<Record> ListAll()
        {
            return repository.ListAll();
        }

        public Record ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
