using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaApp.DataAccess.CosmosDb;
using SpaApp.Shared.DataAccess;
using System.Linq;

namespace SpaApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddSingleton(s =>
            {
                string endpointUrl = this.Configuration.GetValue<string>("EndPointUrl");
                string authorizationKey = this.Configuration.GetValue<string>("AuthorizationKey");

                return new CosmosClient(endpointUrl, authorizationKey);
            });

            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();

            services.Configure<CosmosDbOptions>(this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            app.UseClientSideBlazorFiles<Client.Startup>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
            });
        }
    }
}
