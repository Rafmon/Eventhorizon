using Microsoft.AspNetCore.Components;
using EventHorizon.Services;

var builder = WebApplication.CreateBuilder(args);

{
    // HTTP Binding
    options.ListenAnyIP(80);
    
    
    //// HTTPS Binding
    //options.ListenAnyIP(443, listenOptions =>
    //{
    //    listenOptions.UseHttps("certs/localhost.pfx", "123456"); // Pfad und Passwort zum Zertifikat
    //});
});