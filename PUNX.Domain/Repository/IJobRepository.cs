using PUNX.Domain.Entities;
using System.Collections.Generic;

namespace PUNX.Domain.Repository
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        IEnumerable<Job> GetJobsByProjectId(int id);
    }
}
