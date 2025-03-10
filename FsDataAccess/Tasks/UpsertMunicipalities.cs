using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertMunicipalitiesTask
    {
        private readonly DboContext _context;

        public UpsertMunicipalitiesTask(DboContext context)
        {
            _context = context;
        }

        public async Task UpsertMunicipalitiesAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "[Upsert].[Locations]";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
