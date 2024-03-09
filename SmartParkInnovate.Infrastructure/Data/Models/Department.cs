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
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Department name must be between 3 and 100 characters long.")]
        public string Name { get; set; } = null!;


        [InverseProperty(nameof(Department))]
        public ICollection<Worker> Workers { get; set; }
    }
}
