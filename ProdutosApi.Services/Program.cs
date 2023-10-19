using ProdutosApi.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Definindo os EndPoints com letras minusculas 
builder.Services.AddRouting(r => r.LowercaseUrls = true);

//configuração da documentação do Swagger
SwaggerConfiguration.Configure(builder);

//Habilitando o AutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();


//Tornando a classe Program publica
public partial class Program { }