using System.Reflection;
using Microsoft.OpenApi.Models;

const string _CorsPolicies = "AllowSpecificOrigin";

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200", "http://localhost:5551", "http://localhost:80", "http://localhost")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition")
                );
            });

//Https Redirect
services.AddHttpsRedirection(options => { options.HttpsPort = 443; });


services.AddControllersWithViews();
// In production, the Angular files will be served from this directory
services.AddSpaStaticFiles(configuration => { configuration.RootPath = "..frontend/dist/calorie-share"; });


services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache            

services.AddHttpContextAccessor();
services.AddResponseCompression();

//Autofac-Configuration
services.AddMvc().AddControllersAsServices();

services.AddOptions();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Angular Client",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200");
                      });
});



var app = builder.Build();
// app.UseCors();
//prevent cache /
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(_CorsPolicies);
app.UseDeveloperExceptionPage();



app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        if (context.File.Name == "index.html")
        {
            context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
            context.Context.Response.Headers.Add("Expires", "-1");
        }
    }
});

app.UseSpaStaticFiles();


app.UseResponseCompression();
app.UseAuthentication();
// app.UseSession();
app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}").RequireCors(_CorsPolicies);
});

app.UseSpa(spa =>
{

    spa.Options.SourcePath = "../frontend";

    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
});


app.Run();
