using Common.Domain;

namespace Common.Logic
{
    internal class VolumeCostCalculator : ICostCalculator
    {
        public int GetDeliveryCost(Product p)
        {
            return p.Height * p.Width * p.Length;
        }
    }
}
