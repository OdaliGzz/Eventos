﻿using EventosAPI.Servicios;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EventosAPI
{
    public class Startup
    {
        
        public Startup(IConfiguration configutation)
        {
            Configuration = configutation;
            
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Terminar el ciclado infinito
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //Configuracion de DBContext con SQL
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddEndpointsApiExplorer();
            //Configuracion de servicios
            services.AddTransient<EventosServicio>();
            services.AddTransient<OrganizadoresServicio>();
            services.AddTransient<UsuarioServicio>();
            //Para manejo de versiones
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "APIEventos", Version = "v1" });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment()) //No esta en produccion
            {
                //No disponible en produccion
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
