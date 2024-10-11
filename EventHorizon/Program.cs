using Microsoft.AspNetCore.Components;using Microsoft.AspNetCore.Components.Web;using EventHorizon.src.Memory;using Microsoft.AspNetCore.Server.Kestrel.Core;using EventHorizon.src.TimeLine;using EventHorizon.src.Util;using EventHorizon.src.Events;
using EventHorizon.Services;using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=data/app.db"));
builder.Services.AddSingleton<MemoryController>();
builder.Services.AddSingleton<SettingsManager>();
builder.Services.AddSingleton<EventManager>();
builder.Services.AddSingleton<TimeLineController>();
builder.Services.AddHostedService<TimeLineBackgroundService>();
builder.Services.AddSingleton<LocalizationService>();
builder.Services.AddScoped<I18nHelper>();

builder.WebHost.ConfigureKestrel(options =>
{
    // HTTP Binding
    options.ListenAnyIP(80);


    //// HTTPS Binding
    //options.ListenAnyIP(443, listenOptions =>
    //{
    //    listenOptions.UseHttps("certs/localhost.pfx", "123456"); // Pfad und Passwort zum Zertifikat
    //});
});



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});


var app = builder.Build();

//Generate/migrate db
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); 
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseDeveloperExceptionPage();
app.Run();
