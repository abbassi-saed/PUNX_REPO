using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;

namespace PUNX.DataAccess.Implementation
{
    public class LineRepository : GenericRepository<Line>, ILineRepository
    {
        public LineRepository(PunxDbContext context) : base(context)
        {

        }
    }
}
