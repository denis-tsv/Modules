using System;
using System.Diagnostics.Contracts;
using Common.Domain;

namespace Common.Logic
{
    [ContractClass(typeof (ICostCalculatorContract))]
    public interface ICostCalculator
    {
        int GetDeliveryCost(Product p);
    }

    [ContractClassFor(typeof (ICostCalculator))]
    abstract class ICostCalculatorContract : ICostCalculator
    {
        public int GetDeliveryCost(Product p)
        {
            Contract.Requires<ArgumentNullException>(p != null, "p != null");
            Contract.Ensures(Contract.Result<int>() >= 0);

            throw new NotImplementedException();
        }
    }
}
