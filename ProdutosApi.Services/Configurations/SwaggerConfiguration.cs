using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProdutosApi.Services.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(WebApplicationBuilder builder)
        {
            //habilitando a geração da documentação do swagger
            builder.Services.AddEndpointsApiExplorer();

            //personalizando a documentação 
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API para controle de produtos",
                    Description = "Projeto desenvolvido em AspNet API, EntityFramework Core, AutoMapper e XUnit.",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington Henrik Martins",
                        Email = "wellingtonhenrik13@gmail.com",
                    }
                });

                //configuração para adicionar os comentarios XML do código na documentação 
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

        }
    }
}
