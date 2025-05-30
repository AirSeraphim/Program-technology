using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Application.Services;
using SortingAndAnalysis.Infrastructure.Data;
using SortingAndAnalysis.Domain.Interfaces;
using SortingAndAnalysis.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контроллеров
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAnalysisTaskRepository, AnalysisTaskRepository>();

// Добавление контроллера анализа изображений
builder.Services.AddScoped<IImageAnalysisService, ImageAnalysisService>();
builder.Services.AddScoped<IApplicationImageService, ApplicationImageService>();

// фоновый консюмер задач
builder.Services.AddSingleton<IImageTaskProducer, ImageTaskProducer>();
builder.Services.AddHostedService<BackgroundImageWorker>();

// Регистрация контекста БД
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
	
// Регистрация репозиториев
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAnalysisTaskRepository, AnalysisTaskRepository>();

// Domain services
builder.Services.AddScoped<DomainBookService>();

// Application services
builder.Services.AddScoped<IApplicationBookService, ApplicationBookService>();

var app = builder.Build();

// Initialize database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();