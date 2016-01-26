using Common.Domain;

namespace Common.Logic
{
    public class VolumeDeliveryCostCalculator : IDeliveryCostCalculator
    {
        public int GetDeliveryCost(Product product)
        {
            return product.Height*product.Width*product.Length;
        }
    }
}
