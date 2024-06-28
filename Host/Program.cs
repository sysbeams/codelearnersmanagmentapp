using Application.Contracts.IStudentService;
using Application.Contracts.Services;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Jwt;
using Infrastructure.Persistence.EfCoreRepository;
using Infrastructure.Repositories;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILogInService, LogInService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddControllers();

//serilog configuration 
ApplicationExtension.ConfigureSerilog(builder.Host);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwtAuth();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseExceptionMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
