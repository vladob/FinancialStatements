using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace FsDataAccess.Tasks
{
    public class UpsertFinancialReportTemplatesTask
    {
        private readonly FinancialStatementsContext _context;
        private readonly ILogger<UpsertFinancialReportTemplatesTask> _logger;

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

                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error saving financial report template to the database.");
                    throw; // Re-throw the exception to handle it further up the call stack if needed
                }
            }
        }
    }
}
