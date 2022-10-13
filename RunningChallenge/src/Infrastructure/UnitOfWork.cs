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
        private readonly ApplicationDbContext _applicationDbContext;
        public IUserRepository UserRepository { get; private set; }
        public IActivityRepository ActivityRepository { get; private set; }
        public IMarathonRepository MarathonRepository { get; private set; }
        public IInvitationRepository InvitationRepository { get; private set; }
        public IMedalRepository MedalRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, 
                            IUserRepository userRepo, 
                            IActivityRepository activityRepo, 
                            IMarathonRepository marathonRepo, 
                            IInvitationRepository invitationRepository,
                            IMedalRepository medalRepo)
        {
            _applicationDbContext = applicationDbContext;
            UserRepository = userRepo;
            ActivityRepository = activityRepo;
            MarathonRepository = marathonRepo;
            InvitationRepository = invitationRepository;
            MedalRepository = medalRepo;
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public async Task Save()
        {
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
