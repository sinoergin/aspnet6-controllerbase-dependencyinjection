var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyDatabase();
builder.Services.AddMyRepositories();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var services = app.Services.CreateAsyncScope())
{
    var context = services.ServiceProvider.GetRequiredService<MyDatabaseContext>();
    await context.Database.EnsureCreatedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
