using Microsoft.EntityFrameworkCore;
using TestApplication.DataConnection;
using TestApplication.DataConnection.Services;
//using TestApplication.Migration;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddTransient<BooksService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublisherService>();
builder.Services.AddTransient<MemberServices>();
builder.Services.AddTransient<CategoryServices>();








builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseRouting();

app.UseCors(builder =>
{
    builder.WithOrigins("http://127.0.0.1:5500") // Replace with your frontend domain
           .AllowAnyHeader()
           .AllowAnyMethod();
});

AppDbInitializer.Seed(app);


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
