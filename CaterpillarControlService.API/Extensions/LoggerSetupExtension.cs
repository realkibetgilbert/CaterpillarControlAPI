﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Serilog;

namespace CaterpillarControlService.API.Extensions
{
    public static class LoggerSetupExtension
    {
        public static WebApplicationBuilder ConfigureSerilog(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();

            var filePath = builder.Configuration["Log_Path"];

            Log.Logger = new
              LoggerConfiguration().WriteTo.File(filePath,
              rollingInterval: RollingInterval.Day)
              .MinimumLevel.Warning()
              .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", Serilog.Events.LogEventLevel.Warning)

              .CreateLogger();

            return builder;
        }
    }
}
