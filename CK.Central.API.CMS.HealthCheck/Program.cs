using Serilog;
using CK.Central.API.CMS.HealthCheck;
using CK.Central.Core.CMS.HealthCheck.Mapping;
using CK.Central.Core.DataObjects.Dto;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Host.UseSerilog(InitialRegistration.ConfigureLogger);
builder.Services.AddAuth(builder.Configuration);
builder.Services.AddDatabaseServer(builder.Configuration);
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddEventDriven(builder.Configuration);
builder.Services.AddCaching(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddRateLimiter(builder.Configuration);
builder.Services.AddHealthCheck(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddProblemDetails();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
});

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStatusCodePages();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseAuthentication();
app.UseAuthorization();

app.UseRateLimiter();

app.UseExceptionHandler(
    options =>
    {
        options.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
            if (null != exceptionObject)
            {
                var dto = BaseResponseDto.Fail(exceptionObject.Error.Message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(dto)).ConfigureAwait(false);
            }
        });
    });

app.MapControllers();

app.Run();