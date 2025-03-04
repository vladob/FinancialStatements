using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertOwnershipTypesTask
    {
        private readonly DboContext _context;

        public UpsertOwnershipTypesTask(DboContext context)
        {
            _context = context;
        }

        public async Task UpsertOwnershipTypesAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "[Upsert].[OwnershipTypes]";
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
