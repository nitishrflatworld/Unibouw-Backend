using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using UnibouwAPI.Models;
using UnibouwAPI.Repositories.Interfaces;
namespace UnibouwAPI.Repositories
{
    public class WorkItemCategoryTypeRepository : IWorkItemCategoryType
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public WorkItemCategoryTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("UnibouwDbConnection");
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
        }

        private IDbConnection _connection => new SqlConnection(_connectionString);
   
        public async Task<IEnumerable<WorkItemCategoryType>> GetAllAsync()
        {
            return await _connection.QueryAsync<WorkItemCategoryType>("SELECT * FROM WorkItemCategoryType");
        }

        public async Task<WorkItemCategoryType?> GetByIdAsync(Guid id)
        {
            return await _connection.QueryFirstOrDefaultAsync<WorkItemCategoryType>("SELECT * FROM WorkItemCategoryType WHERE CategoryId = @Id", new { Id = id });

        }

    }
}
