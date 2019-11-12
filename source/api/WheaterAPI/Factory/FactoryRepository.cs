using WheaterAPI.Repository;
using WheaterAPI.Model;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace WheaterAPI.Factory
{
    public class FactoryRepository
    {
        private SqlConnection conn;
        public IConfiguration _iconfig = null;
        object _params;

        public FactoryRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _iconfig = iconfig;
        }

        public FactoryRepository(IConfiguration iconfig, object parameters)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _iconfig = iconfig;
            _params = parameters;
        }

        public IRepository CreateFactoryRepository(int repositoryType)
        {
            switch (repositoryType)
            {
                case (int) Enums.Repository.User:
                    return new UserRepository(_iconfig, (User)_params);

                case (int) Enums.Repository.MonitorCiry:
                    return new MonitorCityRepository(_iconfig, (MonitorCity)_params);

                case (int) Enums.Repository.Wheater:
                    return new WheaterRepository(_iconfig, (Wheater)_params);
                    
                default:
                    return new UserRepository(_iconfig);
            }
        }
    }
}
