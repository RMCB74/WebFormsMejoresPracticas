using Serilog;

using System.Configuration;

using System.IO;


namespace WebFormsMejoresPracticas.Infrastructure.Logging
{
    public static class LoggerConfig
    {
        public static void Configure()
        {
            var logPath = ConfigurationManager
                .AppSettings["LogPath"];

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File(
                    Path.Combine(logPath, "app-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 30)
                .CreateLogger();
        }
    }
}

//namespace WebFormsMejoresPracticas.Infrastructure.Logging
//{
//    public static class LoggerConfig
//    {
//        public static void Configure()
//        {
//            Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Information()
//                //.WriteTo.File(
//                //    "Logs/app-.log",
//                //    rollingInterval: RollingInterval.Day,
//                //    retainedFileCountLimit: 30)
//                .CreateLogger();
//        }
//    }
//}