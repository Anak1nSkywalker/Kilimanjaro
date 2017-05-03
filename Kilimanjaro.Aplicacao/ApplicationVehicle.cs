using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System.Collections.Generic;

namespace Kilimanjaro.Application
{
    public class ApplicationVehicle
    {
        private readonly IRepository<Vehicle> repository;

        public ApplicationVehicle(IRepository<Vehicle> repository)
        {
            this.repository = repository;
        }

        public void Save(Vehicle vehicle)
        {
            repository.Save(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            repository.Delete(vehicle);
        }

        public IEnumerable<Vehicle> ListAll()
        {
            return repository.ListAll();
        }

        public Vehicle ListById(string id)
        {
            return repository.ListById(id);
        }
    }
}
