using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field must be at most 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The FileName field is required.")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "The FilePath field is required.")]
        public string FilePath { get; set; }

        [Required(ErrorMessage = "The UserId field is required.")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "The ClientId field is required.")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Client Client { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
