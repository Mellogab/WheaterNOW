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

        public MonitorCityRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
        }

        public List<MonitorCity> GetCities()
        {
            return conn.Query<MonitorCity>("SELECT * FROM [MonitorCity_W]").ToList();
        }

        public List<MonitorCity> GetCityByName(MonitorCity city)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Username", city.CitySearched);
            
            return conn.Query<MonitorCity>("SELECT * FROM [MonitorCity_W] where CitySearched = @CitySearched", vParams).ToList();
        }

        public List<MonitorCity> Register(MonitorCity city)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@CitySearched", city.CitySearched);
            vParams.Add("@IdUser", city.IdUser);

            return conn.Query<MonitorCity>("INSERT INTO [MonitorCity_W](CitySearched,IdUser,Status,Message) VALUES(@CitySearched,@IdUser,NULL,NULL)", vParams).ToList();
        }

        public List<MonitorCity> Update(MonitorCity city)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@CitySearched", city.CitySearched);
            vParams.Add("@IdUser", city.IdUser);
            vParams.Add("@Message", city.Message);
            vParams.Add("@Status", city.Status);

            return conn.Query<MonitorCity>("UPDATE [MonitorCity_W] SET CitySearched = @CitySearched, IdUser = @IdUser, Message = @Message, Status = @Status WHERE Id = @Id", vParams).ToList();
        }

        public List<MonitorCity> Delete(int Id)
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Id", Id);

            return conn.Query<MonitorCity>("DELETE FROM [MonitorCity_W] WHERE Id = @Id", vParams).ToList();
        }

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public void Remove()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<object> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public object GetItemById()
        {
            throw new System.NotImplementedException();
        }
    }
}
