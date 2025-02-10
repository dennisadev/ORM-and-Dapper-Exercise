using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;     //Connection 

        public DapperProductRepository(IDbConnection conn) 
        { 
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts() 
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }

        public void CreateProduct(string newProdcutName, double newPrice, int newCategoryID)
        {
            _conn.Execute("INSERT INTO products (Name) VALUES (@productsName)", new { productsName = newProdcutName });
        }

    }
}
