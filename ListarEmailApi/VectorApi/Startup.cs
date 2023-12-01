using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vector.Aplicacao.Aplicacao;
using Vector.Aplicacao.Contrato;
using Vector.Dominio.Contratos.IRepositorio;
using Vector.Dominio.Contratos.IRepositorio.Comum;
using Vector.Dominio.Contratos.IServico;
using Vector.Dominio.Contratos.IServico.Comum;
using Vector.Dominio.Servicos;
using Vector.Dominio.Servicos.Comum;
using Vector.Infra.Data.Contexto;
using Vector.Infra.Data.Repositorio;
using Vector.Infra.Data.Repositorio.Comum;
using Vector.Servicos.EmailApi.Contrato;
using Vector.Servicos.EmailApi.Request;

namespace VectorApi
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
            services.AddDbContext<Context>(x => x.UseSqlServer(Configuration.GetConnectionString("BDPrincipal")));

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("Qwerty123asdfg456ZxCvB001")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            #region Repositorio
            services.AddTransient(typeof(IRepositorioComum<>), typeof(RepositorioComum<>));
            services.AddScoped<IAvatarMockRepositorio, AvatarMockRepositorio>();
            #endregion

            #region Servicos
            services.AddTransient(typeof(IServicoComum<>), typeof(ServicoComum<>));
            services.AddScoped<IAvatarMockServico, AvatarMockServico>();
            #endregion

            #region Aplicaao
            services.AddScoped<IAvatarMockAplicacao, AvatarMockAplicacao>();
            #endregion

            #region Services Api
            services.AddScoped<IRequestApi, RequestApi>();
            #endregion

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VectorApi", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
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
                         new string[] {}
                    }
                });
            });

            services.AddCors(options => options.AddDefaultPolicy(builder => builder.AllowAnyOrigin()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VectorApi v1"));
            }

            app.UseRouting();
            app.UseCors(x => x.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader()
                       );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
