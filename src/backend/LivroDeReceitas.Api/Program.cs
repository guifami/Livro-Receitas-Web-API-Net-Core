using LivroDeReceitas.Api.Filtros;
using LivroDeReceitas.Application;
using LivroDeReceitas.Application.Services.AutoMapper;
using LivroDeReceitas.Domain.Extension;
using LivroDeReceitas.Infrastructure;
using LivroDeReceitas.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepository(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguracao());
}).CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

atualizarBaseDeDados();

app.Run();

void atualizarBaseDeDados()
{
    var connection = builder.Configuration.GetConnection();
    var database = builder.Configuration.GetDatabaseName();

    Database.CriateDatabase(connection, database);

    app.MigrateDatabase();
}