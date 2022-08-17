using Application;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    internal class SingletonMediator
    {
        private static SingletonMediator _instance;
        IMediator mediator;
        private SingletonMediator()
        {
            var diContainer = new ServiceCollection()
                .AddScoped<IUserRepository, InMemoryUserRepository>()
                .AddScoped<IActivityRepository, InMemoryActivityRepository>()
                .AddMediatR(typeof(IUserRepository))
                .AddMediatR(typeof(IActivityRepository))
                .BuildServiceProvider();

            // Get mediator
            mediator = diContainer.GetRequiredService<IMediator>();
        }
        public static SingletonMediator Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new SingletonMediator();
                }
                return _instance;
            }
            private set { }
        }
        public IMediator GetMediator()
        {
            return mediator;
        }
    }
}
