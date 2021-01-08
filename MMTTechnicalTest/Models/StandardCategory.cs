using MMTTechnicalTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTTechnicalTest.Models
{
    public class StandardCategory : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
