using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationRecordStatus
    {
        private readonly IRepository<RecordStatus> repository;

        public ApplicationRecordStatus(IRepository<RecordStatus> repository)
        {
            this.repository = repository;
        }

        public void Save(RecordStatus recordStatus)
        {
            repository.Save(recordStatus);
        }

        public void Delete(RecordStatus recordStatus)
        {
            repository.Delete(recordStatus);
        }

        public IEnumerable<RecordStatus> ListAll()
        {
            return repository.ListAll();
        }

        public RecordStatus ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
