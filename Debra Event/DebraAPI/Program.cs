using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DebraAPI.Data;

using System;

var builder = WebApplication.CreateBuilder(args);
var conn = @"Data Source=DESKTOP-PSG981M\KAVINDASQL;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;
Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
builder.Services.AddDbContext<DebraAddDBContext>(option => option.UseSqlServer(conn));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container.
builder.Services.AddScoped<IPartnerRepo, PartnerRepo>();
builder.Services.AddScoped<ICreateEventRepo, CreateEventRepo>();
builder.Services.AddScoped<ISelTicketRepo, SelTicketRepo>();
builder.Services.AddScoped<IDebraAdminRepo, DebraAdminRepo>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
