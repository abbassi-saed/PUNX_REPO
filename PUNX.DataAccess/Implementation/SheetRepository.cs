using Microsoft.EntityFrameworkCore;
using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PUNX.DataAccess.Implementation
{
    public class SheetRepository : GenericRepository<Sheet>, ISheetRepository
    {
        public SheetRepository(PunxDbContext context) : base(context)
        {

        }

        public async  Task<IEnumerable<Sheet>> GetSheetsByProjectAndJobId(int projectId, int jobId)
        {
            return await _context.Sheets
               .Include(sheet => sheet.Job)
               .ThenInclude(job => job.Project)
               .Where(sheet => sheet.Job.ProjectID == projectId && sheet.JobID == jobId)
               .ToListAsync();

        }

        public async Task<IEnumerable<Sheet>> GetSheetsBySheetIdAndProjectAndJobId(int projectId, int jobId, int sheetId)
        {
            return await _context.Sheets
               .Include(sheet => sheet.Job)
               .ThenInclude(job => job.Project)
               .Where(sheet => sheet.Job.ProjectID == projectId && sheet.JobID == jobId && sheet.Id == sheetId)
               .ToListAsync();
        }
    }
}
