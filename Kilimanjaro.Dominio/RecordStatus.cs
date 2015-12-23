using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class RecordStatus
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual IEnumerable<Record> Record { get; set; }
    }
}
