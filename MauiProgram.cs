﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AM.Controllers;
using Radzen;

namespace AM;

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
        // 🔹 Cargar appsettings.json desde Resources/Raw/
        using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

        builder.Configuration.AddConfiguration(config);

        // Configurar Entity Framework
        builder.Services.AddDbContext<dbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

        // Registrar IDbContextFactory para DbContext
        builder.Services.AddDbContextFactory<dbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddRadzenComponents();
        builder.Services.AddScoped<NotificationService>();
        // Registrar servicios
        builder.Services.AddScoped<IArmamentoController,ArmamentoController>();
        builder.Services.AddScoped<IMunicionController,MunicionController>();


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
