using Application;
using Application.Abstract;
using Infrastructure;
using Infrastructure.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePresentation
{
    internal class SingletonMediator
    {
        private static SingletonMediator _instance;
        private static readonly object locker = new object();
        public IMediator mediator;
        private SingletonMediator()
        {
            var diContainer = new ServiceCollection()
                .AddDbContext<DataContext>()
                .AddMediatR(typeof(AssemblyMarker))
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IActivityRepository, ActivityRepository>()
                .BuildServiceProvider();

            // Get mediator
            mediator = diContainer.GetRequiredService<IMediator>();
            Debug.WriteLine("Mediator instance called");
        }
        public static SingletonMediator Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (locker)
                    {
                        if(_instance == null)
                        {
                            _instance = new SingletonMediator();
                        }
                    }
                }
                return _instance;
            }
            private set { }
        }
    }
}
