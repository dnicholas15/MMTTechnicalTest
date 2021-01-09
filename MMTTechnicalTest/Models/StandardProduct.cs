using MMTTechnicalTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models
{
    public class StandardProduct : IProduct
    {
        public int Id { get; set; }
        public int StockKeepingUnit { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int  CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
