﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ORMAndDapper_Exercise1
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;
        public DapperProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM products");
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID)", new {name, price, categoryID});
        }
        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id;", new { id });
        }
        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products" +
                " SET Name = @name, " +
                " Price = @price, " +
                " CategoryID = @categoryID, " +
                " OnSale = @onSale, " +
                " StockLevel = @stock " +
                " WHERE ProductID = @id;", 
            new {
                id = product.ProductID,
                name = product.Name, 
                price = product.Price, 
                categoryID = product.CategoryID,
                onSale = product.OnSale,
                stock = product.StockLevel
                });

        }

        public void DeleteProduct(int id)
        {
            _conn.Execute("DELETE FROM sales WHERE ProductID = @id;", new { id });
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @id;", new { id });
            _conn.Execute("DELETE FROM products WHERE ProductID = @id;", new { id });
        }
    }
}
