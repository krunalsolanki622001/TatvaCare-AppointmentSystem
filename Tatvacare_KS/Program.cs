using Microsoft.EntityFrameworkCore;
using Tatvacare_KS.Data;
using Tatvacare_KS.Services;

var builder = WebApplication.CreateBuilder(args);

// DbContext (InMemory for now)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TatvaCareDb"));

// Register service
builder.Services.AddScoped<AppointmentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (for Angular)
const string CorsPolicy = "AllowFrontend";
builder.Services.AddCors(o => o.AddPolicy(CorsPolicy, p =>
    p.WithOrigins(
        "http://localhost:4200",
        "http://127.0.0.1:4200",
        "https://localhost:44472" // Angular dev server
    )
    .AllowAnyHeader()
    .AllowAnyMethod()
));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CorsPolicy);
app.MapControllers();

app.Run();
