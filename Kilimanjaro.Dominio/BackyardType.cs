using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class BackyardType
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Address> Address { get; set; }
    }
}
