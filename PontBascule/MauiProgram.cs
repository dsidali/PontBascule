using System.Reflection;
using Windows.Security.Cryptography.Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PontBascule.Data;
using PontBascule.Model;
using PontBascule.Model.DataAccess;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
          var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");




        //   var connectionString  = "data source = 127.0.0.1; initial catalog = PontBasculeDB2; user id = sa; password = Informatik.1; Trust Server Certificate = true; MultipleActiveResultSets = True; ";


        //	builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        builder.Services.AddDbContextFactory<ApplicationDbContext>(
   (DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));



		builder.Services.AddSingleton<WeatherForecastService>();
		//builder.Services.AddScoped<IAchatCrud, AchatCrud>();
		builder.Services.AddTransient<AchatsService>();
		builder.Services.AddTransient<BusinessLayer>();
		return builder.Build();
	}
}
