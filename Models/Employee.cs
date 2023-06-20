using System.ComponentModel.DataAnnotations;

namespace Practical_11.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "Date of Birth")]
        public DateTime Dob { get; set; }
    }
}
