using System;
using Common.Domain;

namespace Common.Logic.Tests.Mocks
{
    // Нельзя использовать Moq, так как проверки на соответствие контракту подставляются на этапе компиляции и в mock классах, созданных на рантайме, их не будет
    // Поэтому мы испльзуем компилируемые моки
    public class MockCostCalculator : ICostCalculator
    {
        public Func<Product, int> GetDeliveryCostDelegate { get; set; }
        public int GetDeliveryCost(Product p)
        {
            return GetDeliveryCostDelegate(p);
        }
    }
}
