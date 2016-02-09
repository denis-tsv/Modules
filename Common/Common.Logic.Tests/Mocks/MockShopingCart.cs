using System;
using System.Collections.Generic;
using Common.Domain;

namespace Common.Logic.Tests.Mocks
{
    // Нельзя использовать Moq, так как проверки на соответствие контракту подставляются на этапе компиляции и в mock классах, созданных на рантайме, их не будет
    // Поэтому мы испльзуем компилируемые моки
    public class MockShopingCart : IShopingCart
    {
        public Action<Product> AddProductDelegate { get; set; } 
        public Action<List<Product>> AddProductsDelegate { get; set; }
        public Func<int> GetDeliveryCostDelegate { get; set; }

        public void AddProduct(Product product)
        {
            AddProductDelegate(product);
        }

        public void AddProducts(List<Product> products)
        {
            AddProductsDelegate(products);
        }

        public int GetDeliveryCost()
        {
            return GetDeliveryCostDelegate();
        }
    }
}
