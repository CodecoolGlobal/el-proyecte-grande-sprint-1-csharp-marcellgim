using System.Text.Json.Serialization;
using BpRobotics.Data;
using BpRobotics.Data.Repositories;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using BpRobotics.Core.Model.AuthenticationModels;
using BpRobotics.Services.Authenticators;
using BpRobotics.Services.PasswordHasher;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("Authentication"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                "https://icy-mushroom-0411fdf0f.1.azurestaticapps.net")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add datastore service
builder.Services.AddDbContext<BpRoboticsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add data repository services
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Partner>, PartnerRepository>();
builder.Services.AddTransient<IRepository<Device>, DeviceRepository>();
builder.Services.AddTransient<IRepository<Service>, ServiceRepository>();

// Authentication services
builder.Services.AddTransient<Authenticator>();
builder.Services.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:AccessTokenSecret"])),
        ValidIssuer = builder.Configuration["Authentication:Audience"],
        ValidAudience = builder.Configuration["Authentication:Issuer"],
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Add data logic services
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPartnersService, PartnersService>();
builder.Services.AddTransient<CustomerService>();
builder.Services.AddTransient<DeviceService>();
builder.Services.AddTransient<ServiceService>();



builder.Services.AddTransient<DataSeeder>();


var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initialiser = services.GetRequiredService<DataSeeder>();
initialiser.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles")),
    RequestPath = "/StaticFiles"
});

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
