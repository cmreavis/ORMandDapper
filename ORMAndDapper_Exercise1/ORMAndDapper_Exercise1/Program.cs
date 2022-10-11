using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORMAndDapper_Exercise1;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DapperDepartmentRepository(conn);

//departmentRepo.InsertDepartment("Colins Dept");

var departments = departmentRepo.GetAllDepartments();

foreach (var department in departments)
{
    Console.WriteLine(department.DepartmentID);
    Console.WriteLine(department.Name);
    Console.WriteLine();
}

var productRepo = new DapperProductRepository(conn);

//productRepo.CreateProduct("Bushs Baked Beans", 420.69, 10);

//var updatingProduct = productRepo.GetProduct(940);
    //updatingProduct.Name = "Dark Souls 3";
    //updatingProduct.OnSale = true;
    //updatingProduct.Price = 40.00;
    //updatingProduct.StockLevel = 100;
//productRepo.UpdateProduct(updatingProduct);

//productRepo.DeleteProduct(942);

var products = productRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine(product.ProductID);
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price);
    Console.WriteLine(product.CategoryID);
    Console.WriteLine(product.OnSale);
    Console.WriteLine(product.StockLevel);
}