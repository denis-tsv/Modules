using System;
using System.Collections.Generic;
using Common.Domain;
using Common.Logic.Tests.Mocks;
using Xunit;

namespace Common.Logic.Tests
{
    public class ShopingCartContractTests
    {
        [Fact]
        public void AddNullProduct()
        {
            var cart = new MockShopingCart
            {
                AddProductDelegate = (p) => { },
            };

            Assert.Throws<ArgumentNullException>(() => cart.AddProduct(null));
        }

        [Fact]
        public void AddNullProducts()
        {
            var cart = new MockShopingCart
            {
                AddProductsDelegate = (p) => { },
            };

            Assert.Throws<ArgumentNullException>(() => cart.AddProducts(null));
        }

        [Fact]
        public void AddProductsWithNullInCollection()
        {
            var cart = new MockShopingCart
            {
                AddProductsDelegate = (p) => { },
            };

            var products = new List<Product>
            {
                new Product(),
                null
            };

            try
            {
                cart.AddProducts(products);
            }
            catch (Exception ex)
            {
                // ContractException is internal, so we can't use Assert.Throws<ContractException>
                Assert.Equal(ex.GetType().Name, "ContractException");
            }
        }

        [Fact]
        public void ReturnNegativeCost()
        {
            var cart = new MockShopingCart
            {
                GetDeliveryCostDelegate = () => -1,
            };

            try
            {
                cart.GetDeliveryCost();
            }
            catch (Exception ex)
            {
                // ContractException is internal, so we can't use Assert.Throws<ContractException>
                Assert.Equal(ex.GetType().Name, "ContractException");
            }
        }

    }
}
