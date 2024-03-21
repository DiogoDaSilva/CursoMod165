using System.ComponentModel.DataAnnotations;

namespace CursoMod165.Models
{
    // EntityFramework -> Biblioteca de conexão à Base de Dados
    public class Customer
    {
        public int ID { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateOnly Birthday { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get;set; }

        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [StringLength(30), Range(0, 999999999999)]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Required]
        [Display(Name = "HealthCare User Number")]
        public string USNS { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Fiscal Number")]
        public string NIF { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
