using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;


namespace PUNX.DataAccess.Implementation
{
    public class CircleRepository : GenericRepository<Circle>, ICircleRepository
    {
        public CircleRepository(PunxDbContext context) : base(context)
        {

        }
    }
}
