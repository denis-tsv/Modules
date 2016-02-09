using System;
using Common.Domain;

namespace Common.Logic.Tests.Mocks
{
    // We can't use Moq because we need to insert checking of contract at compile time. So we will use custom mocks
    public class MockCostCalculator : ICostCalculator
    {
        public Func<Product, int> GetDeliveryCostDelegate { get; set; }
        public int GetDeliveryCost(Product p)
        {
            return GetDeliveryCostDelegate(p);
        }
    }
}
