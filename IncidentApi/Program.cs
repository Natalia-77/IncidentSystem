using Domain;
using IncidentApi.Profiles;
using IncidentApi.Repository.Contracts;
using IncidentApi.Repository.ImplementRepository;
using IncidentApi.WrapperRepository.Contracts;
using IncidentApi.WrapperRepository.Implementation;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<AppDbContext>((DbContextOptionsBuilder options) =>

               options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped <IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IWrapperRepo, WrapperRepo>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(ContactProfile));
builder.Services.AddAutoMapper(typeof(AccountProfile));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});

builder.Services.AddSwaggerGen((SwaggerGenOptions o) => {

    o.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "Incident",
        Version = "v1",
        Title = "Incident system API example"
    });
   
});

builder.Services.AddCors();

var app = builder.Build();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseSwagger();

app.UseSwaggerUI((SwaggerUIOptions c) =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incident system");
});

app.UseStaticFiles();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.Run();
