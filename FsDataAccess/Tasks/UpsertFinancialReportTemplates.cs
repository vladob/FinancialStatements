using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;

namespace FsDataAccess.Tasks
{
    public class UpsertFinancialReportTemplatesTask
    {
        private readonly FinancialStatementsContext _context;

        public UpsertFinancialReportTemplatesTask(FinancialStatementsContext context)
        {
            _context = context;
        }

        public async Task UpsertFinancialReportTemplatesAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "EXEC [Upsert].[Templates];";
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
