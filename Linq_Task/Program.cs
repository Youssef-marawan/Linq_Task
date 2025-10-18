using Linq_Task.DataAccess;
using Linq_Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Linq_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _db = new();
            /*
             #region Q_01

                 var customers = _db.Customers.AsQueryable().Select(e => new
                 {
                    firstNmae =  e.FirstName,
                    lastName = e.LastName,
                    email = e.Email,
                 }
                 );
                 foreach (var rec in customers) {
                     Console.WriteLine($"FirstName = {rec.firstNmae} **** LastName = {rec.lastName} **** Email = {rec.email}");
                 }

             #endregion

             #region Q_02

                 var orders = _db.Orders.AsQueryable().Where(e=>e.StaffId == 3).ToList();
                 foreach (var rec in orders) {
                     Console.WriteLine($"order ID : {rec.OrderId}");
                 }

             #endregion

             #region Q_03
             var products = _db.Products.AsQueryable().Include(e => e.Category).Where(e => e.Category.CategoryName == "Mountain Bikes");
             foreach (var rec in products) {
                 Console.WriteLine($"Product Name : {rec.ProductName}");
             }
             #endregion
            
            #region Q_04
            var orders = _db.Products.AsQueryable().Select((e => e.ProductId)).Count();
            Console.WriteLine($"Number of Orders : {orders}");
            #endregion
            
            #region Q_05
            var orders = _db.Orders.AsQueryable().Where(e => e.ShippedDate == null);
            foreach (var rec in orders)
            {
                Console.WriteLine($"order ID : {rec.OrderId}");
            }
            #endregion
            
            #region Q_06
            var data = _db.Customers.AsQueryable().Include(e=>e.Orders).Select(e=>new {id = e.CustomerId,lastname = e.LastName,fname =  e.FirstName,number = e.Orders.Count() }).ToList();
            foreach (var recc in data)
            {
                Console.WriteLine($"{recc.id} => {recc.fname}  {recc.lastname} => {recc.number}");
            }
            #endregion
            
            #region Q_07

            var data = _db.Products.AsQueryable().Include(e => e.OrderItems).Where(e => !e.OrderItems.Any());
            foreach (var recc in data)
            {
                Console.WriteLine($"{recc.ProductName}");
            }
            
            #endregion
            
            #region Q_08
            var data = _db.Stocks.AsQueryable().Include(e => e.Product).Select(e => new { e.Quantity,e.Product.ProductName}).Where(e => e.Quantity<5);
            foreach (var recc in data)
            {
                Console.WriteLine($"{recc.ProductName} Quantity = {recc.Quantity}");
            }
            #endregion
            
            #region Q_09
            var data = _db.Products.AsQueryable().FirstOrDefault();
            Console.WriteLine($"{data.ModelYear}");
            #endregion
            
            
            #region Q_10
            var data = _db.Products.AsQueryable().Where(e=>e.ModelYear==2025);
            foreach (var item in data)
            {
                Console.WriteLine($"{item.ProductName}");
            }
            #endregion
            
            #region Q_11
            var data = _db.Products.Include(e=>e.OrderItems).Select(e=>new {id =  e.ProductId, number = e.OrderItems.Count()});
            foreach (var item in data) {
                Console.WriteLine($"Id = {item.id} = > {item.number}");
            }
            #endregion
            
            #region Q_12
            var data = _db.Categories.AsQueryable().Include(e => e.Products).Select(e => new { e.CategoryName ,number = e.Products.Count}).ToList();
            foreach (var rec in data) {
                Console.WriteLine($"{rec.CategoryName}  => {rec.number}");
            }
            #endregion
            
            #region Q_13
            var data = _db.OrderItems.AsQueryable().Average(e=>e.ListPrice);
            
                Console.WriteLine($"{data}");
            
            #endregion
            
            #region Q_14
            var data = _db.Products.Find(0);
            
                Console.WriteLine(data!=null?$"products name = {data.ProductName}": "not found");
            
            #endregion
            
            #region Q_15
            var data = _db.OrderItems.AsQueryable().Include(e => e.Product).Select(e => new {number= e.Quantity, name = e.Product.ProductName }).Where(e=>e.number>3);
            foreach (var rec in data)
            {
                Console.WriteLine($"{rec.name}  => {rec.number}");
            }
            #endregion
            
            #region Q_16
            var data = _db.Staffs.AsQueryable().Select(e => new { name = e.FirstName,number = e.Orders.Count()});
            foreach (var rec in data)
            {
                Console.WriteLine($"{rec.name}  => {rec.number}");
            }
            
            #endregion
            
            #region Q_17
            var data = _db.Staffs.AsQueryable().Select(e => new { name = e.FirstName, number = e.Phone,flag = e.Active }).Where(e=>e.flag==1);
            foreach (var rec in data)
            {
                Console.WriteLine($"{rec.name}  => {rec.number}");
            }
            #endregion
            
            #region Q_18
            var data = _db.Products.Include(e=>e.Brand).Include(e=>e.Category).Select(e=>new { p = e.ProductName , c = e.Category.CategoryName,b = e.Brand.BrandName}).ToList();
            foreach (var item in data) {
                Console.WriteLine($"{item.p} => {item.c} => {item.b}");
            }
            #endregion
            
            #region Q_19
            var orders = _db.Orders.AsQueryable().Where(e => e.ShippedDate == null);
            foreach (var rec in orders)
            {
                Console.WriteLine($"order ID : {rec.OrderId}");
            }
            #endregion
            */
            #region Q_20
            var data = _db.OrderItems.Include(e=>e.Product).GroupBy(e =>new { e.ProductId,e.Product.ProductName }).Select(g => new { id = g.Key, number = g.Sum(e => e.Quantity) });
            foreach (var rec in data) {
                Console.WriteLine($"{rec.id}  => {rec.number}");
            }
            #endregion

        }
    }
}
