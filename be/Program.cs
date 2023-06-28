using be.Models;
using be.Repositories.ExportRepository;
using be.Repositories.IssueRepository;
using be.Services.ExportService;
using be.Repositories.BaseRepository;
using be.Repositories.ComponentRepository;
using be.Repositories.IProjectRepositoty;
using be.Repositories.IssueRepository;
using be.Repositories.ProductRepository;
using be.Repositories.UserRepository;
using be.Services;
using be.Services.ComponentService;
using be.Services.IssueService;
using be.Services.ProductService;
using be.Services.ProjectService;
using be.Services.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text.Json.Serialization;
using be.Services.WatcherService;
using be.Repositories.WatcherRepository;
using be.Services.HistoryService;
using be.Repositories.HistoryRepository;
using be.Services.History;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<DbJiraCloneContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbJiraClone")));
builder.Services.AddCors();


var services = builder.Services;
services.AddScoped<IHistoryRepository, HistoryRepository>();
services.AddScoped<IHistoryService, HistoryService>();
//Export
services.AddScoped<IExportRepository, ExportRepository>();
services.AddScoped<IExportService, ExportService>();
//Issue
services.AddScoped<IIssueRepository, IssueRepository>();
services.AddScoped<IIssueService, IssueService>();
services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
//User
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IComponentService, ComponentService>();
builder.Services.AddScoped<IComponentRepository, ComponentRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IWatcherService, WatcherService>();
builder.Services.AddScoped<IWatcherRepository, WatcherRepository>();

builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();
//app.UseAuthentication();
app.MapControllers();

app.Run();
