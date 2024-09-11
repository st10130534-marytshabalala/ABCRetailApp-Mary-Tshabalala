using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ensure that Configuration is accessed properly from the builder
var configuration = builder.Configuration;

// Add Azure Table Service and Blob Service using the correct connection string
builder.Services.AddSingleton(x => new TableServiceClient(configuration.GetConnectionString("AzureStorageConnection")));
builder.Services.AddSingleton(x => new BlobServiceClient(configuration.GetConnectionString("AzureStorageConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios.
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
