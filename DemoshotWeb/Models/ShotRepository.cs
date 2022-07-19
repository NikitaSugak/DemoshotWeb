using Microsoft.Data.SqlClient;
using static DemoshotWeb.Models.IShotRepository;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;

namespace DemoshotWeb.Models
{
    public class ShotRepository : IShotRepository
    {

        string connectionString = null;
        public ShotRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Shot> GetShots()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Shot>("SELECT * FROM Users").ToList();
            }
        }

        public Shot Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Shot>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Shot shot)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
                db.Execute(sqlQuery, shot);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(Shot shot)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
                db.Execute(sqlQuery, shot);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }

}
