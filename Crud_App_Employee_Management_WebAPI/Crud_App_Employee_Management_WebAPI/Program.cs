using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.DataAccess;
using ServiceLayer;
using JWTAuthenticationAuthorization;
using JWTAuthenticationAuthorization.JwtServices;
using JWTAuthenticationAuthorization.JwtModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//    .AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
//});

builder.Services.AddScoped<EmployeeServices>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddDbContext<DbConnection>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
    options.UseMySQL(connectionString);
});
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();
app.UseMiddleware<JwtMiddleware>();
// Configure the HTTP request pipeline.
app.UseRouting();

//app.UseAuthorization();
//app.UseAuthentication();

app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
