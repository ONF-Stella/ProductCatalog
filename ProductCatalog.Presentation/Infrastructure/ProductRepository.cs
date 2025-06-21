using Dapper;
using System.Data;
using ProductCatalog.Web.Models;

namespace ProductCatalog.Web.Infrastructure
{
    public class ProductRepository
    {
        private readonly IDbConnection _db;

        public ProductRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search)
        {
            var sql = @"SELECT * FROM Products
                WHERE Name LIKE @search OR Description LIKE @search";
            return await _db.QueryAsync<Product>(sql, new { search = $"%{search}%" });
        }

        public async Task<IEnumerable<Product>> SearchAsync(string search, string test)
        {
            var sql = @"SELECT * FROM Products
                WHERE (Name LIKE @search OR Description LIKE @search) and Price > 100";
            return await _db.QueryAsync<Product>(sql, new { search = $"%{search}%" });
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Products";
            return await _db.QueryAsync<Product>(sql);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            return await _db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Product product)
        {
            var sql = @"INSERT INTO Products (Name, Description, Price, CreatedAt)
                        VALUES (@Name, @Description, @Price, @CreatedAt);
                        SELECT CAST(SCOPE_IDENTITY() as int)";
            return await _db.ExecuteScalarAsync<int>(sql, product);
        }

        public async Task UpdateAsync(Product product)
        {
            var sql = @"UPDATE Products SET Name = @Name, Description = @Description, Price = @Price
                        WHERE Id = @Id";
            await _db.ExecuteAsync(sql, product);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            await _db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
