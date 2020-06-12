using System.Collections.Generic;

namespace PrimeNumberAppService
{
    public interface IPrmieNumberService
    {
        List<int> ListPrimeNumbers(int n);
    }
}