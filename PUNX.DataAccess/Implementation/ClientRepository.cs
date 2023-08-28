using PUNX.DataAccess.Context;
using PUNX.Domain.Entities;
using PUNX.Domain.Repository;


namespace PUNX.DataAccess.Implementation
{
    public class ClientRepository :GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(PunxDbContext context) : base(context)
        {

        }
    }
}
