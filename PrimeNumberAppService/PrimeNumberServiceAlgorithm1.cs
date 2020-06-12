using System;
using System.Collections;
using System.Collections.Generic;

namespace PrimeNumberAppService
{
    public class PrimeNumberServiceAlgorithm1 : IPrmieNumberService
    {
        private BitArray GeneratePrimeBits(int limit)
        {
            BitArray bits = new BitArray(limit + 1, true);
            bits[0] = false;
            bits[1] = false;
            for (int i = 0; i * i <= limit; i++)
            {
                if (bits[i])
                {
                    for (int j = i * i; j <= limit; j += i)
                    {
                        bits[j] = false;
                    }
                }
            }
            return bits;
        }

        public List<int> ListPrimeNumbers(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("Invalid input! Value must be greater than zero!");
            }

            int limit = EstimatedNthPrime(n);
            BitArray bits = GeneratePrimeBits(limit);
            List<int> primes = new List<int>();
            for (int i = 0, found = 0; i <= limit && found < n; i++)
            {
                if (bits[i])
                {
                    primes.Add(i);
                    found++;
                }
            }
            return primes;
        }

        private int EstimatedNthPrime(int nn)
        {
            double n = (double)nn;
            double p;
            if (nn >= 7022)
            {
                p = n * Math.Log(n) + n * (Math.Log(Math.Log(n)) - 0.9385);
            }
            else if (nn >= 6)
            {
                p = n * Math.Log(n) + n * Math.Log(Math.Log(n));
            }
            else if (nn > 0)
            {
                p = new int[] { 2, 3, 5, 7, 11 }[nn - 1];
            }
            else
            {
                p = 0;
            }
            return (int)p;
        }

    }
}
