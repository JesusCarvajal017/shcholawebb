using Api.ServicesCollection;
using Entity.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMapper(); // mapper
builder.Services.AddViewAuthApi();

//SQLServer
builder.Services.AddAuthorization();
builder.Services.AddDataAccessFactory("PgAdmin", builder.Configuration);

builder.Services.AddServicesApp();

builder.Services.AddJwtConfig(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPermissionCorsApp(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//SeedService.Initialize(app.Services);

// permite usar los cords
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
