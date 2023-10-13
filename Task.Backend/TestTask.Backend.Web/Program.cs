using TestTask.Backend.DataAccess;
using TestTask.Backend.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.Get<AppConfiguration>();

builder.Services.AddDataAccess();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.WithOrigins(configuration.Cors.Origins)
        .AllowAnyMethod()
        .WithHeaders("content-type", "origin");
});

app.MapControllers();

app.Run();

