using curso.api.Business.Repositories;
using curso.api.Configurations;
using curso.api.Infraestruture.Data;
using curso.api.Infraestruture.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true; //Desabilitar a vedação dos ModelState para não utilizar o padrão da Microsoft
                    //Utilizar costumizado

                });
            services.AddSwaggerGen(c => //Lear arquivo de documentação xml
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme //Definição de segurança do Swagger
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });



                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //Pegando no nome do arquivo, é o meso do projeto + xml
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); //Pegando o local do arquivo, nesse caso o mesmo da aplicação
                c.IncludeXmlComments(xmlPath); //Incluir comentários no swagger
            });

            //Criar chave de configuração
            var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value); //Ler a chave e converter em bytes
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<CursoDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly(typeof(CursoDbContext).Assembly.FullName).EnableRetryOnFailure());
            });
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IAuthenticationService, JwtService>();
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

            app.UseAuthentication(); //Add autenticação
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
