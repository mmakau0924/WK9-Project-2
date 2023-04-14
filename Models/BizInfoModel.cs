using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab9_2.Models
{
    public class BizInfoModel
    {
        public int Id { get; set; }
        [AllowNull]
        public string BusinessName { get; set; }
        [AllowNull]
        public string Email { get; set; }
        [AllowNull]
        public string Phone { get; set; }
        [AllowNull]
        public string Address1 { get; set; }
        [AllowNull]
        public string Address2 { get; set; }




        [Range(0, 100)]
        [Required]
        public int YearsOperating { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime RegDate { get; set; }
        [StringLength(500)]
        [AllowNull]
        public string CoBranches { get; set; }
        [AllowNull]
        public string ContactPerson { get; set; }



        [AllowNull]
        public string CompanyName { get; set; }
        [Range(1, 10000)]
        public int TempStaff { get; set; }

        [Range(1, 15000)]
        public int permanentStaff { get; set; }
        [Range(1, 150)]
        public int ExecStaff { get; set; }




        [AllowNull]

        public string Comments { get; set; }
    }
}

