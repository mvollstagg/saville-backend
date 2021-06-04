using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediaBalansSaville.Data.DAL;
using MediaBalansSaville.Core;
using MediaBalansSaville.Data;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using Microsoft.AspNetCore.Authentication.Cookies;
using MediaBalansSaville.Services.Utilities;

namespace MediaBalansSaville.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(opt =>
            {
                opt.Providers.Add<GzipCompressionProvider>();
                opt.EnableForHttps = true;
            });
            services.Configure<GzipCompressionProviderOptions>(options => options.Level =
            CompressionLevel.Fastest);
            
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddDistributedMemoryCache();
            
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddDbContext<ApplicationDbContext>(options => options.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning))
                                                                          .UseSqlServer(Configuration.GetConnectionString("Connect")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<ILangService, LangService>();
            services.AddTransient<ISeoService, SeoService>();
            services.AddTransient<IReceiptService, ReceiptService>();
            services.AddTransient<IReceiptPhotoService, ReceiptPhotoService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISiteSettingsService, SiteSettingsService>();
            services.AddTransient<IAboutSettingservice, AboutSettingservice>();
            services.AddTransient<ILetterService, LetterService>();
            services.AddTransient<IExportationService, ExportationService>();
            services.AddTransient<ICategoryLangService, CategoryLangService>();
            services.AddTransient<IFAQService, FAQService>();
            services.AddTransient<IPomegranateService, PomegranateSettingsService>();
            services.AddTransient<IImage, Image>();                 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { 
                options.AccessDeniedPath = "/cms/hesab/giris"; 
                options.LoginPath = "/cms/hesab/giris"; 
                options.ExpireTimeSpan = TimeSpan.FromHours(1); 
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddHttpContextAccessor();
            services.AddMvc().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            var cookiePolicyOptions = new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
            };
            app.UseCookiePolicy(cookiePolicyOptions);
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "{controller=Account}/{action=Login}");
            });
        }
    }
}
