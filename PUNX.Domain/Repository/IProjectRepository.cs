using PUNX.Domain.DTOs;
using PUNX.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUNX.Domain.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<IEnumerable<ProjectByUserTypeDto>> GetProjectCountByUserType();
    }
}
