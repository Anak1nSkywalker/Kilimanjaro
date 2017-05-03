using Kilimanjaro.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.IO;
using System.Text;
//using System.Data.Entity.Validation.DbEntityValidationResult;

namespace Kilimanjaro.RepositoryEF
{
    public class Context : DbContext
    {
        public Context()
            : base("KilimanjaroDB")
        {

        }

        public DbSet<Address> Addresss { get; set; }
        public DbSet<BackyardType> BackyardTypes { get; set; }
        public DbSet<FederativeUnit> FederativeUnits { get; set; }
        public DbSet<Odontologist> Odontologists { get; set; }
        public DbSet<OdontologistType> OdontologistTypes { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<RecordStatus> RecordStatuss { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder builder = new StringBuilder();

                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        builder.AppendLine(string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage));
                    }
                }

                System.IO.File.WriteAllText(@"C:\log\logError.txt", builder.ToString());

                throw;
            }
        }

        /*

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw;  // You can also choose to handle the exception here...
            }
        }

        /*
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
         */

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Address
            modelBuilder.Entity<Address>().Property(address => address.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Address>().Property(address => address.Backyard).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(address => address.Number).IsRequired().HasColumnType("varchar").HasMaxLength(5);
            modelBuilder.Entity<Address>().Property(address => address.Complement).IsRequired().HasColumnType("varchar").HasMaxLength(8);
            modelBuilder.Entity<Address>().Property(address => address.Neighborhood).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(address => address.City).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Address>().Property(address => address.ZipCode).IsRequired().HasColumnType("int");

            //BackyardType
            modelBuilder.Entity<BackyardType>().Property(backyardType => backyardType.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<BackyardType>().Property(backyardType => backyardType.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //FederativeUnit
            modelBuilder.Entity<FederativeUnit>().Property(federativeUnit => federativeUnit.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<FederativeUnit>().Property(federativeUnit => federativeUnit.Acronym).IsRequired().HasColumnType("char").HasMaxLength(2);
            modelBuilder.Entity<FederativeUnit>().Property(federativeUnit => federativeUnit.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //Odontologist
            modelBuilder.Entity<Odontologist>().Property(odontologist => odontologist.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Odontologist>().Property(odontologist => odontologist.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //TipoOdontologist
            modelBuilder.Entity<OdontologistType>().Property(odontologistType => odontologistType.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<OdontologistType>().Property(odontologistType => odontologistType.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //Patient
            modelBuilder.Entity<Patient>().Property(patient => patient.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.Name).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Patient>().Property(patient => patient.Gender).IsRequired().HasColumnType("char").HasMaxLength(1);
            modelBuilder.Entity<Patient>().Property(patient => patient.Birthdate).IsRequired().HasColumnType("date");
            modelBuilder.Entity<Patient>().Property(patient => patient.Rg).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<Patient>().Property(patient => patient.Cpf).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.MotherName).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Patient>().Property(patient => patient.PrimaryDdd).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.PrimaryFone).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.SecundaryDdd).HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.SecundaryFone).HasColumnType("int");
            modelBuilder.Entity<Patient>().Property(patient => patient.Email).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            modelBuilder.Entity<Patient>().Property(patient => patient.CreationDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Patient>().Property(patient => patient.LastChangeDate).HasColumnType("datetime");

            //Record
            modelBuilder.Entity<Record>().Property(record => record.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Record>().Property(record => record.CriationDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Record>().Property(record => record.LastChangeDate).HasColumnType("datetime");
            modelBuilder.Entity<Record>().Property(record => record.TreatmentDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Record>().Property(record => record.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            modelBuilder.Entity<Record>().Property(record => record.Observation).IsRequired().HasColumnType("varchar").HasMaxLength(255);

            //RecordStatus
            modelBuilder.Entity<RecordStatus>().Property(recordStatus => recordStatus.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<RecordStatus>().Property(recordStatus => recordStatus.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //User
            modelBuilder.Entity<User>().Property(user => user.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.Login).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<User>().Property(user => user.Gender).IsRequired().HasColumnType("char").HasMaxLength(1);
            modelBuilder.Entity<User>().Property(user => user.Birthdate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<User>().Property(user => user.Rg).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<User>().Property(user => user.Cpf).IsRequired().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.PrimaryDdd).IsRequired().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.PrimaryFone).IsRequired().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.SecondaryDdd).IsOptional().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.SecondaryFone).IsOptional().HasColumnType("int");
            modelBuilder.Entity<User>().Property(user => user.Email).IsOptional().HasColumnType("varchar").HasMaxLength(40);
            modelBuilder.Entity<User>().Property(user => user.CreationDate).IsOptional().HasColumnType("datetime");
            modelBuilder.Entity<User>().Property(user => user.LastChangeDate).IsOptional().HasColumnType("datetime");
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired().HasColumnType("varchar").HasMaxLength(15);

            //UserType
            modelBuilder.Entity<UserType>().Property(userType => userType.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<UserType>().Property(userType => userType.Description).IsRequired().HasColumnType("varchar").HasMaxLength(30);

            //Customer
            modelBuilder.Entity<Customer>().Property(customer => customer.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Customer>().Property(customer => customer.Name).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Customer>().Property(customer => customer.Birthdate).IsRequired().HasColumnType("date");
            modelBuilder.Entity<Customer>().Property(customer => customer.Cpf).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Customer>().Property(customer => customer.Ddd).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Customer>().Property(customer => customer.Fone).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Customer>().Property(customer => customer.Email).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(customer => customer.Password).IsRequired().HasColumnType("varchar").HasMaxLength(255);
            modelBuilder.Entity<Customer>().Property(customer => customer.CreationDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Customer>().Property(customer => customer.LastChangeDate).HasColumnType("datetime");
            modelBuilder.Entity<Customer>().Property(customer => customer.Status).IsRequired().HasColumnType("bit");
            modelBuilder.Entity<Customer>().Property(customer => customer.ServiceProvider).IsRequired().HasColumnType("bit");

            //Vehicle
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Id).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Identification).IsRequired().HasColumnType("varchar").HasMaxLength(7);
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Chassis).IsRequired().HasColumnType("varchar").HasMaxLength(17);
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Year).IsRequired().HasColumnType("int");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Weight).IsRequired().HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Height).IsRequired().HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Width).IsRequired().HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Length).IsRequired().HasColumnType("float");            
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.UsefulAreaHeight).HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.UsefulAreaWidth).HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.UsefulAreaLength).HasColumnType("float");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.CreationDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.LastChangeDate).HasColumnType("datetime");
            modelBuilder.Entity<Vehicle>().Property(vehicle => vehicle.Status).IsRequired().HasColumnType("bit");

        }
         
    }
}
