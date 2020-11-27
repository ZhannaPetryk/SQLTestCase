using System.Runtime;
using SQLTestCase.Data.Enums;

namespace SQLTestCase.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ProductCategory Category { get; set; }
    }
}