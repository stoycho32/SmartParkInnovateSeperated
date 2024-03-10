using SmartParkInnovate.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartParkInnovate.Infrastructure.Data.Models
{
    public class Department
    {
        public Department()
        {
            this.Workers = new List<Worker>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(DataConstants.DepartmentNameMaxLength,
            MinimumLength = DataConstants.DepartmentNameMinLength,
            ErrorMessage = ErrorMessages.DepartmentNameLengthErrorMessage)]
        public string Name { get; set; } = null!;


        [InverseProperty(nameof(Department))]
        public ICollection<Worker> Workers { get; set; }
    }
}
