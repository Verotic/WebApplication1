using MySql.Data.MySqlClient;
using Dapper;
using WebApplication1.Data;
using WebApplication1.Models;
using MySqlX.XDevAPI.Common;

namespace WebApplication1.Repositories
{
    public class TeamRepositories : ITeamRepository
    {
        private MysqlConfiguration _connectionString;

        public TeamRepositories(MysqlConfiguration connectionString)
        { 
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<Team> createTeam(Team team)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO team(name) VALUES (@name); SELECT LAST_INSERT_ID()";
            team.Id = await db.QuerySingleAsync<int>(sql, new {team.nome});

            return team;
        }

        public async Task<bool> deleteTeam(int id)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM team WHERE id = @id";

            var result = await db.ExecuteAsync(sql, new {id});
            return result > 0;

        }

        public async Task<Team> getTeam(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, name FROM team WHERE id = @id";
            return await db.QueryFirstAsync<Team>(sql, new { id  });
            
        }

        public async Task<IEnumerable<Team>> getTeams()
        {
            var db = dbConnection();
            var sql = @"SELECT id ,name FROM team";
            return await db.QueryAsync<Team>(sql, new { });
            
        }

        public async Task<bool> updateTeam(Team team)
        {
            var db = dbConnection();
            var sql = @"UPDATE team SET name = @name WHERE id = @id";
            var result = await db.ExecuteAsync(sql, new { });
            return result > 0;
        }
    }
}
