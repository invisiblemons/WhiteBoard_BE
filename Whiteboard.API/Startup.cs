using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;
using Whiteboard.Business.Service;
using Whiteboard.Data;
using Whiteboard.Data.Context;
using Whiteboard.Data.Repository;

namespace Whiteboard.API
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
            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = Configuration.GetConnectionString("Redis");
            });

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(Environment.CurrentDirectory, "whiteboardswd-firebase-adminsdk-woq29-7a1c89d5a9.json")),
            });


            //Fix possible object cycle
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            //firebase
            //services 
            //    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //        {
            //            var firebaseProjectName = Configuration["FireBaseProjectID"];
            //            options.Authority = "https://securetoken.google.com/" + firebaseProjectName;
            //            options.TokenValidationParameters = new TokenValidationParameters
            //            {
            //                ValidateIssuer = true,
            //                ValidIssuer = "https://securetoken.google.com/" + firebaseProjectName,
            //                ValidateAudience = true,
            //                ValidAudience = firebaseProjectName,
            //                ValidateLifetime = true
            //            };
            //        });
            var key = Encoding.ASCII.GetBytes(MyConstant.Secret);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Read the connection string from appsettings.
            string dbConnectionString = this.Configuration.GetConnectionString(Configuration["Environment"]);

            // Read the connection string from appsettings.
            services.AddDbContext<WhiteboardContext>(options =>
                options.UseSqlServer(dbConnectionString));

            services.AddDatabaseDeveloperPageExceptionFilter();

            //AddService
            services.AddScoped<IReviewerService, ReviewerService>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICampusService, CampusService>();
            services.AddScoped<ICriterionService, CriterionService>();
            services.AddScoped<IMajorService, MajorService>();
            services.AddScoped<IPictureForReviewService, PictureForReviewService>();
            services.AddScoped<IReviewCriterionService, ReviewCriterionService>();
            services.AddScoped<IUniversityService, UniversityService>();


            //AddRepository
            services.AddScoped<IReviewerRepository, ReviewerRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IAdminRespository, AdminRespository>();
            services.AddScoped<ICampusRepository, CampusRepository>();
            services.AddScoped<ICriterionRepository, CriterionRepository>();
            services.AddScoped<IMajorRepository, MajorRepository>();
            services.AddScoped<IPictureForReviewRepository, PictureForReviewRepository>();
            services.AddScoped<IReviewCriterionRepository, ReviewCriterionRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();

            //Register DBcontext for migration
            services.AddDbContext<WhiteboardContext>(options => options.UseSqlServer(dbConnectionString));

            // Register your regular repositories
            // services.AddScoped<IDiameterRepository, DiameterRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Whiteboard.API", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Whiteboard.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            //firebase
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
