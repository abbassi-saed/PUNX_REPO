using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUNX.Domain.Entities
{
    public class Line
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The XPosition field is required.")]
        public double XPosition { get; set; }

        [Required(ErrorMessage = "The YPosition field is required.")]
        public double YPosition { get; set; }

        [Range(-1.0, 1.0, ErrorMessage = "The Bulge must be between -1 and 1.")]
        public double Bulge { get; set; }

        [Required(ErrorMessage = "The SheetID field is required.")]
        [ForeignKey("Sheet")]
        public int SheetID { get; set; }

        // Navigation properties
        public Sheet Sheet { get; set; }
    }
}
