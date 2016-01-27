using Common.Domain;

namespace Common.Logic
{
    public interface IShopingCart
    {
        void AddProduct(Product product);
        int GetDeliveryCost();
    }
}
