using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.DbContexts;
using CK.Central.Core.DataObjects.Model;
using CK.Central.Core.Domain.DataObjects.CMS.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Serilog.Events;
using Serilog;
using System.Text;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.Services;
using Microsoft.OpenApi.Models;
using CK.Central.Core.CMS.Auth.Abstract.Services;
using CK.Central.Core.CMS.Auth.Services;
using Microsoft.AspNetCore.RateLimiting;
using MediatR;
using CK.Central.Core.CMS.Auth.Abstract.Repositories;
using CK.Central.Core.CMS.Auth.Repositories;

namespace CK.Central.API.CMS.Auth
{
    public static class InitialRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<ApplicationUserModel, ApplicationRoleModel>(options =>
            {
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 12;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<ApplicationRoleModel>()
            .AddSignInManager()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthorization();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JwtTokenSettings:ValidAudience"],
                    ValidIssuer = configuration["JwtTokenSettings:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenSettings:SymmetricSecurityKey"]))
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CK.Central.API.CMS.Auth", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                        },
                        new string[] {}
                    }
                });
            });

            services.Configure<JwtSettingsModel>(configuration.GetSection("JwtTokenSettings"));

            return services;
        }

        public static IServiceCollection AddCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RedisSettingsModel>(configuration.GetSection("RedisServer"));

            return services;
        }

        public static IServiceCollection AddDatabaseServer(this IServiceCollection services, IConfiguration configuration)
        {
            var settingsPath = Path.Combine(Directory.GetCurrentDirectory());

            if (!string.IsNullOrEmpty(settingsPath))
            {
                var appsettings = new ConfigurationBuilder().SetBasePath(settingsPath).AddJsonFile("appsettings.json", false).Build();

                services.AddDbContext<MasterDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(appsettings.GetConnectionString("MasterPgsqlDbConnection")));
                services.AddDbContext<SlaveDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(appsettings.GetConnectionString("SlavePgsqlDbConnection")));
                services.AddDbContext<IUnitOfWork, MasterDbContext>(options => options.UseNpgsql(appsettings.GetConnectionString("MasterPgsqlDbConnection")));
                services.AddDbContext<AuthDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(appsettings.GetConnectionString("MasterPgsqlDbConnection")));
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.Configure<ConnectionStringSettingsModel>(configuration.GetSection("ConnectionStrings"));
            services.Configure<MongoDbSettingsModel>(configuration.GetSection("MongoDbServer"));
            services.Configure<ElasticsearchSettingsModel>(configuration.GetSection("ElasticsearchServer"));

            return services;
        }

        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<DbContext, MasterDbContext>();
            services.AddScoped<DbContext, SlaveDbContext>();
            services.AddScoped<IMemoryCache, MemoryCache>();
            services.AddScoped<IMasterDbContext, MasterDbContext>();
            services.AddScoped<ISlaveDbContext, SlaveDbContext>();
            services.AddScoped<IElasticsearchCMSAuthService, ElasticsearchCMSAuthService>();
            services.AddScoped<IMemoryCacheCMSAuthService, MemoryCacheCMSAuthService>();
            services.AddScoped<IRedisCacheCMSAuthService, RedisCacheCMSAuthService>();
            services.AddScoped<IRabbitMQProducerCMSAuthService, RabbitMQProducerCMSAuthService>();
            services.AddScoped<IAppSettingService, AppSettingService>();
            services.AddScoped<IJWTokenService, JWTokenService>();
            services.AddScoped<IMediator, Mediator>();

            services.AddScoped<IIdentityRoleClaimRepository, IdentityRoleClaimRepository>();
            services.AddScoped<IIdentityRoleRepository, IdentityRoleRepository>();
            services.AddScoped<IIdentityUserClaimRepository, IdentityUserClaimRepository>();
            services.AddScoped<IIdentityUserLoginRepository, IdentityUserLoginRepository>();
            services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();
            services.AddScoped<IIdentityUserRoleRepository, IdentityUserRoleRepository>();
            services.AddScoped<IIdentityUserTokenRepository, IdentityUserTokenRepository>();

            return services;
        }

        public static IServiceCollection AddEventDriven(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQSettingsModel>(configuration.GetSection("RabbitMQServer"));

            return services;
        }

        public static IServiceCollection AddRateLimiter(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RateLimiterSettingsModel>(configuration.GetSection("RateLimiterSettings"));

            var rateLimiterSettings = new RateLimiterSettingsModel();
            configuration.GetSection(RateLimiterSettingsModel.RateLimiterSettings).Bind(rateLimiterSettings);

            services.AddRateLimiter(options => options.AddSlidingWindowLimiter(
                policyName: RateLimiterSettingsModel.PolicyNameSliding,
                options =>
                {
                    options.PermitLimit = rateLimiterSettings.PermitLimit;
                    options.Window = TimeSpan.FromSeconds(rateLimiterSettings.Window);
                    options.SegmentsPerWindow = rateLimiterSettings.SegmentsPerWindow;
                    options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    options.QueueLimit = rateLimiterSettings.QueueLimit;
                }));

            return services;
        }

        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
        (context, loggerConfiguration) =>
        {
            var env = context.HostingEnvironment;
            loggerConfiguration.MinimumLevel.Information()
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .WriteTo.Debug()
                .WriteTo.Console();
            if (context.HostingEnvironment.IsDevelopment())
            {
                loggerConfiguration.MinimumLevel.Override("CK-Central-CMS-Auth", LogEventLevel.Debug);
            }

            var elasticUrl = context.Configuration.GetValue<string>("ElasticsearchServer:Uri");
            if (!string.IsNullOrEmpty(elasticUrl))
            {
                loggerConfiguration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elasticUrl))
                    {
                        AutoRegisterTemplate = true,
                        InlineFields = true,
                        IndexFormat = "CK-Central-CMS-Auth-Logs-{0:yyyy.MM.dd}",
                        NumberOfReplicas = 2,
                        NumberOfShards = 2
                    });
            }
        };
    }
}
