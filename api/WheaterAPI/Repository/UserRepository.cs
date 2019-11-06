using Microsoft.Extensions.Configuration;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WheaterAPI.Model;

namespace WheaterAPI.Repository
{
    public class UserRepository : IRepository
    {
        private SqlConnection conn;
        private User _user;
        private UserBase _userBase;
        public IConfiguration _iconfig = null;
        
        public UserRepository(IConfiguration iconfig)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _iconfig = iconfig;
        }

        public UserRepository(IConfiguration iconfig, User user) 
        {
            conn = new BaseRepository(iconfig).Instancia;
            _iconfig = iconfig;
            _user = user;
        }

        public UserRepository(IConfiguration iconfig, UserBase user)
        {
            conn = new BaseRepository(iconfig).Instancia;
            _iconfig = iconfig;
            _userBase = user;
        }

        public List<User> GetUsers()
        {
            return conn.Query<User>("SELECT * FROM [User_W]").ToList();
        }

        public List<User> GetUserByLogin()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Username", _userBase.Username);
            vParams.Add("@Password", _userBase.Password);

            return conn.Query<User>("SELECT * FROM [User_W] where Username = @Username and Password = @Password", vParams).ToList();
        }

        public List<User> Register()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Name", _user.Name);
            vParams.Add("@Email", _user.Email);
            vParams.Add("@Username", _user.Username);
            vParams.Add("@Password", _user.Password);

            return conn.Query<User>("INSERT INTO [User_W](Name,Email,Username,Password) VALUES(@Name,@Email,@Username,@Password)", vParams).ToList();
        }

        public List<User> Update()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Name", _user.Name);
            vParams.Add("@Email", _user.Email);
            vParams.Add("@Username", _user.Username);
            vParams.Add("@Password", _user.Password);

            return conn.Query<User>("UPDATE [USER_W] SET Name = @Name, Email = @Email, Username = @Username, Password = @Password WHERE Id = @Id", vParams).ToList();
        }
        public List<User> Delete()
        {
            DynamicParameters vParams = new DynamicParameters();
            vParams.Add("@Id", _user.Id);

            return conn.Query<User>("DELETE FROM [User_W] WHERE Id = @Id", vParams).ToList();
        }
    }
}

