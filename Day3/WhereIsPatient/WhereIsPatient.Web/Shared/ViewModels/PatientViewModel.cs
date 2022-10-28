using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WhereIsPatient.Web.Shared.ViewModels
{
    public class PatientViewModel
    {
        [MaxLength(8)]
        public string UMRN { get; set; }

        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(2)]
        public string Gender { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
