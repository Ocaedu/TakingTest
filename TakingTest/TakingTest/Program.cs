
using TakingTest.Domain.Interfaces.Services;
using TakingTest.Domain.Services;
using TakingTest.Domain.Interfaces.Repositories;
using TakingTest.Infra.Contexts;
using TakingTest.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using TakingTest.Application.Interfaces;
using TakingTest.Application.Services;
using TakingTest.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Adicionando o contexto e confiurando a string de conexão
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<SaleContext>(x => x.UseSqlite(connectionString));
//Inserindo os serviços no container

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogApp, LogAppService>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleApp, SaleAppService>();
builder.Services.AddScoped<IBranchService, BranchService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();


builder.Services.AddAutoMapper(x => x.AddProfile(new MappingEntity()));

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
