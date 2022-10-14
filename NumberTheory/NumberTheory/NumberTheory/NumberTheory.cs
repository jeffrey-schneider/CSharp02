using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace NumberTheory
{
    public class NumberTheory
    {
        private int theNumber;

        public NumberTheory()
        {
        }

        public NumberTheory(int theNumber)
        {
            this.theNumber = theNumber;
        }


        public int TheNumber { get => theNumber; set => theNumber = value; }

        public static List<int> getCollatz(int v)
        {
            List<int> retVal = new List<int>
            {
                v
            };
            int counter = v;
            while (counter > 1)
            {
                if (counter % 2 == 0) {
                    counter /= 2;
                } else {
                    counter = (int)Math.Floor(3.0 * counter + 1);
                }
                retVal.Add(counter);
            }
            return retVal;
        }
        public List<int> GetCollatz()
        {
            return getCollatz(theNumber);
        }




        public static List<int> GetJugglers(int v)
        {
            double factr = 0.0;
            List<int> retVal = new List<int>();
            retVal.Add(v);
            int counter = v;
            while (counter > 1)
            {
                if (counter % 2 == 0)
                {
                    factr = .5;
                }
                else
                {
                    factr = 1.5;
                }
                counter = (int)Math.Floor(Math.Pow(counter, factr));
                retVal.Add(counter);
            }
            return retVal;
        }

        public int GetAliquotSum()
        {
            return GetAliquotSum(theNumber);
        }

        public static int GetAliquotSum(int v)
        {
            int retVal = 0;
            foreach (var factor in GetFactors(v))
            {
                retVal += factor;
            }
            return retVal - v;
        }

        public static List<int> GetFactors(int v)
        {
            List<int> retVal = new List<int>();
            for (int i = 1; i < v; i++)
            {
                if (v % i == 0)
                    retVal.Add(i);
            }
            retVal.Add(v);
            return retVal;
        }
        public List<int> GetFactors()
        {
            return GetFactors(theNumber);
        }

        public static int GetFactorSum(int v)
        {
            int retVal = 0;
            foreach (var item in GetFactors(v))
            {
                retVal += item;
            }
            return retVal;
        }
        public int GetFactorSum()
        {
            return GetFactorSum(theNumber);
        }

        public static List<int> GetPrimeFactors(int v)
        {
            List<int> retVal = new List<int>();
            int ourNumber = v;
            for (int i = 2; i < v; i++)
            {
                while (ourNumber % i == 0) {
                    retVal.Add(i);
                    ourNumber /= i;
                }
            }
            return retVal;
        }

        public List<int> GetPrimeFactors()
        {
            return GetPrimeFactors(theNumber);
        }



        public List<int> GetJugglers()
        {
            return GetJugglers(theNumber);
        }



        public static int Cube(int v)
        {
            return v * v * v;
        }
        public int Cube()
        {
            return Cube(this.theNumber);
        }


        public int GetTheNumber()
        {
            return theNumber;
        }



        public static int Square(int v)
        {
            return v * v;
        }

        public int Square()
        {
            return Square(theNumber);
        }


        public static bool IsPrime(int v)
        {
            int stopVal = (int)Math.Sqrt(v);
            int i = 2;
            while (i <= stopVal)
            {
                if (v % i == 0)
                    return false;
                i++;
            }

            return true;
        }



        public bool IsPrime()
        {
            return IsPrime(theNumber);
        }


        public static BigInteger GetFactorial(int v)
        {
            BigInteger factorial = new BigInteger(1);
            for (int i = 1; i <= v; i++)
            {
                factorial = BigInteger.Multiply(factorial, BigInteger.Parse(i.ToString()));
            }
            return factorial;
        }

        public BigInteger GetFactorial()
        {
            return GetFactorial(theNumber);
        }

        public static List<int> GetProperDivisors(int v)
        {
            List<int> retVal = new List<int>();
            for (int i = 1; i < v; i++)
            {
                if (v % i == 0)
                {
                    retVal.Add(i);
                }
            }
            return retVal;
        }
        public List<int> GetProperDivisors()
        {
            return GetProperDivisors(theNumber);
        }


        public static int GetAbundance(int v)
        {
            return GetAliquotSum(v) - v;
        }
        public int GetAbundance()
        {
            return GetAbundance(theNumber);
        }

        public static bool IsAbundant(int v)
        {
            return GetAliquotSum(v) > v;
        }
        public bool IsAbundant()
        {
            return IsAbundant(theNumber);
        }

        public static bool IsPerfect(int v)
        {
            return GetAbundance(v) == 0;
        }
        public bool IsPerfect()
        {
            return IsPerfect(theNumber);
        }


        public static int GetReverseNumber(int v)
        {
            int num = v;
            int rev = 0;
            int digit = 0;
            while (num > 0)
            {
                digit = num % 10;
                rev = rev * 10 + digit;
                num /= 10;
            }
            return rev;
        }
        public int GetReverseNumber()
        {
            return GetReverseNumber(theNumber);
        }

        public static double GetReciprocalNumber(int v)
        {
            return 1.0 / v;
        }
        public double GetReciprocalNumber()
        {
            return GetReciprocalNumber(theNumber);
        }

        public static string GetHex(int v)
        {
            string retVal = "";
            string[] hex = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            int rem = 0;
            int buffer = v;
            while (buffer > 0)
            {
                rem = buffer % 16;
                retVal = hex[rem] + retVal;
                buffer = buffer / 16;
            }
            return retVal;
        }



        public string GetHex()
        {
            return GetHex(theNumber);
        }



        public static string GetOctal(int v)
        {
            String retVal = "";
            String[] dig = { "0", "1", "2", "3", "4", "5", "6", "7" };
            int rem = 0;
            int buffer = v;
            while (buffer > 0)
            {
                rem = buffer % 8;
                retVal = dig[rem] + retVal;
                buffer /= 8;
            }
            return retVal;
        }

        public static int GetAmicableNumber(int v)
        {
            int bla = NumberTheory.GetAliquotSum(v);
            int blin = NumberTheory.GetAliquotSum(bla);
            if (blin == v && bla > blin)
            {
                return bla;
            }
            return -1;
        }
        public int GetAmicableNumber()
        {
            return GetAmicableNumber(theNumber);
        }

        public string GetOctal()
        {
            return GetOctal(theNumber);
        }


        public static string GetBinary(int v)
        {
            return Convert.ToString(v, 2);
        }

        public string GetBinary()
        {
            return GetBinary(theNumber);
        }

        public static int GetSigma(double v)
        {
            if (v == 1)
            {
                return 1;
            }
            int result = 0;
            for (int i = 1; i <= v; i++)
            {
                if (v % i == 0)
                {
                    result += i;
                }
            }
            return result;
        }

        public int GetSigma()
        {
            return GetSigma(theNumber);
        }


        public static Boolean IsSuperAbundant(int v)
        {
            double M = 0.0;
            double theNumberDouble = (double)v;
            double N = GetSigma(theNumberDouble) / theNumberDouble;
            for (double i = 0.0; i < v; i++)
            {
                M = GetSigma(i) / i;
            }
            if (M >= N)
            {
                return false;
            }
            return true;
        }
        public Boolean IsSuperAbundant()
        {
            return IsSuperAbundant(theNumber);
        }

        public static Boolean IsPrimativeAbundant(int v)
        {
            //20, 70 True
            // 87 False
            if (IsAbundant(v))
            {
                List<int> FactorArray = GetProperDivisors(v);
                for (int i = 0; i < FactorArray.Count; i++)
                {
                    if (GetAliquotSum(FactorArray[i]) > 0) {
                        return true;
                    }
                }
            }
            return false;
        }



        public Boolean IsPrimativeAbundant()
        {
            return IsPrimativeAbundant(theNumber);
        }



        public static Boolean IsAKeithNumber(int v)
        {
            if (v > Int32.MaxValue)
            {
                throw new ArithmeticException("Integer Overflow");
            }
            LinkedList<int> theList = new LinkedList<int>();
            int number = v;
            while (number > 0)
            {
                theList.AddFirst(number % 10);
                number /= 10;
            }
            int nextNumber = 0;
            while (nextNumber < v)
            {
                nextNumber = 0;
                foreach (int item in theList)
                {
                    nextNumber += item;
                }
                theList.RemoveFirst();
                theList.AddLast(nextNumber);

                if (nextNumber == v)
                    return true;
            }
            return false;
        }

        public Boolean IsAKeithNumber()
        {
            return IsAKeithNumber(theNumber);
        }

        public static int GetKynea(int v)
        {
            double kyneaA = Math.Pow(4.0, v);
            double kyneaB = Math.Pow(2.0, v + 1);
            return (int)(kyneaA + kyneaB - 1.0);
        }



        public int GetKynea()
        {
            return GetKynea(theNumber);
        }

        public static int GetCarol(int v)
        {
            double carolA = Math.Pow(4.0, v);
            double carolB = Math.Pow(2.0, (v + 1));
            double carolFinal = carolA - carolB - 1.0;
            return (int)carolFinal;
        }

        public int GetCarol()
        {
            return GetCarol(theNumber);
        }

        public static BigInteger GetCatalan(int v)
        {
            BigInteger catA = NumberTheory.GetFactorial(2 * v);
            BigInteger catB = NumberTheory.GetFactorial(v + 1);
            BigInteger catC = NumberTheory.GetFactorial(v);
            BigInteger catFinal = catA / (catB * catC);
            return catFinal;
        }

        public BigInteger GetCatalan()
        {
            return GetCatalan(theNumber);
        }


        public static List<int> GetFibonacci(int v)
        {
            int num1 = 0;
            int num2 = 1;
            int counter = 0;
            List<int> retList = new List<int>();
            //Iterate until counter == v
            while (counter < v)
            {
                retList.Add(num1);
                int num3 = num2 + num1;
                num1 = num2;
                num2 = num3;
                counter++;
            }
            return retList;
        }
        public List<int> GetFibonacci()
        {
            return GetFibonacci(theNumber);
        }


        public static List<int> GetLucas(int v)
        {
            int num1 = 2;
            int num2 = 1;
            int counter = 0;
            List<int> retList = new List<int>();
            //Iterate until counter == v
            while (counter < v)
            {
                retList.Add(num1);
                int num3 = num2 + num1;
                num1 = num2;
                num2 = num3;
                counter++;
            }
            return retList;
        }
        public List<int> GetLucas()
        {
            return GetLucas(theNumber);
        }

        public static List<BigInteger> GetPellList(int v)
        {
            BigInteger num1 = 0;
            BigInteger num2 = 1;
            int counter = 0;
            List<BigInteger> retList = new List<BigInteger>();
            while (counter < v)
            {
                retList.Add(num1);
                BigInteger num3 = 2 * num2 + num1;
                num1 = num2;
                num2 = num3;
                counter++;
            }
            return retList;
        }

        

        public List<BigInteger> GetPellList()
        {
            return GetPellList(theNumber);
        }

        public static BigInteger GetPell(int v)
        {
            List<BigInteger> theList = GetPellList(v);
            Stack<BigInteger> theStack = new Stack<BigInteger>();
            foreach (BigInteger item in theList)
            {
                theStack.Push(item);
            }
            return theStack.Pop();
        }

        

        public static List<int> GetJacobsthal(int v)
        {
            int num1 = 0;
            int num2 = 1;
            int counter = 0;
            List<int> retList = new List<int>();
            //Iterate until counter == v
            while (counter < v)
            {
                retList.Add(num1);
                int num3 = num2 + 2 * num1;
                num1 = num2;
                num2 = num3;
                counter++;
            }
            return retList;
        }

        public static bool IsEmirp(int v)
        {
            return (IsPrime(v) && IsPrime(GetReverseNumber(v)));
        }
        public bool IsEmirp()
        {
            return IsEmirp(theNumber);
        }

        public List<int> GetJacobsthal()
        {
            return GetJacobsthal(theNumber);
        }

        public static bool IsGapful(int v)
        {
            if (v < 100 || IsPrime(v))
            {
                //if number isn't at least 3 digits fail.
                return false;
            }
            int[] a = GetFirstAndLastDigits(v);
            int divisor = a[0] * 10 + a[1];
            if (v % divisor == 0)
                return true;
            return false;
        }

        public static bool IsCoPrime(int v1, int v2)
        {
            if(GCD(v1, v2) == 1)
            {
                return true;
            }
            return false;
        }
        public bool IsCoPrime(int v1)
        {
            return IsCoPrime(theNumber, v1);
        }

        public bool IsGapful()
        {
            return IsGapful(theNumber);
        }

        public static bool IsChenPrime(int v)
        {
            if (IsPrime(v))
            {
                return IsPrime(v +2 ) || IsSemiPrime(v + 2);
            }
            return false;
        }

        public static bool IsSemiPrime(int v)
        {
            List<int> anotherList = NumberTheory.GetPrimeFactors(v);
            return anotherList.Count() == 2;
        }
        public bool IsSemiPrime()
        {
            return IsSemiPrime(theNumber);
        }


        public bool IsChenPrime()
        {
            return IsChenPrime(theNumber);
        }

        public static int[] GetFirstAndLastDigits(int v)
        {
            List<int> theList = GetListOfDigits(v);
            int firstDigit = theList[0];
            int length = theList.Count() - 1;
            int lastDigit = theList[length];
            int[] retVal = { firstDigit, lastDigit };
            return retVal;
        }


        // https://www.geeksforgeeks.org/astonishing-numbers/
        // This code is contributed by shubhamsingh10
        // Time Complexity: O(n)
        // Auxiliary Space: O(1)

        // Loop to find sum of all integers
        // from i until the sum becomes >= v
        public static bool IsAstonishing(int v)
        {
            //Does not work for all astonishing numbers:
            // 190, 204, 216, 200207, 19900
            for (int i = 1; i < v; i++)
            {
                // variable to store sum of all integers
                // from i to j and check if sum and
                // concatenation equals v or not.
                int sum = 0;
                for (int j = i; j < v; j++)
                {
                    sum += j;
                    if (sum == v)
                    {
                        // Finding concatenation of i and j
                        int concatenation = concat(i, j);

                        // condition for astonishing number
                        if (concatenation == v)
                        {
                            return true;
                        }
                    }

                }
            }
            return false;
        }
        public bool IsAstonishing()
        {
            return IsAstonishing(theNumber);
        }

        private static int concat(int a, int b)
        {
            //Convert both integers into string
            String s1 = a.ToString();
            String s2 = b.ToString();
            //Concat both strings
            String s = s1 + s2;
            //Convert string to integer
            int c = Convert.ToInt32(s);
            return c;
        }

        private static List<int> GetListOfDigits(int v)
        {
            List<int> retList = new List<int>();
            //this works right to left
            while(v > 0)
            {
                int remainder = v % 10;
                retList.Add(remainder);
                v /= 10;
            }
            retList.Reverse();
            return retList;

            
        }

        public static String GetBigIntegerPower(int baseNumber, int exponent)
        {
            BigInteger biggie = baseNumber;
            String retVal = BigInteger.Pow(baseNumber, exponent).ToString();
            return retVal;
        }

        public static String GetApocolyptic(int v)
        {
            string GetTestNumber = GetBigIntegerPower(2, v);
            return "Nope";
        }
        public String GetApocolyptic()
        {
            return GetApocolyptic(theNumber);
        }

        public static int GCD(int b, int n)
        {
            if (n == 0)
                return b;
            return GCD(n, b % n);
        }


        /**
         *  
        * @param b   first number
        * @param exp exponent
        * @param n   third number
        * @return
        */
        public static int GetPower(int b, int exp, int n)
        {
            if (exp == 0)
                return 1;
            int result = GetPower(b, exp / 2, n) % n;
            result = (result * result) % n;
            if (exp % 2 == 1)
                result = (result * b) % n;
            return result;
        }

        public static Boolean IsCarmichael(int v)
        {
            for (int b = 2; b <= v; b++)
            {
                if (GCD(b, v) == 1 && GetPower(b, v - 1, v) != 1)
                    return false;
            }
            return true;
        }

        public Boolean IsCarmichael()
        {
            return IsCarmichael(theNumber);
        }

        public static bool IsCurzon(int v)
        {
            BigInteger two = 2;
            BigInteger a = BigInteger.Pow(two, v) + 1;
            BigInteger b = 2 * v + 1;
            return a % b == 0;
        }
        public bool IsCurzon()
        {
            return IsCurzon(theNumber);
        }

        public static bool IsDePolignac(int v)
        {
            if (!isEven(v))
            {
                for (int p = 1; p < v; p++)
                {
                    if (IsPrime(p))
                    {
                        for (int k = 1; k < p; k++)
                        {
                            if(v - p == Math.Pow(2, k))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public bool IsDePolignac()
        {
            return IsDePolignac(theNumber);
        }

        public static bool isEven(int v)
        {
            return v % 2 == 0;
        }
        public bool IsEven()
        {
            return isEven(theNumber);
        }

        public static bool IsDroll(int v)
        {
            List<int> primeFactors = GetPrimeFactors(v);
            int evenTotal = 0;
            int oddTotal = 0;
            foreach (var item in primeFactors)
            {
                if (isEven(item))
                {
                    evenTotal += item;
                }
                else
                {
                    oddTotal += item;
                }
            }
            if (evenTotal > 0 && evenTotal == oddTotal)
                return true;
            return false;
        }
        public bool IsDroll()
        {
            return IsDroll(theNumber);
        }
    }
}
