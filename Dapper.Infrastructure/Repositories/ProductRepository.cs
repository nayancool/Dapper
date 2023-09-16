using Dapper.Application.Interfaces;
using Dapper.Core.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Dapper.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM PRODUCT";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                var result = await conn.QueryAsync<Product>(sql);
                return result.ToList();
            }
        }

        public async Task<int> Add(Product product)
        {
            product.AddedOn = DateTime.Now;

            //A straightforward SQL command to insert data into Product table.
            var sql = "INSERT INTO PRODUCT (ID, NAME, DESCRIPTION, BARCODE, RATE, ADDEDON) VALUES (@ID, @NAME, @DESCRIPTION, @BARCODE, @RATE, @ADDEDON)";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(sql, product);// we pass product object and sql command to the execute function.
                return result;
            }
        }

        public async Task<int> DeleteById(int id)
        {
            var sql = "DELETE FROM PRODUCT WHERE ID = @ID";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<Product> GetById(int id)
        {
            var sql = "SELECT * FROM PRODUCT WHERE ID = @ID";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                var result = await conn.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> Update(Product entity)
        {
            entity.ModifiedOn = DateTime.Now;
            var sql = "UPDATE PRODUCT SET NAME =@NAME, DESCRIPTION = @DESCRIPTION, BARCODE = @BARCODE, RATE = @RATE, MODIFIEDON = @MODIFIEDON WHERE ID = @ID";
            using (var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}