using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PontBascule.Data;
using PontBascule.Model;
using PontBascule.Model.DataAccess;

namespace PontBascule;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

		builder.Services.AddDbContextFactory<ApplicationDbContext>(
			(DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));



		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<IAchatCrud, AchatCrud>();
		return builder.Build();
	}
}
