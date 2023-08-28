using System;

namespace PUNX.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICircleRepository Circle { get; }
        IClientRepository Client { get; }
        IJobRepository Job { get; }
        ILineRepository Line { get; }
        IProjectRepository Project { get; }
        ISheetRepository Sheet { get; }
        IUserRepository User { get; }
        int Save();
    }
}
