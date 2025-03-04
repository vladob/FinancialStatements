using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertLegalFormsTask
    {
        private readonly DboContext _context;

        public UpsertLegalFormsTask(DboContext context)
        {
            _context = context;
        }

        public async Task UpsertLegalFormsAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "[Upsert].[LegalForms]";
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
