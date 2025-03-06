using FsDataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDataAccess
{
    public class CinListRepository
    {
        private readonly DboContext _dbContext;

        public CinListRepository(DboContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<string> GetUnprocessedCINs()
        {
            return _dbContext.ToRetrieveCinList
                .Where(c => !c.Processed)
                .Select(c => c.CIN)
                .ToList();
        }

        public void UpdateCINStatus(string cin, bool processed, string errorMessage = null)
        {
            try
            {
                string sql = "UPDATE ToRetrieveCinList SET ProcessDate = GETDATE(), Processed = @Processed, ErrorMessage = @ErrorMessage WHERE CIN = @CIN";

                _dbContext.Database.ExecuteSqlRaw(sql,
                    new Microsoft.Data.SqlClient.SqlParameter("@Processed", processed),
                    new Microsoft.Data.SqlClient.SqlParameter("@ErrorMessage", errorMessage ?? (object)DBNull.Value),
                    new Microsoft.Data.SqlClient.SqlParameter("@CIN", cin));
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error updating CIN status: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                throw;
            }
        }
    }
}
