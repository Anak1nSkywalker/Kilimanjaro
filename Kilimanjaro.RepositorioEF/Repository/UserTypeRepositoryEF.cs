using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class UserTypeRepositoryEF : IRepository<UserType>
    {
        private readonly Context context;

        public UserTypeRepositoryEF()
        {
            context = new Context();
        }

        public void Save(UserType entity)
        {
            if (entity.Id > 0)
            {
                var userTypeUpdate = context.UserTypes.First(x => x.Id == entity.Id);
                userTypeUpdate.Description = entity.Description;
            }
            else
            {
                context.UserTypes.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(UserType entity)
        {
            var userTypeDelete = context.UserTypes.First(x => x.Id == entity.Id);
            context.Set<UserType>().Remove(userTypeDelete);
            context.SaveChanges();
        }

        public IEnumerable<UserType> ListAll()
        {
            return context.UserTypes.ToList();
        }

        public UserType ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.UserTypes.First(x => x.Id == idInt);
        }

    }
}
