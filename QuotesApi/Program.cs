var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();

// Swagger only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT: Do NOT use HTTPS redirection on Render
// app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

// Controllers
app.MapControllers();

// Optional root endpoint (helps confirm service is online)
app.MapGet("/", () => "Random Quotes API is running 🚀");

app.Run();
