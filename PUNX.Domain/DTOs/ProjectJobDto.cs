
namespace PUNX.Domain.DTOs
{
    public class ProjectJobDto
    {
        public int Id { get; set; }
        public int MaterialID { get; set; }

        // Navigation properties
        public ProjectDto Project { get; set; }
    }
}
