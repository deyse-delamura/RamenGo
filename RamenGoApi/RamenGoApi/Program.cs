using Microsoft.Extensions.Options;
using RamenGoApi.Application.Services;
using RamenGoApi.Domain.Repositories;
using RamenGoApi.Infrastructure.Configurations;
using RamenGoApi.Infrastructure.ExternalServices;
using RamenGoApi.Infrastructure.Persistence;
using RamenGoApi.Middleware;

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

// Registra os reposit�rios
builder.Services.AddScoped<IProteinaRepository, ProteinaRepository>();
builder.Services.AddScoped<ICaldoRepository, CaldoRepository>();

// Registra as factories e services
builder.Services.AddScoped<PedidoService>();

// Registra o servi�o externo de gera��o de IDs com HttpClient
//builder.Services.AddHttpClient<OrderIdGeneratorService>();

// Vincular as configura��es do OrderServiceOptions
builder.Services.Configure<OrderServiceOptions>(builder.Configuration.GetSection("OrderService"));

// Configurar o HttpClient com BaseAddress e headers padr�o
builder.Services.AddHttpClient<OrderIdGeneratorService>((provider, client) =>
{
    var options = provider.GetRequiredService<IOptions<OrderServiceOptions>>().Value;
    client.BaseAddress = new Uri(options.BaseUrl);
    client.DefaultRequestHeaders.Add("x-api-key", options.ApiKey);
});


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

app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();