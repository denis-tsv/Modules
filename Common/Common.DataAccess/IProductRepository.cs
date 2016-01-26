using Common.Domain;

namespace Common.DataAccess
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
    }
}
