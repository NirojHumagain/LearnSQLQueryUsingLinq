using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarnSQLQuery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using LarnSQLQuery.View;

namespace LarnSQLQuery.Controllers
{
    public class CategoryProductController : Controller
    {
        //    public IActionResult Index()
        //    {
        //        return View();
        //    }
        private readonly CategoryProductContext _context;
        public CategoryProductController(CategoryProductContext context)
        {
            _context = context;
        }
        //GET: CategoryProduct
        public async Task<IActionResult> Index()
        {



            //return View(await _context.Product.ToListAsync());
            //using (var context = new CategoryProductContext())
            //{

            //    var commandText = "SELECT * FROM Category";

            //    context.Database.ExecuteSqlRaw(commandText);
            //}
            //var category = await _context.Category.ToListAsync();
            //var product = await _context.Product.ToListAsync();

            var db = from category in _context.Category
                     join product in _context.Product on category.Id equals product.CategoryID
                     /*group product by product.CategoryID */
                     select new DatabaseView
                     {
                         CategoryName = category.CategoryName,
                         CategoryID = category.CategoryID,
                         ProductID = product.Id,
                         ProductName = product.ProductName,
                     };
            return View(db);
        }
        public async Task<IActionResult> TotalProduct()
        {
            var db2 = from category2 in _context.Category
                      join product2 in _context.Product on category2.Id equals product2.CategoryID
                      group product2 by new { category2.CategoryID, category2.CategoryName, } into tp orderby tp.Key.CategoryID
                      select new DatabaseView2
                      { 
                          categoryID = tp.Key.CategoryID,
                          categoryName = tp.Key.CategoryName,
                          totalproduct = tp.Count()
                      };
            return View(db2);
        }

    }
}
