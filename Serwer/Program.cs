using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHealthChecks("/healthcheck");

app.Start();

//gets the port number
var server = app.Services.GetService<IServer>();
var addressFeature = server.Features.Get<IServerAddressesFeature>();

Console.WriteLine("Data uruchomienia: " + DateTime.Now);
Console.WriteLine("Autor: Tomasz Wiatrowski");
foreach (var address in addressFeature.Addresses)
{
    Console.WriteLine("Port TCP: " + address.Split(":").Last());
}

app.WaitForShutdown();