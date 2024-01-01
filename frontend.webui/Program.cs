using frontend.business;
using frontend.data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AppDataRegistration();
builder.Services.AddBusinessRegistration();
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

app.UseAuthorization();
#region Admin Controller
#region AboutHeader
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/aboutHeader/update/{id}",
    defaults: new { Controller = "About", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/aboutHeader/create",
    defaults: new { Controller = "About", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/aboutHeader/details/{id}",
    defaults: new { Controller = "AboutHeader", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/aboutHeader",
    defaults: new { Controller = "AboutHeader", Action = "Index" }
    );
#endregion
#region About

app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/about/update/{id}",
    defaults: new { Controller = "About", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/about/create",
    defaults: new { Controller = "About", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/about/details/{id}",
    defaults: new { Controller = "About", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/about",
    defaults: new { Controller = "About", Action = "Index" }
    );
#endregion
#region Product
app.MapAreaControllerRoute(
    name: "areas",
    areaName: "admin",
    pattern: "admin/product/update/{id}",
    defaults: new { Controller = "Product", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/product/create",
    defaults: new { Controller = "Product", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/product",
    defaults: new { Controller = "Product", Action = "Index" }
    );

#endregion
#region Recent
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/recent/update/{id}",
    defaults: new { Controller = "Recent", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/recent/create",
    defaults: new { Controller = "Recent", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/recent/details/{id}",
    defaults: new { Controller = "Recent", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/recent",
    defaults: new { Controller = "Recent", Action = "Index" }
    );
#endregion
#region Pricing
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/update/{id}",
    defaults: new { Controller = "Pricing", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/create",
    defaults: new { Controller = "Pricing", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/pricing/details/{id}",
    defaults: new { Controller = "Pricing", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/pricing",
    defaults: new { Controller = "Pricing", Action = "Index" }
    );
#endregion
#region Contact
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contact/update/{id}",
    defaults: new { Controller = "Contact", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contact/create",
    defaults: new { Controller = "Contact", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contact/details/{id}",
    defaults: new { Controller = "Contact", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contact",
    defaults: new { Controller = "Contact", Action = "Index" }
    );
#endregion
#region ContactInfo 
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactInfo/update/{id}",
    defaults: new { Controller = "ContactInfo", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactInfo/create",
    defaults: new { Controller = "ContactInfo", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactInfo/details/{id}",
    defaults: new { Controller = "ContactInfo", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactInfo",
    defaults: new { Controller = "ContactInfo", Action = "Index" }
    );
#endregion
#region ContactHeader

app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactHeader/update/{id}",
    defaults: new { Controller = "ContactHeader", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactHeader/create",
    defaults: new { Controller = "ContactHeader", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactHeader/details/{id}",
    defaults: new { Controller = "ContactHeader", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/contactHeader",
    defaults: new { Controller = "ContactHeader", Action = "Index" }
    );
#endregion
#region Feauters
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/feauters/update/{id}",
    defaults: new { Controller = "Feauters", Action = "Update" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/feauters/create",
    defaults: new { Controller = "Feauters", Action = "Create" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/feauters/details/{id}",
    defaults: new { Controller = "Feauters", Action = "Details" }
    );
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin/feauters",
    defaults: new { Controller = "Feauters", Action = "Index" }
    );
#endregion
#region DashBoard 
app.MapAreaControllerRoute(

    name: "areas",
    areaName: "admin",
    pattern: "admin",
    defaults: new { Controller = "Dashboard", Action = "Index" }

    );
#endregion

#endregion

#region Ui Controller


#region Home
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{Action=Index}/{id?}"
    );
#endregion
#endregion




app.Run();
