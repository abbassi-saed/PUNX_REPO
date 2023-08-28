using Microsoft.EntityFrameworkCore;
using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace PUNX.DataAccess.Implementation
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        public JobRepository(PunxDbContext context) : base(context)
        {

        }

        public IEnumerable<Job> GetJobsByProjectId(int id)
        {
            return _context.Jobs.Include(job => job.Project).Where(job => job.ProjectID == id).ToList();

        }
    }
}
