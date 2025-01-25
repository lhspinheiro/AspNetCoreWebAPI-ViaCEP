using Refit;
using ViaCep.Integration;
using ViaCep.Integration.Interfaces;
using ViaCep.Integration.Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IViaCepIntegration, ViaCepIntegration>(); //configurando a injeção de dependencia

builder.Services.AddRefitClient<IViaCepIntegrationRefit>().ConfigureHttpClient(client => {
    client.BaseAddress = new Uri("https://viacep.com.br");  //configuração a injeção do refit para qual API ira se comunicar
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
