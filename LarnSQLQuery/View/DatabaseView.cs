using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarnSQLQuery.View
{
    public class DatabaseView
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public DatabaseView2 DataBaseView2 { get; set; }


    }
}
