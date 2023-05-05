using System;
namespace AFSAPIService
{
	public class Startup
	{
        public IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            // Init Serilog configuration
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
    }
}

