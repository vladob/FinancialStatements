using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDataAccess.Tasks
{
    public class UpsertAccountingEntities
    {
        private readonly DboContext _context;

        public UpsertAccountingEntities(DboContext context)
        {
            _context = context;
        }
        public async Task AccountingEntitiesAsync()
        {
            var connection = _context.Database.GetDbConnection();
            await using (var command = connection.CreateCommand())
            {
                command.CommandText = "[Upsert].[AccountingEntities]";
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
