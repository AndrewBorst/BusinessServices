using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using DataApi.Models;


namespace DataApi
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        public Startup(ILogger<Startup> logger, IConfiguration configuration)
        {
            _logger = logger;

            _logger.LogInformation("Executing Configure()");

            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext> (options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); 

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
