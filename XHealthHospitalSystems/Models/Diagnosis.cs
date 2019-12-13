using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XHealthHospitalSystems.Models
{
    public class Diagnosis
    {
        [Key]
        public int DiagnosisId { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Symtoms")]
        public string Symtoms { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Diagnosis")]
        public string Diagnosiss { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Meds Prescribed")]
        public string MedsPres { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required]
        [DisplayName("Tests Prescribed")]
        public string TestsPres { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
