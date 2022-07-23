using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace curso.api
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
            services.AddSwaggerGen(c => //Lear arquivo de documentação xml
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //Pegando no nome do arquivo, é o meso do projeto + xml
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); //Pegando o local do arquivo, nesse caso o mesmo da aplicação
                c.IncludeXmlComments(xmlPath); //Incluir comentários no swagger
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(); //Subir o middleware do swagger
            app.UseSwaggerUI(c => //Rota do swagger
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api curso treinamento V1");
                c.RoutePrefix = String.Empty;//swagger //Rota padrão, ja cai direto no swagger
            });
        }
    }
}
