using Microsoft.EntityFrameworkCore;
using NLayer.Core.Repository;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();//IUnitOfWork ile kar��la��rsan UnitOfWork nesne �rne�i al demektir.
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); //IGenericRepository ile kar��la��rsan GenericRepository nesne �rne�i al demektir.
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();







builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); //NLayer.Repository Katman�m ile NLayer.Api katman�m�z� konu�turuyoruz.
    });
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
