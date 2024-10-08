using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Crime_Report.Utility
{
    internal class DbConnectionUtil
    {
        private static IConfiguration _iconfiguration;

        static DbConnectionUtil()
        {
            GetConnString();
        }

        public static string GetConnString()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _iconfiguration = builder.Build();

            var connectionString = _iconfiguration.GetConnectionString("AppSettingsDbContext");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'AppSettingsDbContext' is not configured in appsettings.json.");
            }

            return connectionString;
        }
    }
}
