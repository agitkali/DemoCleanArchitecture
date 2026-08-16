using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Mapping;
using ProductManagement.Application.Services;
using ProductManagement.InfrastructureLayer.Data;
using ProductManagement.InfrastructureLayer.Repositories;
using ProductManagement.InfrastructureLayer.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("CleanArchitectureDbConn"));
});

// Generic Repository
builder.Services.AddScoped(
    typeof(IGenericRepository<>),
    typeof(GenericRepository<>));

// Product Repository
builder.Services.AddScoped<
    IProductRepository,
    ProductRepository>();

// Unit Of Work
builder.Services.AddScoped<
    IUnitOfWork,
    UnitOfWork>();

// Product Service
builder.Services.AddScoped<
    IProductService,
    ProductService>();


// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ProductProfile>();
});

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
