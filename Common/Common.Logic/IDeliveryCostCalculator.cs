using Common.Domain;

namespace Common.Logic
{
    public interface IDeliveryCostCalculator
    {
        int GetDeliveryCost(Product product);
    }
}
