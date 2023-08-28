using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Sheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Length field is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "The Length must be greater than 0.")]
        public double Length { get; set; }

        [Required(ErrorMessage = "The Width field is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "The Width must be greater than 0.")]
        public double Width { get; set; }

        [Required(ErrorMessage = "The JobID field is required.")]
        [ForeignKey("Job")]
        public int JobID { get; set; }

        [Required(ErrorMessage = "The Circles field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Circles must be a non-negative integer.")]
        public int Circles { get; set; }

        [Required(ErrorMessage = "The Polylines field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Polylines must be a non-negative integer.")]
        public int Polylines { get; set; }

        // Navigation properties
        public Job Job { get; set; }
        public ICollection<Circle> CirclesList { get; set; }
        public ICollection<Line> LinesList { get; set; }
    }
}
