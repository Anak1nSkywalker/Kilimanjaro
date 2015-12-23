using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class OdontologistType
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
