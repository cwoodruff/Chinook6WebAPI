using Chinook.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConnectionProvider(builder.Configuration);
builder.Services.AddAppSettings(builder.Configuration);
builder.Services.ConfigureRepositories();
builder.Services.ConfigureSupervisor();
builder.Services.ConfigureValidators();
builder.Services.AddAPILogging();
builder.Services.AddCORS();
builder.Services.AddHealthChecks();
builder.Services.AddCaching(builder.Configuration);
//builder.Services.AddIdentity(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddApiExplorer();
builder.Services.AddSwaggerServices();
builder.Services.AddProblemDetail();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseCors();
//app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.Run();

public partial class Program { }
