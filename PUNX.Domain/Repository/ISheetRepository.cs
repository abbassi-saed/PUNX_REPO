using PUNX.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PUNX.Domain.Repository
{
    public interface ISheetRepository : IGenericRepository<Sheet>
    {
        Task<IEnumerable<Sheet>> GetSheetsByProjectAndJobId(int projectId, int jobId);
        Task<IEnumerable<Sheet>> GetSheetsBySheetIdAndProjectAndJobId(int projectId, int jobId, int sheetId);

    }
}
