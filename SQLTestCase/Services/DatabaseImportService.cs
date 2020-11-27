using System.Linq;
using SQLTestCase.Data;
using SQLTestCase.Data.Entities;
using SQLTestCase.Data.Enums;
using SQLTestCase.Interfaces;

namespace SQLTestCase.Services
{
    public class DatabaseImportService:IDatabaseImportService
    {
        private readonly SQLTestCaseDbContext _context;

        public DatabaseImportService(SQLTestCaseDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (!_context.Customers.Any())
            {
                _context.Customers.AddRange(new Customer {FullName = "Jane Petryk", Country = "Ukraine"},
                    new Customer {FullName = "Ann Smith", Country = "USA"},
                    new Customer {FullName = "Hans Zimmer", Country = "Germany"},
                    new Customer {FullName = "Ihor Boiko", Country = "Ukraine"},
                    new Customer {FullName = "Grzegorz Brzeczyszczykiewicz", Country = "Poland"},
                    new Customer {FullName = "Ewa Duda", Country = "Poland"},
                    new Customer {FullName = "Ester Trillo", Country = "Spain"},
                    new Customer {FullName = "George Best", Country = "UK"}
                );
            }

            if (!_context.Products.Any())
            {
                _context.Products.AddRange(
                    new Product
                    {
                        Name = "Acer Aspire 5 Slim Laptop", Price = 364.99M, Category = ProductCategory.Computers
                    },
                    new Product
                    {
                        Name = "ecobee3 Lite Smart Thermostat", Price = 140.13M, Category = ProductCategory.SmartHome
                    },
                    new Product
                    {
                        Name = "Lenovo IdeaPad 3 14\" Laptop", Price = 423.81M, Category = ProductCategory.Computers
                    }
                );
            }

            _context.SaveChanges();
        }
    }
}