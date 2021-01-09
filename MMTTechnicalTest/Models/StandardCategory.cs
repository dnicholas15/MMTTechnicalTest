using MMTTechnicalTest.Models.Interfaces;

namespace MMTTechnicalTest.Models
{
    public class StandardCategory : ICategory
    {
        ///<inheritdoc/>
        public int Id { get; set; }

        ///<inheritdoc/>
        public string Name { get; set; }
    }
}
