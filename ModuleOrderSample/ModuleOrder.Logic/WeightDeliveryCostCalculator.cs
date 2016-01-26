using Common.Domain;
using Common.Logic;

namespace ModuleOrder.Logic
{
    internal class WeightDeliveryCostCalculator : IDeliveryCostCalculator
    {
        public int GetDeliveryCost(Product product)
        {
            return product.Weight;
        }
    }
}
