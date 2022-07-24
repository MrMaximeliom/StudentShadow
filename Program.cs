using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentShadow.Data;
using StudentShadow.UnitOfWork;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add DB Context
builder.Services.AddDbContext<ApplicationDBContext>(

    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName))
    );
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Student Shadow API",
            Version = "v1",
            Description = "This .NET API was built for an application called Student Shadow , which helps to keep track of students and their activities in the school",
            Contact = new OpenApiContact
            {
                Name = "Moayed Abdulhafiez",
                Email = "hysoca7@gmail.com",
                Url = new Uri("https://github.com/mrmaximeliom"),
            },
            License = new OpenApiLicense
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT"),
            },

        });
        // generate the xml docs that'll  drive the swagger docs
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);



    }

    ).AddSwaggerGenNewtonsoftSupport();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

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
