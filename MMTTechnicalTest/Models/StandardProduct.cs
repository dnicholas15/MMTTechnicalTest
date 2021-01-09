using MMTTechnicalTest.Models.Interfaces;

namespace MMTTechnicalTest.Models
{
    public class StandardProduct : IProduct
    {
        ///<inheritdoc/>
        public int Id { get; set; }

        ///<inheritdoc/>
        public int StockKeepingUnit { get; set; }

        ///<inheritdoc/>
        public string Name { get; set; }

        ///<inheritdoc/>
        public string Description { get; set; }

        ///<inheritdoc/>
        public decimal Price { get; set; }

        ///<inheritdoc/>
        public int  CategoryId { get; set; }

        ///<inheritdoc/>
        public string CategoryName { get; set; }
    }
}
