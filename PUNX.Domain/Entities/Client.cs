using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Phone field is required.")]
        [RegularExpression(@"^\+?[0-9]*$", ErrorMessage = "Invalid phone number.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Address field is required.")]
        public string Address { get; set; }

        // Navigation properties
        public ICollection<Project> Projects { get; set; }
    }
}
