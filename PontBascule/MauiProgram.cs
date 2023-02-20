using System.Reflection;
using Windows.Security.Cryptography.Certificates;
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
     /*   builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");*/

		/*

     var jsonfile = "PontBascule.appsettings.json";
     var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MauiProgram)).Assembly;
	 var stream = assembly.GetManifestResourceStream(jsonfile);
     builder.Configuration.AddJsonStream(stream);*/
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");







		builder.Services.AddDbContextFactory<ApplicationDbContext>(
			(DbContextOptionsBuilder options) => options.UseSqlServer("data source=127.0.0.1;initial catalog=PontBasculeDB2;user id=sa;password=Informatik.1;Trust Server Certificate=true;MultipleActiveResultSets=True;"));



		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddScoped<IAchatCrud, AchatCrud>();
        builder.Services.AddTransient<AchatCrud>();
		return builder.Build();
	}
}
