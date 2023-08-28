

namespace PUNX.Domain.DTOs
{
    public class JobSheetDto
    {
        public int Id { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public int Circles { get; set; }
        public ProjectJobDto Job { get; set; }
    }
}
