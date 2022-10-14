using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberTheory.Square(21));
            Console.WriteLine(NumberTheory.Cube(21));
            Console.WriteLine(NumberTheory.IsPrime(7));
            List<int> theList = NumberTheory.getCollatz(27);
            foreach(int number in theList)
            {
                Console.Write(number.ToString() + " " );
            }
            Console.WriteLine();
            Console.WriteLine("Get Jugglers:");
            List<int> jugList = NumberTheory.GetJugglers(37);
            foreach (int number in jugList)
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine();
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine(i + " " + NumberTheory.GetFactorial(i));
            }



            NumberTheory instance = new NumberTheory(52);
            Console.WriteLine(instance.TheNumber);
            Console.WriteLine(instance.Square());
            Console.WriteLine(instance.Cube());
            Console.WriteLine(instance.IsPrime());
            theList.Clear();
            instance.TheNumber = 27;
            theList = instance.GetCollatz();
            foreach (int number in theList)
            {
                Console.Write(number.ToString() + " ");
            }
            Console.WriteLine();
            jugList.Clear();
            jugList = instance.GetJugglers();
            Console.WriteLine("Get Jugglers:");
            foreach (int number in jugList)
            {
                Console.Write(number.ToString() + " ");
            }

            Console.WriteLine("Pell list");
            foreach (var item in NumberTheory.GetPellList(10))
            {
                Console.Write(item + " " ) ;
            }

            Console.WriteLine("Pell numbers");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i + " " + NumberTheory.GetPell(i));
            }
                                 
            Console.ReadKey();
        }
    }
}
