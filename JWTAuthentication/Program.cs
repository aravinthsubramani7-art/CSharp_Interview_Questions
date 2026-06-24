using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using JWTAuthentication.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger service
builder.Services.AddSwaggerGen(options => //here we are not dealing with generating or validation JWT token, this is to inform the Swagger this API is usng JWT Authentication and show Authorize buttion 
{
    options.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
        Name = "Authorization", //means JWT token will be sent in Authorization header
        Type = SecuritySchemeType.Http, //means This authentication uses HTTP headers
        Scheme = "bearer", //means Use Bearer Authentication, if it is a Basic Authentication we need to give the value as basic
        BearerFormat = "JWT",
        In = ParameterLocation.Header //Send token in request header
    }); //My API uses JWT Bearer Authentication. Token must be sent in Authorization header.

    options.AddSecurityRequirement( //SecurityDefinition only defines authentication. SecurityRequirement tells Swagger: Actually use it.
        new OpenApiSecurityRequirement //This API requires authentication
        {
            {
                new OpenApiSecurityScheme //means Which authentication scheme? answer bearer
                {
                    Reference = new OpenApiReference //Don't create a new scheme. Use the one already defined.
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        }); //Without SecurityRequirement, Swagger shows: Authorize Button ✓, But protected endpoints may not automatically use the token. With SecurityRequirement, Swagger says: Apply Bearer Authentication, to protected endpoints.
});

// Add services to the container.

//configure Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; //for testing purpose this is set to false, enabling it in production to ensure https is required for metadata
    options.SaveToken = true;
    
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"]!)), //Use secret key to verify token signature
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, //Reject expired tokens
        ValidateIssuerSigningKey = true //Verify token wasn't modified
    };
});
//add authorization service
builder.Services.AddAuthorization();
builder.Services.AddScoped<JwtService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseAuthorization();

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
