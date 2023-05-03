using System.ComponentModel.DataAnnotations;

namespace EMS.Business.Entities.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public Boolean IsActive { get; set; } = true;
    }
}
