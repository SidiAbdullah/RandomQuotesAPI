var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", p =>
        p.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

// سماح بعرض HTML/CSS/JS
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// صفحة افتراضية
app.MapGet("/", () => Results.Redirect("/Quotes.html"));

app.Run();
