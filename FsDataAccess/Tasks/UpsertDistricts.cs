using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertDistrictsTask
    {
        private readonly DboContext _context;

        public UpsertDistrictsTask(DboContext context)
        {
            _context = context;
        }

        public async Task UpsertDistrictsAsync()
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
