using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using TransNetwork.Data;
using static TransNetwork.Interfaces.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped<Encrypt_Decrypt_Data>();

builder.Services.AddScoped<ExampleService, ExampleService>();

builder.Services.AddScoped<IDapperService, DapperService>();

builder.Services.AddScoped<IPaysService, PaysService>();
builder.Services.AddScoped<IGouvernoratService, GouvernoratService>();
builder.Services.AddScoped<IDelegationService, DelegationService>();

builder.Services.AddScoped<ICategorieService, CategorieService>();
builder.Services.AddScoped<IMarqueService, MarqueService>();
builder.Services.AddScoped<IModeleService, ModeleService>();

builder.Services.AddScoped<ICiviliteService, CiviliteService>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IVehiculeService, VehiculeService>();

builder.Services.AddScoped<IRoleUtilisateurService, RoleUtilisateurService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IPassagerService, PassagerService>();
builder.Services.AddScoped<IConducteurService, ConducteurService>();
builder.Services.AddScoped<IActiviteService, ActiviteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
