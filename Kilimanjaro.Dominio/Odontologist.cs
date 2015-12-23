using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class Odontologist
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
