using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory.Tests
{
    [TestClass()]
    public class NumberTheoryTests
    {
        int expected = 0;
        int result = 0;
        NumberTheory instance = new NumberTheory();

        [TestInitialize()]
        public void TestInitialize()
        {
            NumberTheory instance = new NumberTheory(27);
        }


        [TestCategory("Simple Return Spec")]
        [TestMethod]
        public void TestSquare()
        {
            //Arrange
            int result = NumberTheory.Square(4);
            int expected = 16;
            NumberTheory instance = new NumberTheory(6);
            int result2 = instance.Square();
            int expected2 = 36;

            //Act

            //Assert
            Assert.AreEqual(expected, result, 0.001);
            Assert.AreEqual(expected2, result2, 0.001);
        }

        [TestMethod]
        public void TestCube()
        {
            result = NumberTheory.Cube(4);
            expected = 64;
            Assert.AreEqual(expected, result, 0.001);

            instance.TheNumber = 12;
            result = instance.Cube();
            expected = 1728;
            Assert.AreEqual(expected, result, 0.001);
        }

        [TestMethod]
        public void TestAliquotSum()
        {
            result = NumberTheory.GetAliquotSum(60);
            expected = 108;
            Assert.AreEqual(expected, result, 0.001);
            instance.TheNumber = 60;
            Assert.AreEqual(expected, instance.GetAliquotSum());
        }
                               
        [TestMethod]
        public void TestGetFactorSum()
        {
            int theTestValue = 60;
            instance.TheNumber = theTestValue;
            expected = NumberTheory.GetFactorSum(theTestValue);
            result = 168;
            Assert.AreEqual(expected, result);

            expected = instance.GetFactorSum();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetFactorial()
        {
            instance.TheNumber = 11;
            BigInteger expected = 39916800;
            BigInteger result = NumberTheory.GetFactorial(11);
            Assert.AreEqual(expected, result);

            result = instance.GetFactorial();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAbundance()
        {
            int theTestValue = 12;
            instance.TheNumber = theTestValue;

            int result = NumberTheory.GetAbundance(theTestValue);
            int expected = 4;
            Assert.AreEqual(expected, result);

            result = instance.GetAbundance();
            Assert.AreEqual(expected, result);
        }

        

        [TestMethod]
        public void TestGetReversedNumber()
        {
            int theTestValue = 12345;
            instance.TheNumber = theTestValue;
            int expected = 54321;
            int result = NumberTheory.GetReverseNumber(theTestValue);
            Assert.AreEqual(expected, result);
            result = instance.GetReverseNumber();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetReciprocalNumber()
        {
            int theTestValue = 8588;
            instance.TheNumber = theTestValue;
            double expected = 0.00011644154;
            double result = NumberTheory.GetReciprocalNumber(theTestValue);
            Assert.AreEqual(expected, result, 0.00000000001);
            result = instance.GetReciprocalNumber();
            Assert.AreEqual(expected, result, 0.00000000001);
        }

        [TestMethod]
        public void TestGetHex()
        {
            int theTestValue = 1456;
            instance.TheNumber = theTestValue;
            string expected = "5B0";
            string result = NumberTheory.GetHex(theTestValue);
            Assert.AreEqual(expected, result);
            result = instance.GetHex();
            instance.TheNumber = 145618;
            expected = "238D2";
            result = instance.GetHex();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetOctal()
        {
            int theTestValue = 500;
            instance.TheNumber = theTestValue;
            string expected = "764";
            string result = NumberTheory.GetOctal(theTestValue);
            Assert.AreEqual(expected, result);
            result = instance.GetOctal();
            instance.TheNumber = 1500;
            expected = "2734";
            result = instance.GetOctal();
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetBinary()
        {
            int theTestValue = 76576500;
            instance.TheNumber = theTestValue;
            string result = instance.GetBinary();
            string expected = "100100100000111011011110100";
            Assert.AreEqual(expected, result);

            result = NumberTheory.GetBinary(76576500);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetSigma()
        {
            instance.TheNumber = 9;
            int result = instance.GetSigma();
            int expected = 13;
            Assert.AreEqual(expected, result);

            result = NumberTheory.GetSigma(15);
            expected = 24;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetKynea()
        {
            instance.TheNumber = 5;
            int expected = 1087;
            int result = instance.GetKynea();
            Assert.AreEqual(expected, result);
            expected = 4223;
            result = NumberTheory.GetKynea(6);
            Assert.AreEqual(expected, result);
            result = NumberTheory.GetKynea(7);
            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        public void TestGetCarol()
        {
            instance.TheNumber = 7;
            int expected = 16127;
            int result = instance.GetCarol();
            Assert.AreEqual(expected, result);

            Assert.AreEqual(65023, NumberTheory.GetCarol(8));
            Assert.AreNotEqual(65023, NumberTheory.GetCarol(7));
        }

        [TestMethod]
        public void TestGetCatalan()
        {
            instance.TheNumber = 20;
            BigInteger result = instance.GetCatalan();
            BigInteger expected = 6564120420;
            Assert.AreEqual(expected, result);

            expected = 16796;
            result = NumberTheory.GetCatalan(10);
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void TestGetAmicable()
        {
            instance.TheNumber = 220;
            int result = instance.GetAmicableNumber();
            int expected = 284;
            Assert.AreEqual(expected, result);

            result = NumberTheory.GetAmicableNumber(12285);
            expected = 14595;
            Assert.AreEqual(expected, result);
        }
        
        [TestCategory("List Return Spec")]
        [TestMethod]
        public void TestGetProperDivisors()
        {
            int theTestValue = 36;

            List<int> expected = new List<int> { 1, 2, 3, 4, 6, 9, 12, 18 };
            List<int> result = NumberTheory.GetProperDivisors(theTestValue);
            CollectionAssert.AreEqual(expected, result);


            instance.TheNumber = theTestValue;
            result = instance.GetProperDivisors();
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetPellList()
        {
            instance.TheNumber = 10;
            List<BigInteger> result = instance.GetPellList();
            List<BigInteger> expected = new List<BigInteger> { 0, 1, 2, 5, 12, 29, 70, 169, 408, 985 };
            CollectionAssert.AreEqual(expected, result);

            result.Clear();
            result = NumberTheory.GetPellList(11);
            expected.Clear();
            expected = new List<BigInteger> { 0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378 };
            CollectionAssert.AreEqual(expected, result);
        }



        [TestMethod]
        public void TestGetJacobsthal()
        {
            instance.TheNumber = 20;
            List<int> result = instance.GetJacobsthal();
            List<int> expected = new List<int> {0, 1, 1, 3, 5, 11, 21, 43, 85, 171, 341, 683, 1365,
                    2731, 5461, 10923, 21845, 43691, 87381, 174763 };
            CollectionAssert.AreEqual(expected, result);

            result.Clear();
            expected.Clear();
            result = NumberTheory.GetJacobsthal(25);
            expected = new List<int> {0, 1, 1, 3, 5, 11, 21, 43, 85, 171, 341, 683, 1365, 2731, 5461,
                    10923, 21845, 43691, 87381, 174763, 349525, 699051, 1398101, 2796203, 5592405  };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetLucas()
        {
            instance.TheNumber = 12;
            List<int> result = instance.GetLucas();
            List<int> expected = new List<int> { 2, 1, 3, 4, 7, 11, 18, 29, 47, 76, 123, 199 };
            CollectionAssert.AreEqual(expected, result);

            result = NumberTheory.GetLucas(33);
            expected.Clear();
            expected = new List<int> { 2, 1, 3, 4, 7, 11, 18, 29, 47, 76, 123, 199, 322, 521, 843, 1364,
                    2207, 3571, 5778, 9349, 15127, 24476, 39603, 64079, 103682, 167761, 271443, 439204, 710647, 1149851,
                    1860498, 3010349, 4870847};
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetFibonacci()
        {
            instance.TheNumber = 10;
            List<int> result = instance.GetFibonacci();
            List<int> expected = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };
            CollectionAssert.AreEqual(expected, result);

            result = NumberTheory.GetFibonacci(17);
            expected.Clear();
            expected = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestGetPrimeFactors()
        {
            int theTestValue = 60;
            instance.TheNumber = theTestValue;
            List<int> expected = new List<int> { 2, 2, 3, 5 };
            List<int> result = instance.GetPrimeFactors();
            CollectionAssert.AreEqual(expected, result);

            result = NumberTheory.GetPrimeFactors(theTestValue);
            CollectionAssert.AreEqual(expected, result);
        }


        [TestCategory("Boolean Spec")]
        [TestMethod]
        public void TestIsAbundant()
        {
            int theTestValue = 12;
            instance.TheNumber = theTestValue;
            Assert.IsTrue(instance.IsAbundant());

            Assert.IsTrue(NumberTheory.IsAbundant(theTestValue));
        }

        [TestMethod]
        public void TestIsPerfect()
        {
            int theTestValue = 33550336;
            instance.TheNumber = theTestValue;
            Assert.IsTrue(instance.IsPerfect());
            Assert.IsTrue(NumberTheory.IsPerfect(theTestValue));
        }

        [TestMethod]
        public void TestIsSuperAbundant()
        {
            instance.TheNumber = 360;
            Assert.IsTrue(instance.IsSuperAbundant());
            instance.TheNumber = 1260;
            Assert.IsTrue(instance.IsSuperAbundant());

            Assert.IsTrue(NumberTheory.IsSuperAbundant(5040));
            Assert.IsFalse(NumberTheory.IsSuperAbundant(25));
        }

        [TestMethod]
        public void TestIsPrimativeAbundant()
        {
            instance.TheNumber = 20;
            Assert.IsTrue(instance.IsPrimativeAbundant());
            Assert.IsTrue(NumberTheory.IsPrimativeAbundant(70));
            instance.TheNumber = 87;
            Assert.IsFalse(instance.IsPrimativeAbundant());
        }

        [TestMethod]
        public void TestIsAKeithNumber()
        {
            instance.TheNumber = 197;
            Assert.IsTrue(instance.IsAKeithNumber());
            instance.TheNumber = 93993;
            Assert.IsTrue(instance.IsAKeithNumber());
            Assert.IsTrue(NumberTheory.IsAKeithNumber(1104));
            Assert.IsFalse(NumberTheory.IsAKeithNumber(1105));
        }

        [TestMethod]
        public void TestIsCarmichael()
        {
            instance.TheNumber=2821;
            Assert.IsTrue(instance.IsCarmichael());
            instance.TheNumber = 2822;
            Assert.IsFalse(instance.IsCarmichael());

            Assert.IsTrue(NumberTheory.IsCarmichael(1729));
            Assert.IsTrue(NumberTheory.IsCarmichael(2465));
            Assert.IsTrue(NumberTheory.IsCarmichael(6601));
            Assert.IsTrue(NumberTheory.IsCarmichael(41041));
            Assert.IsFalse(NumberTheory.IsCarmichael(41042));

        }


        [TestMethod]
        public void TestIsCurzon()
        {
            Assert.IsTrue(NumberTheory.IsCurzon(4769));
            Assert.IsFalse(NumberTheory.IsCurzon(4770));
            instance.TheNumber = 2109;
            Assert.IsTrue(instance.IsCurzon());
            instance.TheNumber = 2119;
            Assert.IsFalse(instance.IsCurzon());
        }

        [TestMethod]
        public void testDePolignac()
        {
            Assert.IsTrue(NumberTheory.IsDePolignac(19961));
            Assert.IsFalse(NumberTheory.IsDePolignac(20322));
            instance.TheNumber = 13285;
            Assert.IsTrue(instance.IsDePolignac());
            instance.TheNumber = 13283;
            Assert.IsFalse(instance.IsDePolignac());
        }

        [TestMethod]
        public void testIsDroll()
        {
            Assert.IsTrue(NumberTheory.IsDroll(72));
            Assert.IsFalse(NumberTheory.IsDroll(73));
            instance.TheNumber = 48384;
            Assert.IsTrue(instance.IsDroll());
            instance.TheNumber++;
            Assert.IsFalse(instance.IsDroll());
        }

        [TestMethod]
        public void testIsEmirp()
        {
            Assert.IsTrue(NumberTheory.IsEmirp(179));
            Assert.IsFalse(NumberTheory.IsEmirp(114));

            instance.TheNumber = 10009;
            Assert.IsTrue(instance.IsEmirp());
            instance.TheNumber = 19272;
            Assert.IsFalse(instance.IsEmirp());
        }

        [TestMethod]
        public void testIsGapful()
        {
            Assert.IsTrue(NumberTheory.IsGapful(108));
            instance.TheNumber = 5772;
            Assert.IsTrue(instance.IsGapful());

            Assert.IsFalse(NumberTheory.IsGapful(5771));
            instance.TheNumber = 7789;
            Assert.IsFalse(instance.IsGapful());            
        }

        [TestMethod]
        public void testIsCoPrime()
        {
            Assert.IsTrue(NumberTheory.IsCoPrime(18, 35));
            Assert.IsFalse(NumberTheory.IsCoPrime(18, 36));

            instance.TheNumber = 13;
            Assert.IsTrue(instance.IsCoPrime(31));
            instance.TheNumber = 150;
            Assert.IsFalse(instance.IsCoPrime(295));

        }

        [TestMethod]
        public void testIsChenPrime()
        {
            Assert.IsTrue(NumberTheory.IsChenPrime(137));
            Assert.IsFalse(NumberTheory.IsChenPrime(133));

            instance.TheNumber = 211;
            Assert.IsTrue(instance.IsChenPrime());
            instance.TheNumber = 84;
            Assert.IsFalse(instance.IsChenPrime());
        }

        [TestMethod]
        public void testIsSemiPrime()
        {
            Assert.IsTrue(NumberTheory.IsSemiPrime(15));
            Assert.IsFalse(NumberTheory.IsSemiPrime(92));

            instance.TheNumber = 74;
            Assert.IsTrue(instance.IsSemiPrime());
            instance.TheNumber = 84;
            Assert.IsFalse(instance.IsSemiPrime());
        }

        [TestMethod]
        public void testIsAstonishing()
        {
            Assert.IsTrue(NumberTheory.IsAstonishing(15));
            Assert.IsTrue(NumberTheory.IsAstonishing(1863));
            Assert.IsFalse(NumberTheory.IsAstonishing(20));

            instance.TheNumber = 1353;
            Assert.IsTrue(instance.IsAstonishing());
            instance.TheNumber++;
            Assert.IsFalse(instance.IsAstonishing());
        }
    }
}