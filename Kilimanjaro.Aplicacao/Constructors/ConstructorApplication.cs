using Kilimanjaro.RepositoryEF;
using Kilimanjaro.RepositoryEF.Repository;
using Kilimanjaro.Domain;
using Kilimanjaro.Domain.Contract;

namespace Kilimanjaro.Application
{
    public class ConstructorApplication
    {
        public static ApplicationAddress ApplicationAddressEF()
        {
            return new ApplicationAddress(new AddressRepositoryEF());
        }

        public static ApplicationBackyardType ApplicationBackyardTypeEF()
        {
            return new ApplicationBackyardType(new BackyardTypeRepositoryEF());
        }

        public static ApplicationFederativeUnit ApplicationFederativeUnitEF()
        {
            return new ApplicationFederativeUnit(new FederativeUnitRepositoryEF());
        }

        public static ApplicationOdontologist ApplicationOdontologistEF()
        {
            //return new ApplicationOdontologist(new OdontologistRepositoryEF());
            return null;
        }

        public static ApplicationOdontologistType ApplicationOdontologistTypeEF()
        {
            return new ApplicationOdontologistType(new OdontologistTypeRepositoryEF());
        }

        public static ApplicationPatient ApplicationPatientEF()
        {
            return new ApplicationPatient(new PatientyRepositoryEF());
        }

        public static ApplicationRecord ApplicationRecordEF()
        {
            return new ApplicationRecord(new RecordRepositoryEF());
        }

        public static ApplicationRecordStatus ApplicationRecordStatusEF()
        {
            return new ApplicationRecordStatus(new RecordStatusRepositoryEF());
        }

        public static ApplicationUser ApplicationUserEF()
        {
            return new ApplicationUser(new UserRepositoryEF());
        }

        public static ApplicationUserType ApplicationUserTypeEF()
        {
            return new ApplicationUserType(new UserTypeRepositoryEF());
        }
        
        public static ApplicationCustomer ApplicationCustomerEF()
        {
            return new ApplicationCustomer(new CustomerRepositoryEF());           
        }

        public static string ApplicationCustomerEFNew()
        {
            return "OBA OBA RATINHO";
        }

        public static ApplicationVehicle ApplicationVehicleEF()
        {
            return new ApplicationVehicle(new VehicleRepositoryEF());
        }
    }
}
