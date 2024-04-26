using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WhereIsPatient.DB.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [MaxLength(8)]
        public string UMRN { get; set; }

        [Required]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(80)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(2)]
        public string Gender { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
