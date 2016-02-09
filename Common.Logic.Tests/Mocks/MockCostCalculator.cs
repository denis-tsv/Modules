using System;
using Common.Domain;

namespace Common.Logic.Tests.Mocks
{
    public class MockCostCalculator : ICostCalculator
    {
        public Func<Product, int> GetDeliveryCostDelegate { get; set; }
        public int GetDeliveryCost(Product p)
        {
            return GetDeliveryCostDelegate(p);
        }
    }
}
