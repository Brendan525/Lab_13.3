using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Data;

namespace Lab_13._3.Models
{
    [Table("CoffeeTable")]
    public class Product
    {
        [Key]
        public long ProductID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public static Product Create(string _name, Decimal _price) // Creates a product
        {
            // Create the new Product instance
            Product prod = new Product() { ProductName = _name, Price = _price };

            // Save it to the database          
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee3;  user id=admin; password=abc123;");
            long _id = db.Insert<Product>(prod);

            // Set the id column of the instance
            prod.ProductID = _id;

            // Return the instance
            return prod;
        }

        public static Product Read(long _id)
        {
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee3;  user id=admin; password=abc123;");
            Product prod = db.Get<Product>(_id);
            return prod;
        }

        public static List<Product> Read()
        {
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee3; user id=admin; password=abc123;");
            List<Product> prods = db.GetAll<Product>().ToList();
            return prods;
        }

        public void Save()
        {
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee3;  user id=admin; password=abc123;");
            db.Update(this);
        }

        public static void Delete(long _id)
        {
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee3;  user id=admin; password=abc123;");
            db.Delete(new Product() { ProductID = _id });
        }

    }
}
