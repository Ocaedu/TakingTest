using Microsoft.EntityFrameworkCore;
using TakingTest.Domain.Interfaces.Services;
using TakingTest.Domain.Services;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Infra.Contexts;
using TakingTest.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adicionando o contexto e confiurando a string de conex�o
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SaleContext>(x => x.UseSqlite(connectionString));
//Inserindo os servi�os no container

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();


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

app.Run();