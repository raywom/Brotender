using System.Text.Json.Serialization;
using Brotender.Context;
using Microsoft.EntityFrameworkCore;
using Brotender.Controllers;
//to transfer files to server
//scp -r C:\Users\rkuan\RiderProjects\Brotender\Brotender\bin\debug\net6.0\publish\ raywom@test.lyteloli.space:/home/raywom/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
try
{
    Console.WriteLine(connectionString);
    builder.Services.AddDbContext<BrotenderContext>(options => options.UseMySql(connectionString, 
        new MySqlServerVersion(new Version(8, 0, 25))));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.WebHost.UseUrls("http://localhost:7046");
var app = builder.Build();
app.UseHttpsRedirection();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();

app.MapControllers();

app.Run();