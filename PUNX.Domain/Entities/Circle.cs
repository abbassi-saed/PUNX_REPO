using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Circle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The XPosition field is required.")]
        public double XPosition { get; set; }

        [Required(ErrorMessage = "The YPosition field is required.")]
        public double YPosition { get; set; }

        [Required(ErrorMessage = "The Radius field is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "The Radius must be greater than 0.")]
        public double Radius { get; set; }

        [Required(ErrorMessage = "The SheetID field is required.")]
        [ForeignKey("Sheet")]
        public int SheetID { get; set; }

        // Navigation properties
        public Sheet Sheet { get; set; }
    }
}
