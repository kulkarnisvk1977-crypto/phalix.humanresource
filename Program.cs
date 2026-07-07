using HumanResource.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Register Core Framework Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configure Environment-Specific Databases
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
}
else if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));
}

// 3. Register Custom Application Services
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// 4. Seed / Prepare Databases Safe Execution
// (Runs once right after build, independent of the middleware pipeline)
PrepDb.PrepPopulation(app, app.Environment.IsProduction());

// 5. Configure the HTTP Request Pipeline (Order Matters!)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Access via /swagger
}
else if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// 6. Security and Routing Middleware (Global)
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// 7. Map Endpoints (Global)
app.MapControllers();

app.Run();
