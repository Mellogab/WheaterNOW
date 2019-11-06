using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WheaterAPI.Model;
using Dapper;

namespace WheaterAPI.Repository
{
    public class WheaterRepository : IRepository
    {
        public SqlConnection conn;
        
        public WheaterRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
        }

        public List<Wheater> GetWheaters()
        {
            return conn.Query<Wheater>("SELECT * FROM [Wheater_W]").ToList();
        }

        public List<Wheater> GetWheaterByCity(Wheater wheater)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@City", wheater.City);

            return conn.Query<Wheater>("SELECT * FROM [Wheater_W] WHERE City = @City").ToList();
        }
        public List<Wheater> GetWheaterBetweenTemperatures(Wheater wheater)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@MinTemperature", wheater.MinTemperature);
            vParams.Add("@MaxTemperature", wheater.MaxTemperature);

            return conn.Query<Wheater>("SELECT * FROM [Wheater_W] WHERE MinTemperature >= @MinTemperature AND MaxTemperature <= @MaxTemperature").ToList();
        }
        public List<string> GetCitiesMonitored()
        {
            return conn.Query<string>("SELECT DISTINCT City FROM [Wheater_W]").ToList();
        }
    }
}
