using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public static class Configuration
    {
        //public static string DatabasePath = @"database.db";
        public static string DatabasePath = @"C:\Users\Portable\test\database.db";

        private static string _connectionStringPattern = "Data Source={0};Version=3;";

        public static string GetConnectionString()
        {
            return string.Format(_connectionStringPattern, DatabasePath);
        }
    }
}
