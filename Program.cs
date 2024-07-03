using Egyptian_association_of_cieliac_patients_api.Models;
using Egyptian_association_of_cieliac_patients_api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" }));
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v2", new OpenApiInfo { Title = "AuthAPI", Version = "v2" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
var CS = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EgyptianAssociationOfCieliacPatientsContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(CS);
});
builder.Services.AddCors(CorsOptions=> CorsOptions.AddPolicy("MyPolicy",
CorsPolicyBuilder => CorsPolicyBuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
var ValidIssur = builder.Configuration["JWT:Issuer"];
var ValidAudiance = builder.Configuration["JWT:Audiance"];
var ValidKey = builder.Configuration["JWT:SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = ValidIssur,
        ValidateAudience = false,
        //ValidAudience = ValidAudiance,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ValidKey))
    };
});
builder.Services.AddHttpContextAccessor();
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
builder.Services.AddScoped<ICRUDRepo<Order>, MainRepository<Order>>();
builder.Services.AddScoped<ICRUDRepo<Reservation>, MainRepository<Reservation>>();
builder.Services.AddScoped<ICRUDRepo<Cart>, MainRepository<Cart>>();
builder.Services.AddScoped<ICRUDRepo<Payment>, MainRepository<Payment>>();





var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("MyPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
