using LinkShortener.Model;
using LinkShortener.Models.Interfaces;
using LinkShortener.Services;
using LinkShortener.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("My Policy",
        policy => policy.
        WithOrigins("https://localhost:7275").
        AllowAnyMethod().
        AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.
    AddSingleton<IAssignLinkService, AssignLinkService>().
    AddSingleton<ILinkModel, LinkModel>();

builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
