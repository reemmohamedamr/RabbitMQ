using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MicroRabbit.Infra.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<BankingDbContext>();
            //Domain bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            //data
            services.AddTransient<IAccountRepository, AccountRepository>();

            //Application services
            services.AddTransient<IAccountService, AccountService>();

        }
    }
}
