using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Common.Domain;

namespace Common.Logic
{
    [ContractClass(typeof (IShopingCartContract))]
    public interface IShopingCart
    {
        void AddProduct(Product product);
        void AddProducts(List<Product> products);
        int GetDeliveryCost();
    }

    [ContractClassFor(typeof (IShopingCart))]
    public abstract class IShopingCartContract : IShopingCart
    {
        public void AddProduct(Product product)
        {
            Contract.Requires<ArgumentNullException>(product != null, "product != null");

            throw new System.NotImplementedException();
        }

        public void AddProducts(List<Product> products)
        {
            Contract.Requires<ArgumentNullException>(products != null, "products != null");
            Contract.Requires(Contract.ForAll(products, p => p != null), "Contract.ForAll(products, p => p != null)");

            throw new System.NotImplementedException();
        }

        public int GetDeliveryCost()
        {
            Contract.Ensures(Contract.Result<int>() >= 0);

            throw new System.NotImplementedException();
        }
    }
}
