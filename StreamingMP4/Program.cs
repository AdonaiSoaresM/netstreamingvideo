var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddResponseCompression(options =>
{
    string[] mimeTypes = new string[] { "video/mp4" };
    options.EnableForHttps = true;
    options.MimeTypes = mimeTypes;
});

var app = builder.Build();

app.UseResponseCompression();
// Configure the HTTP request pipeline.
app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().DisallowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();