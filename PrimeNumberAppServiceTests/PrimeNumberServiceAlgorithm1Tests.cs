using NUnit.Framework;
using PrimeNumberAppService;
using System;

namespace PrimeNumberAppServiceTests
{
    public class PrimeNumberServiceAlgorithm1Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        [TestCase(-321)]
        [TestCase(-450)]
        public void ListPrimeNumbers_ShouldThrowArgumentException_IfInputIsNegativeNumber(int n)
        {   
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();
            

            //act
            //assert
            Assert.Throws(typeof(ArgumentException), () => sut.ListPrimeNumbers(n));
        }

        [Test]
        public void ListPrimeNumbers_ShouldThrowArgumentException_IfInputIsZero()
        {
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();


            //act
            //assert
            Assert.Throws(typeof(ArgumentException), () => sut.ListPrimeNumbers(0));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void ListPrimeNumbers_WithNNumberAsInput_ShouldReturnFirstNPrimes(int n)
        {
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();
            
            //act
            var primes = sut.ListPrimeNumbers(n);

            //assert
            Assert.AreEqual(n, primes.Count);
        }

        [Test]        
        public void ListPrimeNumbers_With1AsInput_ShouldReturn2AsPrimeNumber()
        {
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();            

            //act
            var primes = sut.ListPrimeNumbers(1);

            //assert
            Assert.AreEqual(1, primes.Count);
            Assert.AreEqual(2, primes[0]);
        }
        
        [Test]        
        public void ListPrimeNumbers_With2AsInput_ShouldReturn2N3AsPrimeNumbers()
        {
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();
            var expectedPrimes = new int[] { 2, 3 };

            //act
            var primes = sut.ListPrimeNumbers(2);

            //assert
            Assert.AreEqual(2, primes.Count);
            Assert.That(expectedPrimes, Is.EquivalentTo(primes));
        }
        
        [Test]        
        public void ListPrimeNumbers_With5AsInput_ShouldReturnFirst5PrimeNumbers()
        {
            //arrange
            var sut = new PrimeNumberServiceAlgorithm1();
            var expectedPrimes = new int[] { 2, 3, 5, 7, 11 };

            //act
            var primes = sut.ListPrimeNumbers(5);

            //assert
            Assert.AreEqual(5, primes.Count);
            Assert.That(expectedPrimes, Is.EquivalentTo(primes));
        }

    }
}