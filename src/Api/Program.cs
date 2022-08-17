using Api;
using Repository;
using Repository.Data;
using Repository.DatabaseAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();
builder.Services
    .AddSingleton<IDatabaseAccess, DatabaseAccess>()
    .AddSingleton<IBookRepository, BookRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection();
app.ConfigureEndPoints();
app.Run();