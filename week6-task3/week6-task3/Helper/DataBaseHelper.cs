using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace week6_task3.Helper
{
    public static class DataBaseHelper
    {
        public static string GetConnectionString()
        {
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSetting.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
