using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Transforma.Domain.CommandHandler;
using Transforma.Domain.Commands;
using Transforma.Domain.Core;
using Transforma.Domain.Interfaces;
using Transforma.infrastructure;
using Transforma.Repository;

namespace TransformaPalavrasProject
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
            services.AddMediatR();
            
            services.AddScoped<ITransformaPalavraRepository, TransformaPalavraRepository>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddScoped<IRequestHandler<TransformarPalavraCommand, CommandResult>, TransformarPalavraCommandHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Transformar palavras",
                        Version = "v1",
                        Description = "Verifica quantidade de movimentos para substituir a primeira palavra pela segunda",
                        Contact = new Contact
                        {
                            Name = "Heleno de Oliveira Santos",
                            Url = ""
                        }
                    });

                c.IncludeXmlComments("Transforma.API.xml");
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Transformar Palavras");
            });
        }
    }
}
