using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WheaterAPI.Repository
{
    public class BaseRepository
    {
        public static SqlConnection conn;
        private IConfiguration _configuration;
        private static BaseRepository _singleton;
        
        public SqlConnection Instancia {
            get
            {
                if (_singleton == null)
                {
                    conn = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
                    _singleton = new BaseRepository(_configuration);
                }
                return conn;
            }
        }

        public BaseRepository(IConfiguration iconfig)
        {
            _configuration = iconfig;
        }
    }
}
