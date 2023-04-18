using EmployeeBlazorServerProject.Models;
using EmployeeBlazorServerProject.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EmployeeBlazorServerProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EmployeeBlazorServerProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'EmployeeBlazorServerProjectContextConnection' not found.");

builder.Services.AddDbContext<EmployeeBlazorServerProjectContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<EmployeeBlazorServerProjectContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7263/");
});

builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7263/");
});

builder.Services.AddAutoMapper(typeof(EmployeeMapper));

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
app.UseAuthentication();;

app.Run();
