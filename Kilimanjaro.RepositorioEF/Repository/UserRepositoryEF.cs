using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using Kilimanjaro.Dominio.Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class UserRepositoryEF: IRepository<User>, ICustonUser<User>
    {
        private readonly Context context;

        public UserRepositoryEF()
        {
            context = new Context();
        }

        public void Save(User entity)
        {
            if (entity.Id > 0)
            {
                var userUpdate = context.Users.First(x => x.Id == entity.Id);
                userUpdate.Login = entity.Login;
                userUpdate.Name = entity.Name;
                userUpdate.Gender = entity.Gender;
                userUpdate.Birthdate = entity.Birthdate;
                userUpdate.Rg = entity.Rg;
                userUpdate.Cpf = entity.Cpf;
                userUpdate.PrimaryDdd = entity.PrimaryDdd;
                userUpdate.PrimaryFone = entity.PrimaryFone;
                userUpdate.SecondaryDdd = entity.SecondaryDdd;
                userUpdate.SecondaryFone = entity.SecondaryFone;
                userUpdate.Email = entity.Email;
                userUpdate.LastChangeDate = DateTime.Now;
                userUpdate.Password = entity.Password;
                userUpdate.ConfirmationPassword = entity.Password;
                userUpdate.UserType = context.UserTypes.ToList().Where(x => x.Id == 
                    entity.UserType.Id).FirstOrDefault();
            }
            else
            {
                entity.UserType = context.UserTypes.ToList().Where(x => x.Id == entity.UserType.Id).FirstOrDefault();
                entity.CreationDate = DateTime.Now;
                context.Users.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(User entity)
        {
            var userDelete = context.Users.First(x => x.Id == entity.Id);
            context.Set<User>().Remove(userDelete);
            context.SaveChanges();
        }

        public IEnumerable<User> ListAll()
        {
            return context.Users.ToList();
        }

        public User ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);

            var user = context.Users.First(x => x.Id == idInt);
            user.UserType = context.UserTypes.ToList().Where(x => x.Id == 
                user.UserType.Id).FirstOrDefault();

            return user;
        }

        public User GetByLogin(string login)
        {
            return context.Users.First(x => x.Login.ToLower() == login.ToLower());
        }

        public List<User> TypeListAll()
        {
            return context.Users.ToList();
        }
        
    }
}
