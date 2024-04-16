using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CursoMod165.Models
{
    public class StaffRole
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool CanDoAppointments { get; set; }
    }
}
