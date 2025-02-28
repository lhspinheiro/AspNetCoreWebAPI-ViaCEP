var builder = WebApplication.CreateBuilder(args);

// Desabilitar a validação de certificados SSL (apenas para desenvolvimento)
if (builder.Environment.IsDevelopment())
{
    // Desabilitar a validação de certificados SSL (cuidado, isso é só para desenvolvimento)
    System.Net.ServicePointManager.ServerCertificateValidationCallback =
        (sender, cert, chain, sslPolicyErrors) => true;
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("ViaCepAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5087"); // URL da Web API
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cep}/{action=Index}/{id?}");

app.Run();