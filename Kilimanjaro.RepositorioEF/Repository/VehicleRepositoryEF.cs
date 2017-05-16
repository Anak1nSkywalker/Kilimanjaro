using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Kilimanjaro.RepositoryEF
{
    public class VehicleRepositoryEF : IRepository<Vehicle>
    {
        private readonly Context context;

        public VehicleRepositoryEF()
        {
            context = new Context();
        }

        public void Save(Vehicle entity)
        {
            if (entity.Id > 0)
            {
                var vehicleUpdate = context.Vehicles.First(x => x.Id == entity.Id);
                vehicleUpdate.Identification = entity.Identification;
                vehicleUpdate.Chassis = entity.Chassis;
                vehicleUpdate.Year = entity.Year;
                vehicleUpdate.Weight = decimal.Parse(entity.Weight.ToString(), CultureInfo.GetCultureInfo("pt -BR"));
                vehicleUpdate.Height = entity.Height;
                vehicleUpdate.Width = entity.Width;
                vehicleUpdate.Length = entity.Length;
                vehicleUpdate.UsefulAreaHeight = entity.UsefulAreaHeight;
                vehicleUpdate.UsefulAreaWidth = entity.UsefulAreaWidth;
                vehicleUpdate.UsefulAreaLength = entity.UsefulAreaLength;
                vehicleUpdate.LastChangeDate = DateTime.Now;
            }
            else
            {
                entity.CreationDate = DateTime.Now;
                context.Vehicles.Add(entity);
            }

            context.SaveChanges();
        }

        public void Delete(Vehicle entity)
        {
            var vehicleDelete = context.Vehicles.First(x => x.Id == entity.Id);
            context.Set<Vehicle>().Remove(vehicleDelete);
            context.SaveChanges();
        }

        public IEnumerable<Vehicle> ListAll()
        {
            return context.Vehicles.ToList();
        }

        public Vehicle ListById(string id)
        {
            int idInt;
            Int32.TryParse(id, out idInt);
            return context.Vehicles.First(x => x.Id == idInt);
        }
    }
}
