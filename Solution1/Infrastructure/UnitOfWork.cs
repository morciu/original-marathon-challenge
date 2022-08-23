using Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        public IUserRepository UserRepository { get; private set; }
        public IActivityRepository ActivityRepository { get; private set; }

        public UnitOfWork(DataContext dataContext, IUserRepository userRepo, IActivityRepository activityRepo)
        {
            _dataContext = dataContext;
            UserRepository = userRepo;
            ActivityRepository = activityRepo;
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
