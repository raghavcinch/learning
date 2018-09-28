using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Learning.Core.DocumentDB;
using Microsoft.Learning.UserProfile.Manager;
using Microsoft.Learning.UserProfile.Repository;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Microsoft.Learning.UserProfile.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Learning Services",
                    Description = "Learning Services",
                    TermsOfService = "None",
                });
            });
            services.AddSingleton<IDocumentClient, DocumentClient>(t => new DocumentClient(
                new Uri(Configuration.GetSection("ApplicationSettings").GetValue<string>("Host")),
                 Configuration.GetSection("ApplicationSettings").GetValue<string>("MasterKey"),
                 new ConnectionPolicy { ConnectionMode = ConnectionMode.Gateway, ConnectionProtocol = Protocol.Https }));

            services.AddTransient<IDataRepository, PersonRepository>(t => 
            new PersonRepository(t.GetRequiredService<IDocumentClient>())
            );
            services.AddTransient<IPersonManager, PersonManager>(t => 
            new PersonManager(t.GetRequiredService<IDataRepository>())
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning Services");
            });
        }
    }
}
