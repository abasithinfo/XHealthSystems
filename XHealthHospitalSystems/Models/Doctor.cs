using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthHospitalSystems.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("Registration No")]
        public string RegNo { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Qualifications")]
        public string Qualification { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        [DisplayName("Visiting Dates")]
        public string VDate { get; set; }

        [Column(TypeName = "varchar(1000)")]
        [Required]
        [DisplayName("Notes")]
        public string Note { get; set; }

    }
}
