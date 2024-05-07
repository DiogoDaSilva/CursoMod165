using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoMod165.Models
{
    public class Staff
    {
        public int ID { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(9)]
        [Range(0, 999999999)]
        [Required]
        public string EmployeeNumber{ get; set; }

        [StringLength(255)]
        [Required]
        public string Address { get;set; }

        [StringLength(30)]
        [Required]
        public string NIF { get; set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber {  get; set; }
        
        
        [DataType(DataType.Date)]
        [Required]
        public DateOnly Birthday { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        // [Column(TypeName = "decimal(18, 2)")]
        [Precision(18, 2)]
        public decimal Salary { get; set; }


        // Médico
        // Enfermeiro
        // Administrativo

        [ValidateNever] // Ver ViewModels
        [ForeignKey("StaffRoleID")]
        public StaffRole StaffRole { get; set; }

        [Display(Name = "Role")]
        [Required]
        public int StaffRoleID { get; set;}

        [Display(Name = "Specialty")]
        public Specialty? Specialty { get; set; }

        //public string UserID { get; set; }

        //[ForeignKey("UserID")]
        //public CursoMod165User User { get; set; }

    }

    //public class CursoMod165User : IdentityUser
    //{
    //    public decimal Salary;
    //    public string EmployeeNumber;
    //}
}
