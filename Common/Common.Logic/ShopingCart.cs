using System.Collections.Generic;
using System.Linq;
using Common.Domain;

namespace Common.Logic
{
    internal class ShopingCart : IShopingCart
    {
        private readonly ICostCalculator _calculator;
        private readonly List<Product> _products = new List<Product>();

        public ShopingCart(ICostCalculator calculator)
        {
            _calculator = calculator;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public int GetDeliveryCost()
        {
            return _products.Sum(p => _calculator.GetDeliveryCost(p));
        }
    }
}
