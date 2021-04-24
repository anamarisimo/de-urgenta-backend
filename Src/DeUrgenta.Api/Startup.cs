using System.Reflection;
using DeUrgenta.Admin.Api.Controller;
using DeUrgenta.Backpack.Api.Controllers;
using DeUrgenta.Certifications.Api.Controller;
using DeUrgenta.Api.Extensions;
using DeUrgenta.Common.Swagger;
using DeUrgenta.Domain;
using DeUrgenta.Group.Api.Controllers;
using Hellang.Middleware.ProblemDetails;
using DeUrgenta.Infra.Extensions;
using DeUrgenta.User.Api.Controller;
using MediatR;
using Microsoft.Extensions.Hosting;
using DeUrgenta.User.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DeUrgenta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            WebHostEnvironment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private const string CorsPolicyName = "MyPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBearerAuth(Configuration);
            services.AddControllers();
            services.AddDatabase<DeUrgentaContext>(Configuration.GetConnectionString("DbConnectionString"));
            services.AddExceptionHandling(WebHostEnvironment);
            

            var applicationAssemblies = GetAssemblies();

            services.AddSwaggerFor(applicationAssemblies, Configuration);
            services.AddMediatR(applicationAssemblies);

            services.AddCors(o => o.AddPolicy(CorsPolicyName, builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.SetupEmailService(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (WebHostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseProblemDetails();
            app.UseConfigureSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            

            app.UseCors(CorsPolicyName);

            

        }

        private static Assembly[] GetAssemblies() => new[]
            {
                Assembly.GetAssembly(typeof(Startup)),

                // Application parts
                typeof(BackpackController).GetTypeInfo().Assembly,
                typeof(CertificationController).GetTypeInfo().Assembly,
                typeof(BlogController).GetTypeInfo().Assembly,
                typeof(GroupController).GetTypeInfo().Assembly,
                typeof(UserController).GetTypeInfo().Assembly,

                // Common

                typeof(ApplicationErrorResponseExample).GetTypeInfo().Assembly
            };
    }
}
