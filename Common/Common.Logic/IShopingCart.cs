namespace Common.Logic
{
    public interface IShopingCart
    {
        void AddProduct(int productId);
        int GetDeliveryCost();
    }
}
