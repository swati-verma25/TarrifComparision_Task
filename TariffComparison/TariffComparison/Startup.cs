
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TariffComparison.BusinessLogic.BusinessLogic;
using TariffComparison.Repository.Repositories;
using TariffComparison.WebApi.GlobalErrorHandling;

namespace TariffComparison.WebApi
{
    /// <summary>
    /// Owin Start up file
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup Ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Varibale to hold Configuration variable.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Enable Cors
            services.AddCors();
            services.AddHttpClient();
            services.AddMvc().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddHealthChecks();

            // configure dependencies
            ConfigureDependencies(services);

            services.AddHttpContextAccessor();

            //Configure swagger
            ConfigureSwagger(services);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ExceptionMiddlewareExtensions));
            app.UseRouting();

            // allow cors url 
            app.UseCors(options => options.WithOrigins(Configuration["RequestOrigins"])
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            // for authorization
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    AllowCachingResponses = false
                });
            });

            // enable swagger
            EnableSwagger(app);
        }

        private static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddTransient<ITariffRepository, TariffRepository>();
            services.AddTransient<ITariffBusinessLogic, TariffBusinessLogic>();
        }


        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Tarrif Comparison API",
                    Version = "v1",
                    Description = "Tariff Comparison Web API",
                });


                // Set the comments path for the Swagger JSON and UI.

            });
        }

        private static void EnableSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tariff Comparison Service API");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
