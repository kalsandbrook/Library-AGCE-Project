using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace A_Level_Library_Project
{
    public class DataAccess
    {
        public List<User> GetUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Library")))
            {
                return connection.Query<User>("SELECT * FROM Users;").ToList();
            }
        }
        public List<Books> GetBooks()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Library")))
            {
                return connection.Query<Books>("SELECT * FROM Books;").ToList();
            }
        }
        public bool CheckLogin(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Library")))
            {
                var result = connection.Query<bool>("dbo.CheckLogin @username, @password", new { Username = username, Password = password });
                return result.First();
            }
        }

        internal void AddUser(string forename, string surname, string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("Library")))
            {
                User newUser = new User { FirstName = forename.ToUpper(), LastName = surname.ToUpper(), Username = username, Password = password };
                List<User> user = new List<User>{ newUser };
                connection.Execute("dbo.AddUser @FirstName, @LastName, @Username, @Password", user);
            }
        }
    }
}
