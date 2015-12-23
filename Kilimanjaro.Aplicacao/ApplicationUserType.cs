using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using Kilimanjaro.RepositoryEF;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationUserType
    {
        private readonly IRepository<UserType> repository;
        
        public ApplicationUserType (UserTypeRepositoryEF repository)
        {
            this.repository = repository;
        }

        public void Save(UserType userType)
        {
            repository.Save(userType);
        }

        public void Delete(UserType userType)
        {
            repository.Delete(userType);
        }

        public IEnumerable<UserType> ListAll()
        {
            return repository.ListAll();
        }

        public UserType ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
