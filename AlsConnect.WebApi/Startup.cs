using AlsConnect.Application.Implementations;
using AlsConnect.Application.Interfaces;
using AlsConnect.Data.EF;
using AlsConnect.Data.EF.Entities;
using AlsConnect.Data.EF.IRepository;
using AlsConnect.Data.EF.Repositories;
using AlsConnect.Infrastructure.Interfaces;
using AlsConnect.Utilities.Settings;
using AutoMapper;
using CorePush.Apple;
using CorePush.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace AlsConnect.WebApi
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
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(@"
{
  ""type"": ""service_account"",
  ""project_id"": ""rn-complete-guide-6c06b"",
  ""private_key_id"": ""9a7cabc13541356ebc1cc19bf7c09ea0b8b29522"",
  ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvgIBADANBgkqhkiG9w0BAQEFAASCBKgwggSkAgEAAoIBAQDJWlm7NPzHoW26\n/FvwUvaoJJz0sQCzww7RVSPjoBQBCDvHrJv8cwtLGZWE/6rqd0ZOYGx5+CuLMQJO\nz1ED9O6BsKFfZQhaQAUE0trJV4yqZfG0Sq13no1YwrsjzYl+2z2HFkRGPqeKwjOr\nhK+z8WdKm4zmiOpSAQs1MrmzCLmP5OkLfr21tB3mRUh94lFictOnw/j0E8P0qv36\nDlWDib4QZiemaxfo1Uh7Tl9cOygQ6GwHsnGQTq1Mn/eHh9DvHdw4gu1UF8sx0g/d\nRb0AFEHhxTnwKNRNzCmWbxTkZ4NEh12pADpcOQu3BNKtz1f5c0lmprj7QEUE5Qvw\nmrh/ZR0BAgMBAAECggEAANFQOzeBPcXI6mkXLfwGQqNIbGFyH2i/vQefmk9meWUZ\nSguoQ/+LGJJZZjV8EhDrLQsM8bdZZOqtZ9jFa1LRq57mHtssDCLFqnH5P7dOa8w3\nbawedXWEPSuoQyJU6DoXbz6exxq+xyxX9Z63sG8+5EGKsk50xiG5NA15TdHvn/cU\nB4gGRImkjt8J6YG3F1XDAalI1dmw4r/GHpTlGqpJiycmoEgV2I7yrPY27NXQ5O/S\n28ljGDap7/REdvo1ul77kWxdaJpi5ks3M80D6mekd8N/KGdX13Z2Ko6lSzErEPoU\nR8W0KhV2hGli7SBSTmiThWIv7h0JV1cS8BFvLLxsuQKBgQDoJeRw+B2PfFAIBIRt\nLa51eHyKJvazonO5cu1/OZ4uTsEzDLPkeqHyeiDj/JXpowBJLk3enGZxF4uLAxO4\nykTIbIfRWUfbM7oCRfOQTp90YyRBzG7yUEUBNdsh9vMU9C50FFCuDVaWj3xx4csZ\nQXR/htArtRaSe3TjhjHefXT8CQKBgQDeCndC8OXyFTaDKnv6hfQEUOhxb+YgIXvQ\nJnAjydgfJSPJBEoERtaknGX8OkIP5GDRVnN6ckaaH/XW8EPMjX+N0J1cOJMXYS9D\nkJ5SSUTT1nDydrGXJQl/qBBN/QC/dZpwRucpbmLmyR0JIG4f9JdTePL9DXCQoF27\n0ZT89H7HOQKBgQDlUkEmg0KYMgHQ2b2DKEQVEK9dvX2oF4rfn7MSIXWrYuqgpiSy\nR53grFn/PM1OHVGz+MS9aZwcjViwOprpyQ1HO0azO9GqrJ9LjZQ7ch871o/DW9Ih\nFcAEoRHVrF+VzFxzGHpWZSCq3BTfXl/FlA4jx6Wt91XT35apBzAOC7pbGQKBgEzD\nL4HsCIMNxF/KUzxEDR1k30dAWT2odcZ7U297+4Sg8WMwYWpjFxennjZ56ZbW7IXS\nrm+ZjEECZZpeTAIutPdRNOXKBUgi6BUirSljfTEDRN7+G91WB5ejgaeEnTqTrMW+\nLXKMYBLLWodqN8hCZgKMoOzNNao6Vs104l4lJKM5AoGBAIVv8Xm7ibbCGmNUsDC8\nCxalChPLV10xlfHvx7rTBcwdhr+gHUjv+n59/++g8PYc/QbetCi7DdkYoYGn/WBJ\nDiHm3NoD0bsESEzY0HFYuLgR6FWnpJnLnJss4yos92FsYFXRECbiPrdWj2+PA7dB\nthiu88x2cODSJREqn5TxwstA\n-----END PRIVATE KEY-----\n"",
  ""client_email"": ""firebase-adminsdk-506sq@rn-complete-guide-6c06b.iam.gserviceaccount.com"",
  ""client_id"": ""108749493970368553217"",
  ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
  ""token_uri"": ""https://oauth2.googleapis.com/token"",
  ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
  ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-p9qjv%40nghichcode-vn.iam.gserviceaccount.com""
}
                    ")
                // Credential = GoogleCredential.FromFile(
                //     _virtualFileProvider.GetFileInfo("/MasterDataModule/Resources/service_account.json").PhysicalPath
                // )
            });
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("CoreApp.Data.EF")));
            //services.AddDbContext<MainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));
            //services.AddDbContext<HermesDBContext>(options =>
            //    options.UseOracle(Configuration.GetConnectionString("HermesConnection")));
            services.AddAutoMapper();
            services.AddIdentity<AppUser, AppRole>()
                 .AddEntityFrameworkStores<AppDbContext>()
                 .AddDefaultTokenProviders();

            services.AddSingleton(Mapper.Configuration);
            services.AddTransient<INotificationService, NotificationService>();
            services.AddHttpClient<FcmSender>();
            services.AddHttpClient<ApnSender>();
            var appSettingsSection = Configuration.GetSection("FcmNotification");
            services.Configure<FcmNotificationSetting>(appSettingsSection);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(EFRepository<,>));
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            //services.AddTransient<IVCTRepository, VCTRepository>();
            //services.AddTransient<IFLUPRepository, FLUPRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IProductTagRepository, ProductTagRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            //Service
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            //services.AddTransient<IVCTService, VCTService>();
            //services.AddTransient<IFLUPService, FLUPService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger API CORE", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
            services.AddControllers();
            //services.AddControllersWithViews();
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

            app.UseAuthorization();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger eShopSolution V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
