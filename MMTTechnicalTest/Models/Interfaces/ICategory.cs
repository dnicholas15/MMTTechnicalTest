using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models.Interfaces
{
    public interface ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StandardProduct> Products { get; set; }

    }
}
