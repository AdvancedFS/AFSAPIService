using AFSAPIService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<IRatingRepository, RatingRepository>();

builder.Services.AddScoped<IReportIssueRepository, ReportIssueRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

