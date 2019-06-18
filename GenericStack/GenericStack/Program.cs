using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> teststack = new Stack<string>();
            for (int i = 0; i < 400; i++)
            {
                teststack.Push(i.ToString());
            }
            foreach (var item in teststack)
            {
                Console.WriteLine(item);
            }

        }


    }
}
