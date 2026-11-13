using ApiBolsas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registra o BolsaService para injeção de dependência
builder.Services.AddScoped<BolsaService>();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirVue", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "ApiBolsas v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("PermitirVue");

app.MapControllers();

app.Run();
