using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Hotel.DataAccess;
using Hotel.GraphQL;
using Hotel.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hotel
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<HotelRepository>();
            //services.AddScoped<HotelReviewRepository>();

            services.AddScoped(service => new HotelRepository(service.GetRequiredService<HotelContext>));
            services.AddScoped(service => new HotelReviewRepository(service.GetRequiredService<HotelContext>));

            var connectionString = Configuration["ConnectionStrings:HotelDBConnectionString"];
            services.AddDbContext<HotelContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services
                .AddGraphQL(options => { options.ExposeExceptions = Env.IsDevelopment(); })
                .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddScoped<HotelSchema>();

            services
                .AddControllers()
                .AddNewtonsoftJson();

            // kestrel
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // IIS
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, HotelContext hotelContext)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            hotelContext.Seed();
            app.UseGraphQL<HotelSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
