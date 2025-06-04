var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controladores (necessário!)
builder.Services.AddControllers();

// Permitir CORS (opcional, útil se frontend estiver separado)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Ativa arquivos estáticos (index.html, JS, CSS)
app.UseDefaultFiles();
app.UseStaticFiles();

// HTTPS e CORS
app.UseHttpsRedirection();
app.UseCors("AllowAll");

// Mapeia os controladores da API
app.MapControllers();

app.Run();
