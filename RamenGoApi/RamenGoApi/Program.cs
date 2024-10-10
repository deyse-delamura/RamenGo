using RamenGoApi.Application.Services;
using RamenGoApi.Domain.Repositories;
using RamenGoApi.Domain.Services;
using RamenGoApi.Infrastructure.ExternalServices;
using RamenGoApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

// Registra os repositórios
builder.Services.AddScoped<IProteinaRepository, ProteinaRepository>();
builder.Services.AddScoped<ICaldoRepository, CaldoRepository>();

// Registra as factories e services
builder.Services.AddScoped<PedidoFactory>();
builder.Services.AddScoped<PedidoService>();

// Registra o serviço externo de geração de IDs com HttpClient
builder.Services.AddHttpClient<OrderIdGeneratorService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();