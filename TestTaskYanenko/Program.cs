using Microsoft.EntityFrameworkCore;
using TestTaskYanenko.Models;
using TestTaskYanenko.Models.DataManager;
using TestTaskYanenko.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Context>(x => x.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a custom scoped servicies
builder.Services.AddScoped<IDataRepository<Project>, ProjectManager>();
builder.Services.AddScoped<ITimeTracker, ActivityManager>();
builder.Services.AddScoped<IDataRepository<ActivityType>, ActivityTypeManager>();
builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
builder.Services.AddScoped<IDataRepository<Role>, RoleManger>();

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
