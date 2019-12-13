using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthHospitalSystems.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

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

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        [DisplayName("Emergency Contact")]
        public string EmgrCont { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Required]
        [DisplayName("Blood Type")]
        public string BloodType { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        [DisplayName("NIC")]
        public string NIC { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required]
        [DisplayName("Telephone No")]
        public string TelNo { get; set; }

    }
}
