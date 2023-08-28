using PUNX.DataAccess.Context;
using PUNX.Domain.Repository;
using System;

namespace PUNX.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PunxDbContext _context;

        public UnitOfWork(PunxDbContext context)
        {
            _context = context;
            Circle = new CircleRepository(_context);
            Client = new ClientRepository(_context);
            Job = new JobRepository(_context);
            Line = new LineRepository(_context);
            Project = new ProjectRepository(_context);
            Sheet = new SheetRepository(_context);
            User = new UserRepository(_context);
        }

        public ICircleRepository Circle { get; private set; }
        public IClientRepository Client { get; private set; }
        public IJobRepository Job { get; private set; }
        public ILineRepository Line { get; private set; }
        public IProjectRepository Project { get; private set; }
        public ISheetRepository Sheet { get; private set; }
        public IUserRepository User { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

            #if DEBUG
                        GC.SuppressFinalize(this);
            #endif
        }
    }
}
