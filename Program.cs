using Blazored.LocalStorage;
using GoFast.UI.Services;
using GoFast.UI.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredLocalStorage();

//builder.Services.AddHttpClient("ApiGoFast", options =>
//{
//    options.BaseAddress = new Uri("https://localhost:7010/");
//});

builder.Services.AddScoped(options => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7010/")
});

//builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
//       provider.GetRequiredService<ApiAuthenticationStateProvider>());

builder.Services.AddHttpClient<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IMotoristaService, MotoristaService>();
builder.Services.AddHttpClient<IBlobService, BlobService>();
builder.Services.AddScoped<IFileConverter, FileConverter>();

builder.Services.AddAuthorizationCore();

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

//app.UseIdentityServer();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
//app.MapFallbackToFile("index.html");

app.Run();
