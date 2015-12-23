using System;
using System.ComponentModel.DataAnnotations;

namespace Kilimanjaro.Domain
{
    public class Record
    {
        [Key]
        public int Id { get; set; }

        public DateTime CriationDate { get; set; }

        public DateTime LastChangeDate { get; set; }

        public DateTime TreatmentDate { get; set; }

        public string Description { get; set; }

        public string Observation { get; set; }

        public Patient Patient { get; set; }

        public User AttendantUser { get; set; }

        public User OdontologistUser { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}
