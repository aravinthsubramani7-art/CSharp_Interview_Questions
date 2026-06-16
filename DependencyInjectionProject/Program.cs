using DependencyInjectionProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger service
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IGiftService, GiftService>();
//Singleton
//builder.Services.AddSingleton<IFoodService, FoodService>();
//Scoped
// builder.Services.AddScoped<IFoodService, FoodService>();
//Transient
builder.Services.AddTransient<IFoodService, FoodService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
