var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddCors();

builder.Services.AddResponseCompression();

builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle("~/bundles/styles.css",
        "/lib/jquery-simplyscroll/jquery.simplyscroll.css",
        "/css/site.css");

    pipeline.AddJavaScriptBundle("~/bundles/jquery.validate.js",
        "lib/jquery-validation/dist/jquery.validate.js",
        "lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js");

    pipeline.AddJavaScriptBundle("~/bundles/scripts.js",
        "lib/jquery-simplyscroll/jquery.simplyscroll.min.js",
        "js/site.js");
});

var app = builder.Build();


app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseResponseCompression();
app.UseWebOptimizer();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
