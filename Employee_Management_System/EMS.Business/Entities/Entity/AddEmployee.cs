using System.ComponentModel.DataAnnotations;

namespace EMS.Business.Entities.Entity
{
    public class AddEmployee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoinedDate { get; set; }

        public Boolean IsActive { get; set; } = true;

        // Foreign key
        public int DepartmentId { get; set; }
    }
}
