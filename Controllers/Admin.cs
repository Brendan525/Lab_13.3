using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_13._3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Lab_13._3.Models;

namespace Lab_13._3.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            IDbConnection db = new SqlConnection("Server=GWJSN13\\SQLEXPRESS; Database=Coffee2; user id=admin; password=abc123;");
            db.Open();
            List<Product> order = db.Query<Product>("SELECT * FROM CoffeeTable").AsList<Product>();

            db.Close();

            return View(order);
        }


        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(long _id)
        {
            ViewBag.Success = "Thie product has been deleted";
            return View(Product.Read(_id));
        }
    }
}
