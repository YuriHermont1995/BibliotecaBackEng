using DomainService.Dominio.Interfaces.Repository;
using DomainService.Dominio.Interfaces.Serviço;
using DomainService.Dominio.Serviços;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using Repository.Repositorio.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dominio.Interfaces;
using WebApplication3.Dominio.Interfaces.Repository;
using WebApplication3.Dominio.Serviços;
using WebApplication3.Repositorio.Repositorys;

namespace WebApplication3
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication3", Version = "v1" });
            });

           

            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(Configuration["ConnectionStrings:Default"]));

            StartDependencyInjectionAdd(services);
        }
        // This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication v1"));

            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void StartDependencyInjectionAdd(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteServico>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

            services.AddScoped<IObraService, ObraServico>();
            services.AddScoped<IObraRepositorio, ObraRepositorio>();
            
            services.AddScoped<IEmprestimoService, EmprestimoServico>();
            services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
            
            services.AddSingleton<IBaseRepositorio, BaseRepositorio>();

        }

    }
}
