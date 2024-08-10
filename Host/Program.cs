using Application.Commands;
using Application.Contracts.IStudentService;
using Application.Contracts.Services;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Jwt;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.CustomSeeders;
using Infrastructure.Persistence.EfCoreRepository;
using Infrastructure.Persistence.Initialization;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<Domain.Services.StudentService>();
builder.Services.AddScoped<Domain.Services.UserService>();
builder.Services.AddScoped<Domain.Services.ApplicantService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<ICustomSeeder ,ApplicantSeeder>();
builder.Services.AddSingleton<CustomSeederRunner>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
    sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure")));


builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateCourse).Assembly));

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
    app.UseDeveloperExceptionPage();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
