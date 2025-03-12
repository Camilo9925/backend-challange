using Challenge.Application.Services;
using Challenge.Application.Validator;
using Challenge.Infrastructure.Context;
using Challenge.Infrastructure.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<MongoDb>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string connectionString = configuration.GetValue<string>("Mongo:MongoConnectionString");
    string databaseName = configuration.GetValue<string>("Mongo:MongoDataBase");
    return new MongoDb(connectionString, databaseName);
});
builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddValidatorsFromAssemblyContaining<InputToolValidator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
