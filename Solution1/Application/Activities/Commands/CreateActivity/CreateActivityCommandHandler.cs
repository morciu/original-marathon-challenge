using Application.Abstract;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands.CreateActivity
{
    internal class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Activity>
    {
        IActivityRepository _repo;
        public CreateActivityCommandHandler(IActivityRepository repo)
        {
            _repo = repo;
        }

        public Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        /*
       public Task<Activity> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
       {
           // Create new activity instance
           *//*Activity activity = new Activity(request.RunnerId, request.Distance, request.Date, request.Duration);*//*
           // Store activity info locally
           _repo.CreateActivity(request.RunnerId.ToString(), request.Distance.ToString(), request.Date.ToString(), request.Duration.ToString());

           return Task.FromResult(activity);
       }*/
    }
}
