using PrimeNumberAppService;
using System;

namespace PrimeNumberChallange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter number : ");           

            try
            {
                int input = GetNumber();
                var primeNumberService = new PrimeNumberServiceAlgorithm1();
                var primes = primeNumberService.ListPrimeNumbers(input);

                var printString = "\t";

                for (int i = 0; i <= primes.Count; i++)
                {
                    if (i > 0)
                        printString = $"{primes[i - 1]} \t";

                    for (int j = 0; j < primes.Count; j++)
                    {

                        if (i == 0)
                            printString += $"{primes[j]} \t";
                        else
                            printString += $"{string.Concat(primes[i - 1] * primes[j])} \t";

                    }
                    Console.WriteLine(printString);
                    printString = string.Empty;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error!");
            }
            Console.Read();
        }

        private static int GetNumber()
        {
            var errorMessage = "Invalid input! Value must be whole number!";
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                throw new ArgumentException(errorMessage);
            }

            return input;
        }
    }
}
