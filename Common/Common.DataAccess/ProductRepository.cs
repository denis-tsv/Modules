using Common.Domain;

namespace Common.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(int id)
        {
            return new Product
            {
                Id = id,
                Height = 1, 
                Weight = 2, 
                Length = 3, 
                Width = 4
            };
        }
    }
}
