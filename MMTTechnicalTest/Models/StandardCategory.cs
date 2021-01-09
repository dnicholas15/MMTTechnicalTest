using MMTTechnicalTest.Models.Interfaces;

namespace MMTTechnicalTest.Models
{
    public class StandardCategory : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
