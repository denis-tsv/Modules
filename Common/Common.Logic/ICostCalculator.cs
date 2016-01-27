using Common.Domain;

namespace Common.Logic
{
    public interface ICostCalculator
    {
        int GetDeliveryCost(Product p);
    }
}
