using EightBitSaxLounge.Api.Services;
using EightBitSaxLounge.Api.Services.VentrisDualReverbParameters;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IVentrisDualReverbParameterService, VentrisDualReverbParameterService>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}