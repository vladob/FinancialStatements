using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertLocationsTask
    {
        private readonly ClassificationsDbContext _context;

        public UpsertLocationsTask(ClassificationsDbContext context)
        {
            _context = context;
        }

        public async Task UpsertLocationsAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "EXEC [Upsert].[Locations];";
                command.CommandType = System.Data.CommandType.Text;

                if (connection.State != System.Data.ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
