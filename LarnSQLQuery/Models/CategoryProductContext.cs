using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LarnSQLQuery.Models
{
    public class CategoryProductContext : DbContext
    {
        

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //private ActionResult View()
        //{
        //    throw new NotImplementedException();
        //}

        public CategoryProductContext(DbContextOptions<CategoryProductContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }

        public DbSet<Product> Product { get; set; }
    }

}
