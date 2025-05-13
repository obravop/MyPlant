using MyPlant.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyPlant.Data;
using MyPlant.Services;
using MyPlant.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<MyPlantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyPlantContext") ?? throw new InvalidOperationException("Connection string 'MyPlantContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Register the service
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
