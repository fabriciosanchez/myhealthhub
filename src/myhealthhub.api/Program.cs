using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.EntityFrameworkCore;
using myhealthhub.api.Models;
using Azure.Storage.Blobs;
using myhealthhub.api.Services;
using myhealthhub.api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyHealthHubContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
}, ServiceLifetime.Transient);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddScoped(_ => { 
  return new BlobServiceClient(builder.Configuration.GetConnectionString("StorageAccount"));
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering services
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IDatabaseManager, DatabaseManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
