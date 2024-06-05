using PruebaLinus.Data;
using Microsoft.EntityFrameworkCore;
using PruebaLinus.Services.Students;
using PruebaLinus.Services.Teachers;
// using PruebaLinus.Services.Courses;
// using PruebaLinus.Services.Enrollments;
// using PruebaLinus.Services.Emails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); // /para poder que nos deje usar los controladores que llaman los metdoss

builder.Services.AddDbContext<BaseContext>(Options =>
    Options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("(8.0.20-mysql")
        ));


builder.Services.AddScoped<IStudentsRepository, StudentsRepository>(); // Important
builder.Services.AddScoped<ITeachersRepository, TeachersRepository>(); // Important
// builder.Services.AddScoped<ICoursersRepository, CoursersRepository>(); // Important
// builder.Services.AddScoped<IEnrollmentsRepository, EnrollmentsRepository>(); // Important

// builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
// builder.Services.AddTransient<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();


app.MapControllers(); // Important
app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
