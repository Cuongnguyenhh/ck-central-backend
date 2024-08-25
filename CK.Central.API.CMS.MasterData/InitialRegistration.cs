using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.CMS.MasterData.Abstract.Services;
using CK.Central.Core.CMS.MasterData.DbContexts;
using CK.Central.Core.CMS.MasterData.Services;
using CK.Central.Core.DataObjects.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.AspNetCore.RateLimiting;
using CK.Central.Core.CMS.MasterData.Abstract.Repositories;
using CK.Central.Core.CMS.MasterData.Repositories;
using MongoDB.Driver;

namespace CK.Central.API.CMS.MasterData
{
    public static class InitialRegistration
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CK.Central.API.CMS.MasterData", Version = "v1" });
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
            services.AddScoped<IMasterDbContext, MasterDbContext>();
            services.AddScoped<ISlaveDbContext, SlaveDbContext>();
            services.AddScoped<IMongoClient, MongoClient>();
            services.AddScoped<IMemoryCache, MemoryCache>();
            services.AddScoped<IElasticsearchCMSMasterDataService, ElasticsearchCMSMasterDataService>();
            services.AddScoped<IMemoryCacheCMSMasterDataService, MemoryCacheCMSMasterDataService>();
            services.AddScoped<IRedisCacheCMSMasterDataService, RedisCacheCMSMasterDataService>();
            services.AddScoped<IRabbitMQProducerCMSMasterDataService, RabbitMQProducerCMSMasterDataService>();
            services.AddScoped<IAppSettingService, AppSettingService>();
            services.AddScoped<IJWTokenService, JWTokenService>();

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IDefinitionRepository, DefinitionRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IAuditHistoricalRepository, AuditHistoricalRepository>();

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
                loggerConfiguration.MinimumLevel.Override("CK-Central-CMS-Master-Data", LogEventLevel.Debug);
            }

            var elasticUrl = context.Configuration.GetValue<string>("ElasticsearchServer:Uri");
            if (!string.IsNullOrEmpty(elasticUrl))
            {
                loggerConfiguration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elasticUrl))
                    {
                        AutoRegisterTemplate = true,
                        InlineFields = true,
                        IndexFormat = "CK-Central-CMS-Master-Data-Logs-{0:yyyy.MM.dd}",
                        NumberOfReplicas = 2,
                        NumberOfShards = 2
                    });
            }
        };
    }
}
