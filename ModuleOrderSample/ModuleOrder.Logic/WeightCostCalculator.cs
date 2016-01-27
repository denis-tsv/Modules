using Common.Domain;
using Common.Logic;

namespace ModuleOrder.Logic
{
    internal class WeightCostCalculator : ICostCalculator
    {
        public int GetDeliveryCost(Product p)
        {
            return p.Weight;
        }
    }
}
