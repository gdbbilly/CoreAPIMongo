using App.Service.Web.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace App.Service.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddResponseCompression()
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "App API", Version = "v1" });
                    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "App.Web.xml"));
                });
            
            Facade.Initialize(Configuration.GetValue<string>("ConnectionStrings:MongoDBConnectionString"),
                                Configuration.GetValue<string>("ConnectionStrings:MongoDBDatabaseName"));
            
            MongoMappings();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "App API v1");
            });

            app.UseMvcWithDefaultRoute();
            app.UseResponseCompression();

            app.Run(context =>
            {
                context.Response.Redirect("/swagger");
                return Task.CompletedTask;
            });
            app.UseMvc();
        }

        private void MongoMappings()
        {
            var classMaps = typeof(MongoDBClassMap<>).GetTypeInfo().Assembly.GetTypes().Where(p => p.GetTypeInfo().BaseType != null && p.GetTypeInfo().BaseType.IsConstructedGenericType && p.GetTypeInfo().BaseType.GetGenericTypeDefinition() == typeof(MongoDBClassMap<>))
            .Where(p => !p.GetTypeInfo().IsAbstract);

            foreach (var classMap in classMaps)
            {
                Activator.CreateInstance(classMap);
            }
        }
    }
}
