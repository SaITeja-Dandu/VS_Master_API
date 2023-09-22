using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
//var builder = WebApplication.CreateBuilder (string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>()}) ;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.WebHost.UseUrls("http://*:5001");


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Host.ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.Run();
//app.UseCors();
app.UseRouting();

app
    .UseRouting()
    .UseHttpsRedirection()
    .UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("*",
            builder =>
            {
                builder
                    .AllowAnyOrigin() // Allow requests from any origin
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });


});

app.UseCors("AllowAnyOrigin");
