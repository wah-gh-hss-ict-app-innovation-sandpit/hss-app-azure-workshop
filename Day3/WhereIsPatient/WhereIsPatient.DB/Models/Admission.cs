using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereIsPatient.DB.Models
{
    public class Admission
    {
        [Key]
        [Required]
        [MaxLength(12)]
        public String VisitNumber { get;set;}

        [Required]
        public DateTime AppointmentDate { get; set;}

        [Required]
        public DateTime AdmissionDate { get; set;}

        [Required]
        public DateTime DischargeDate { get; set;}

        [Required]
        [MaxLength(80)]
        public string HospitalName { get;set;}

        [Required]
        [MaxLength(300)]
        public string HospitalAddress { get; set;}

        [Required]
        [MaxLength(5)]
        public string CurrentWard { get; set;}

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now!;

        [Required]
        public DateTime UpdatedDate { get; set; } = DateTime.Now!;
    }
}
