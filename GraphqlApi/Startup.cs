using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphqlApi.Contracts;
using GraphqlApi.Contracts.Repositories;
using GraphqlApi.Entities.Context;
using GraphqlApi.GraphQL.AppSchema;
using GraphqlApi.GraphQL.Queries;
using GraphqlApi.GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;

namespace GraphqlApi
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
            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DbConnectionString")));

            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            this.ConfigureGraphQLServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            this.ConfigureGraphQL(app);
            app.UseMvc();
        }

        private void ConfigureGraphQLServices(IServiceCollection services)
        {
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<ApplicationSchema>();

            //Queries, Mutations, Supcriptions
            services.AddSingleton<OwnerQuery>();

            //Types
            services.AddSingleton<OwnerType>();

            services.AddScoped<IServiceProvider>(serviceProvider => new FuncServiceProvider(serviceProvider.GetRequiredService));
            services.AddGraphQL(option =>
            {
                option.ExposeExceptions = false;
            }).AddGraphTypes(ServiceLifetime.Scoped);
        }

        private void ConfigureGraphQL(IApplicationBuilder app)
        {
            app.UseGraphQL<ApplicationSchema>();
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
        }
    }
}
