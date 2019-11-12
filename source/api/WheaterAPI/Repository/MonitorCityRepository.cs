using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WheaterAPI.Model;

namespace WheaterAPI.Repository
{
    public class MonitorCityRepository : IRepository
    {
        public SqlConnection conn;
        private MonitorCity _monitorCity;
        public IConfiguration _iconfig = null;
        public MonitorCityRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
        }

        public MonitorCityRepository(IConfiguration iconfig, MonitorCity monitorCity)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _monitorCity = monitorCity;
        }

        public void Add()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@CitySearched", _monitorCity.CitySearched);
            vParams.Add("@IdUser", _monitorCity.IdUser);

            conn.Query<MonitorCity>("INSERT INTO [MonitorCity_W](CitySearched,IdUser,Status,Message) VALUES(@CitySearched,@IdUser,NULL,NULL)", vParams).ToList();
        }

        public void Remove()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Id", _monitorCity.Id);

            conn.Query<MonitorCity>("DELETE FROM [MonitorCity_W] WHERE Id = @Id", vParams).ToList();
        }

        public void Update()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@CitySearched", _monitorCity.CitySearched);
            vParams.Add("@IdUser", _monitorCity.IdUser);
            vParams.Add("@Message", _monitorCity.Message);
            vParams.Add("@Status", _monitorCity.Status);

            conn.Query<MonitorCity>("UPDATE [MonitorCity_W] SET CitySearched = @CitySearched, IdUser = @IdUser, Message = @Message, Status = @Status WHERE Id = @Id", vParams).ToList();
        }

        public IEnumerable<object> GetAll()
        {
            return conn.Query<MonitorCity>("SELECT * FROM [MonitorCity_W]").ToList();
        }

        public object GetItemById()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Username", _monitorCity.CitySearched);

            return conn.Query<MonitorCity>("SELECT * FROM [MonitorCity_W] where CitySearched = @CitySearched", vParams).ToList();
        }
    }
}
