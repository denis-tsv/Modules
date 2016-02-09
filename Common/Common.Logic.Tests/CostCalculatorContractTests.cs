using System;
using Common.Domain;
using Common.Logic.Tests.Mocks;
using Xunit;

namespace Common.Logic.Tests
{
    public class CostCalculatorContractTests
    {
        [Fact]
        public void NullProduct()
        {
            var calc = new MockCostCalculator
            {
                GetDeliveryCostDelegate = (p) => 0
            };
            Assert.Throws<ArgumentNullException>(() => calc.GetDeliveryCost(null));
        }

        [Fact]
        public void ReturnNegativeValue()
        {
            var calc = new MockCostCalculator
            {
                GetDeliveryCostDelegate = (p) => -1
            };
            try
            {
                calc.GetDeliveryCost(new Product());
            }
            catch (Exception ex)
            {
                // ContractException - это internal класс, поэтому нельзя использовать Assert.Throws<ContractException>
                Assert.Equal(ex.GetType().Name, "ContractException");
            }
        }
    }
}
