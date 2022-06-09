using BpRobotics.Data;
using BpRobotics.Data.Repositories;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add datastore service
builder.Services.AddSingleton<IBpRoboticsDataStorage, BpRoboticsDataStorage>();
builder.Services.AddSingleton<IRepository<Partner>, PartnerRepository>();

// Add data repository services
builder.Services.AddSingleton<IRepository<User>, UserRepository>();

// Add data logic services
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
