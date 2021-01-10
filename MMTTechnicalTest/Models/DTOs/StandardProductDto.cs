namespace MMTTechnicalTest.Models.DTOs
{
    /// <summary>
    /// DTO for sending Product info to the client and avoid exposing unneccesary properties
    /// </summary>
    public class StandardProductDto
    {
        /// <summary>
        /// The Id of the product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The currency code. Used by the client to format the currency
        /// </summary>
        public string CurrencyCode  { get { return "GBP"; } }

        /// <summary>
        /// The price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The name of the category that the product belongs to
        /// </summary>
        public string CategoryName { get; set; }
    }
}
