using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.DbContext
{
    
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionStringTemplate=_configuration.GetConnectionString("DefaultConnection")!;
            string connectionStringValues = connectionStringTemplate.Replace("$MYSQL_HOST", Environment.GetEnvironmentVariable("MYSQL_HOST")).
            Replace("$MYSQL_DATABASE", Environment.GetEnvironmentVariable("MYSQL_DATABASE")).
            Replace("$MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER")).
            Replace("$MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD")).
            Replace("$MYSQL_PORT", Environment.GetEnvironmentVariable("MYSQL_PORT"));         
          
            //string connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            _connection = new MySqlConnection(connectionStringValues);
        }
        public IDbConnection DbConnection => _connection;
    }
}
