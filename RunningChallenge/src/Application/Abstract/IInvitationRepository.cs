﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IInvitationRepository
    {
        Task CreateInvitation(Invitation invitation);
        Task<List<Invitation>> CheckUnansweredInvitations(User receiver);
        Task<Invitation> GetInvtiation(int invitationId);
    }
}
