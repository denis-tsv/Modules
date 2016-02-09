﻿using System;
using System.Collections.Generic;
using Common.Domain;

namespace Common.Logic.Tests.Mocks
{
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