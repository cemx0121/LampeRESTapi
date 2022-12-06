var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://zealand.dk").AllowAnyHeader().AllowAnyMethod()
        );
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        );
    options.AddPolicy("AllowOnlyGetAndPut",
        builder => builder.AllowAnyOrigin().AllowAnyHeader().WithMethods("GET", "PUT")
        );
    options.AddPolicy("AllowOnlySpecificOriginAndMethods",
        builder => builder.WithOrigins("http://zealand.dk").AllowAnyHeader().WithMethods("GET", "POST")
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// Link til API i browser: https://lamperestapi.azurewebsites.net/api/help
app.UseSwagger();
app.UseSwaggerUI(c =>
{

    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lamp API v1.0");
    c.RoutePrefix = "api/help";
});

app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
