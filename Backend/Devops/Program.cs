using Devops.Data;
using Microsoft.EntityFrameworkCore;
using Repository.ImpI;
using Repository.Interface;
using Service.ImpI;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:8080");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    .Replace("localhost", "192.168.8.102"); 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost", "http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular", policy =>
//    {
//        policy.WithOrigins("http://localhost:4200") 
//              .AllowAnyMethod()
//              .AllowAnyHeader();
//    });
//});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}


app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
