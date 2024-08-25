using CK.Central.Core.DataObjects.Model;
using Microsoft.EntityFrameworkCore;
using CK.Central.Core.POS.GrabMart.Stock.DbContexts;
using CK.Central.Core.Abstract.Repositories;
using Microsoft.Extensions.Caching.Memory;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Services;
using CK.Central.Core.POS.GrabMart.Stock.Services;
using Serilog.Events;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Serilog.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using CK.Central.Core.Abstract.Services;
using CK.Central.Core.Services;
using System.Reflection;
using CK.Central.Core.POS.GrabMart.Stock.Commands;
using MediatR;
using CK.Central.Core.POS.GrabMart.Stock.Abstract.Repositories;
using CK.Central.Core.POS.GrabMart.Stock.Repositories;
using Microsoft.AspNetCore.RateLimiting;

namespace CK.Central.API.POS.GrabMart.Stock
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CK.Central.API.POS.GrabMart.Stock", Version = "v1" });
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
            services.AddScoped<IMemoryCache, MemoryCache>();
            services.AddScoped<IElasticsearchPOSGrabMartStockService, ElasticsearchPOSGrabMartStockService>();
            services.AddScoped<IRedisCachePOSGrabMartStockService, RedisCachePOSGrabMartStockService>();
            services.AddScoped<IKafkaProducerPOSGrabMartStockService, KafkaProducerPOSGrabMartStockService>();
            services.AddScoped<IAppSettingService, AppSettingService>();
            services.AddScoped<IJWTokenService, JWTokenService>();
            services.AddScoped<IMediator, Mediator>();

            services.AddScoped<IStockItemRepository, StockItemRepository>();

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(UpdateOrderCommandHandler).GetTypeInfo().Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CancelOrderCommandHandler).GetTypeInfo().Assembly));

            return services;
        }

        public static IServiceCollection AddEventDriven(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KafkaSettingsModel>(configuration.GetSection("KafkaServer"));

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
                loggerConfiguration.MinimumLevel.Override("CK-Central-POS-GrabMart-Stock", LogEventLevel.Debug);
            }

            var elasticUrl = context.Configuration.GetValue<string>("ElasticsearchServer:Uri");
            if (!string.IsNullOrEmpty(elasticUrl))
            {
                loggerConfiguration.WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(elasticUrl))
                    {
                        AutoRegisterTemplate = true,
                        InlineFields = true,
                        IndexFormat = "CK-Central-POS-GrabMart-Stock-Logs-{0:yyyy.MM.dd}",
                        NumberOfReplicas = 2,
                        NumberOfShards = 2
                    });
            }
        };
    }
}
