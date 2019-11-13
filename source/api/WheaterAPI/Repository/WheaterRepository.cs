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
        private Wheater _wheater;
        public IConfiguration _iconfig = null;

        public WheaterRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
        }

        public WheaterRepository(IConfiguration iconfig, Wheater wheater)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _wheater = wheater;
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

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAll()
        {
            return conn.Query<Wheater>("SELECT * FROM [Wheater_W]").ToList();
        }

        public object GetItemById()
        {
            return conn.Query<Wheater>("SELECT * FROM [Wheater_W] WHERE City = @City").ToList();
        }
    }
}
