using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PortfolioAPI.PortfolioMappers;
using PortfolioAPI.Configurations;
using PortfolioAPI.Data;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PortfolioAPI.Data.Repositories;
using PortfolioAPI.Data.Repositories.Post;
using PortfolioAPI.Data.Repositories.Author;
using PortfolioAPI.Data.Repositories.Comment;
using PortfolioAPI.Data.Repositories.Tag;
using PortfolioAPI.Data.Repositories.Reactions;
using PortfolioAPI.Data.Repositories.User;
using PortfolioAPI.BuildingBlocks.Commands;
using PortfolioAPI.BuildingBlocks.Validators;
using Microsoft.SqlServer.Management.Smo.Wmi;
using PortfolioAPI;
using PortfolioAPI.BuildingBlocks;
using MediatR;
using FluentValidation;
using PortfolioAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
    };
});

// Add services to the container.
//builder.Services.AddHttpsRedirection(options =>
//{
//    options.HttpsPort = 5001;
//    options.ClientCertificateMode = ClientCertificateMode.AllowCertificate;
//    options.ServerCertificate = new X509Certificate2("mycert.crt");
//})

builder.Services.AddControllers();

builder.Services.AddSingleton<ISqlConnectionFactory, SqlConnectionFactory>();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), builder =>
    {
        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
    }));


builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
}) ;

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:4200")
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => { 
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PortfolioAPI"); 
});

//}

//app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.AddGlobalErrorHandler();

app.Run();