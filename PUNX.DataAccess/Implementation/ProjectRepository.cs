using Microsoft.EntityFrameworkCore;
using PUNX.DataAccess.Context;
using PUNX.Domain.DTOs;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUNX.DataAccess.Implementation
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(PunxDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<ProjectByUserTypeDto>> GetProjectCountByUserType()
        {
            var userTypes = await _context.Users.Select(u => u.Type).Distinct().ToListAsync();

            var projectCountsByUserType = new List<ProjectByUserTypeDto>();

            foreach (var userType in userTypes)
            {
                var projectCount = await _context.Projects
                    .CountAsync(p => p.User != null && p.User.Type == userType);

                projectCountsByUserType.Add(new ProjectByUserTypeDto
                {
                    UserType = userType,
                    CountOfProjects = projectCount
                });
            }

            return projectCountsByUserType;
        }

    }
}
