namespace MMTTechnicalTest.Models.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// Gets and sets the id of the product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the stock keeping unit of the product
        /// </summary>
        public int StockKeepingUnit { get; set; }

        /// <summary>
        /// Gets and sets the name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets the description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets and sets the price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets and sets the categoryid of the product
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Gets and sets the categoryname of the product
        /// </summary>
        public string CategoryName { get; set; }
    }
}
