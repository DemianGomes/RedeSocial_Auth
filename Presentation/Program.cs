using System.Reflection;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using RedeSocial_Auth.Application.Interfaces;
using RedeSocial_Auth.Application.Services;
using RedeSocial_Auth.Infrastructure.Persistence.Interfaces;
using RedeSocial_Auth.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registrando Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RedeSocial_Auth", Version = "v1" });

    // Localizar o arquivo de documentação XML gerado
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

// Registrando autoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adiciona o contexto do banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>();

// Registrando controllers
builder.Services.AddControllers();

// Registrando camada Application (Service)
builder.Services.AddScoped<IUserService, UserService>();

// Registrando camada Infrastructure (Repository)
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Aplica as migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedeSocial_Auth v1");
        c.RoutePrefix = string.Empty; // Para acessar o Swagger na raiz (opcional)
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
