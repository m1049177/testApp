using Dapper;
using testApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public ProductRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public async Task<List<Products>> GetProductList()
        {
            try
            {
                List<Products> productList = new List<Products>();
                using (IDbConnection connection = _sqlConnectionFactory.CreateConnection())
                {
                    productList = (await connection.QueryAsync<Products>(@"select * from Products;")).ToList();
                }
                return productList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void PostProductList(Products products)
        {
            try
            {
                using (IDbConnection connection = _sqlConnectionFactory.CreateConnection())
                {
                    await connection.ExecuteAsync(@"insert into Products(ProductName)values(@ProductName);" , new { products.ProductName });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
