using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "MaterialID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "MaterialID must be greater than 0.")]
        public int MaterialID { get; set; }

        [Required(ErrorMessage = "ProjectID is required.")]
        [ForeignKey("Project")]
        public int ProjectID { get; set; }

        // Navigation properties
        public Project Project { get; set; }
        public ICollection<Sheet> Sheets { get; set; }
    }
}
