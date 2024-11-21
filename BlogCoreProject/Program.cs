using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// FluentValidation i�in dil ayar�
ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

// Global AuthorizeFilter eklenmesi
builder.Services.AddControllersWithViews(options =>
{
	var policy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser() // Giri� yapm�� kullan�c� gereksinimi
		.Build();
	options.Filters.Add(new AuthorizeFilter(policy)); // T�m Controller ve Action'lara uygula
});

// Database Context'i ekle
builder.Services.AddDbContext<Context>();

// Dependency Injection (DI) ile servislerin eklenmesi
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EfArticleDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IWriterService, WriterManager>();
builder.Services.AddScoped<IWriterDal, EfWriterDal>();
builder.Services.AddScoped<INewsLetterService, NewsLetterManager>();
builder.Services.AddScoped<INewsLetterDal, EfNewsLetter>();
builder.Services.AddScoped<IAdminService, AdminManager>();
builder.Services.AddScoped<IAdminDal, EfAdminDal>();

builder.Services.AddSession();

// Authentication ve Authorization ayarlar�
builder.Services.AddAuthentication("CookieAuth")
	.AddCookie("CookieAuth", options =>
	{
		options.LoginPath = "/Login/Index"; // Oturum a�ma sayfas�
		options.AccessDeniedPath = "/ErrorPage/Error404"; // Yetkisiz eri�im sayfas�
	});

builder.Services.AddAuthorization(); // Yetkilendirme sistemi

var app = builder.Build();

// Hata sayfas� y�nlendirmeleri
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

// Orta katmanlar�n eklenmesi
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
	  name: "default",
	  pattern: "{controller=Blog}/{action=Index}/{id?}"
  );

	
});

// Varsay�lan y�nlendirme ayarlar�


app.Run();



