using Microsoft.OpenApi.Models;
using MediatR;
using MicroRabbit.Infra.IOC;
using Microsoft.EntityFrameworkCore;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventHandlers;

namespace MicroRabbit.Transfer.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<TransferDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("BankingDbConnection")));
            //services.Configure<ConnectionStringOptions>(Configuration.GetSection("ConnectionStrings"));

            services.AddMediatR(typeof(Startup));

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Transfer Microservice",
                    Version = "v1"
                });
            });
            RegisterServices(services);
        }
        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
