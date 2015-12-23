using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using Kilimanjaro.Dominio.Contract;
using Kilimanjaro.RepositoryEF;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationUser
    {
        private readonly IRepository<User> repository;
        private readonly ICustonUser<User> repositoryCuston;

        public ApplicationUser(UserRepositoryEF repository)
        {
            this.repository = repository;
            this.repositoryCuston = repository;
        }

        public void Save(User user)
        {
            repository.Save(user);
        }

        public void Delete(User user)
        {
            repository.Delete(user);
        }

        public IEnumerable<User> ListAll()
        {
            return repository.ListAll();
        }

        public User ListById(string id)
        {
            return repository.ListById(id);
        }

        public User GetByLogin(string login)
        {
            return repositoryCuston.GetByLogin(login);
        }

        public List<User> TypeListAll()
        {
            return repositoryCuston.TypeListAll();
        }
    
    }
}
