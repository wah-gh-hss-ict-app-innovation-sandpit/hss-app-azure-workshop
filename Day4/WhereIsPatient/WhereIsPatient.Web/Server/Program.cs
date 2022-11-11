using Microsoft.AspNetCore.ResponseCompression;
using WhereIsPatient.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// #NOTE: By default DBContextFactory create the context as a Singleton.
// You may want to change the lifespan to a transient or scoped instance depending on your requirememt
builder.Services.AddDbContextFactory<WhereIsPatientContext>(opt => opt.UseSqlServer("WhereIsPatientDBString"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
        .WithMethods("POST", "GET"));

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
