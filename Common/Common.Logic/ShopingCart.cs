using System.Collections.Generic;
using System.Linq;
using Common.DataAccess;
using Common.Domain;

namespace Common.Logic
{
    public class ShopingCart : IShopingCart
    {
        private readonly IDeliveryCostCalculator _deliveryCostCalculator;
        private readonly IProductRepository _repository;
        private readonly List<Product> _products = new List<Product>();

        public ShopingCart(IDeliveryCostCalculator deliveryCostCalculator, IProductRepository repository)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
            _repository = repository;
        }

        public void AddProduct(int productId)
        {
            var product = _repository.GetProduct(productId);
           _products.Add(product);
        }

        public int GetDeliveryCost()
        {
            return _products.Sum(p => _deliveryCostCalculator.GetDeliveryCost(p));
        }
    }
}
