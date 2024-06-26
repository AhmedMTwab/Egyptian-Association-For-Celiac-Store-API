using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var CS = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EgyptianAssociationOfCieliacPatientsContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(CS);
});

builder.Services.AddScoped<ICRUDRepo<Patient>, MainRepository<Patient>>();
builder.Services.AddScoped<ICRUDRepo<AssosiationBranch>, MainRepository<AssosiationBranch>>();
builder.Services.AddScoped<ICRUDRepo<Dises>, MainRepository<Dises>>();
builder.Services.AddScoped<ICRUDRepo<Doctor>, MainRepository<Doctor>>();
builder.Services.AddScoped<ICRUDRepo<Clinic>, MainRepository<Clinic>>();
builder.Services.AddScoped<ICRUDRepo<HealthInsurance>, MainRepository<HealthInsurance>>();
builder.Services.AddScoped<ICRUDRepo<Pharmacy>, MainRepository<Pharmacy>>();
builder.Services.AddScoped<ICRUDRepo<Lab>, MainRepository<Lab>>();
builder.Services.AddScoped<ICRUDRepo<Hospital>, MainRepository<Hospital>>();
builder.Services.AddScoped<ICRUDRepo<Product>, MainRepository<Product>>();
builder.Services.AddScoped<ICRUDRepo<RawMaterial>, MainRepository<RawMaterial>>();

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
