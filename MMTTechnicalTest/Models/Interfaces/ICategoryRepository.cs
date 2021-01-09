using System.Collections.Generic;

namespace MMTTechnicalTest.Models.Repositories
{
    /// <summary>
    /// Interface for the category repository
    /// </summary>
    public interface ICategoryRepository
    {
        /// <summary>
        /// Method to return all categories from the database
        /// </summary>
        /// <returns>A list of <see cref="StandardCategory"/></returns>
        public IEnumerable<StandardCategory>GetAllCategories();
    }
}
