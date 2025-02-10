
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper;
using System.Data;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            //Exercise 1 Deparments

            var departmentRepo = new DapperDepartmentRepository(conn);

            departmentRepo.InsertDepartment("New Department Example");

            var departments = departmentRepo.GetAllDepartments();

            Console.WriteLine("Departments:");

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} {department.Name}");
            }

            //Exercise 2 Products
            var productRepo = new DapperProductRepository(conn);

            var products = productRepo.GetAllProducts();

            Console.WriteLine("");
            Console.WriteLine("Products:");

            foreach (var product in products) 
            {
                Console.WriteLine($"{product.ProductID} Name:{product.Name} Price:{product.Price} Category:{product.CategoryID} OnSale:{product.OnSale} StockLevel:{product.StockLevel}");
            }



        }
    }
}

