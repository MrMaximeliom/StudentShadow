using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudentShadow.Data;
using StudentShadow.Helpers;
using StudentShadow.Middlewares;
using StudentShadow.Models;
using StudentShadow.Services;
using StudentShadow.UnitOfWork;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
    .AddJwtBearer(
    o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))

        };     


    });

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
    
}
//UseSwaggerAuth.UseSwaggerAuthorized(app);
app.UseSwagger();
app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "Student Shadow Documentation v1"));
    app.UseReDoc(options =>
    {
        options.DocumentTitle = "Student Shadow Documentation";
        options.SpecUrl = "/swagger/v1/swagger.json";
    });
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

