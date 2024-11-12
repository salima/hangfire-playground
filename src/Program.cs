using Hangfire;
using HangfirePlayground.Configurations;
using HangfirePlayground.Workers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfireConfiguration(builder.Configuration);

// Registra os jobs e JobConfigurations como serviços
builder.Services.AddSingleton<JobConfigurations>();
builder.Services.AddTransient<ConsolidacaoDadosRecurringJob>();
builder.Services.AddTransient<NotificacaoEmailJob>();

var app = builder.Build();

app.UseHangfireDashboard("/hangfire");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var jobConfigurations = app.Services.GetRequiredService<JobConfigurations>();
jobConfigurations.ConfigureJobs();

app.Run();
