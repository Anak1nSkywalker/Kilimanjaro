using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string Backyard { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public User User { get; set; }

        public Patient Patient { get; set; }

        public BackyardType BackyardType { get; set; }

        public FederativeUnit FederativeUnit { get; set; }
    }
}
