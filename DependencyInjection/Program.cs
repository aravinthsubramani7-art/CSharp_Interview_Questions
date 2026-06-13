using CoachingClassAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger service
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IStudentService, MathStudentService>();
//requirement change they want Science student count means comment out above code
builder.Services.AddScoped<IStudentService, ScienceStudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();