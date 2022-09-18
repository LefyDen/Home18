using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home18
{
    class Class1 : Hoper
    {

        public int Hope { get; set; }
        public void PublicMethod()
        {
            Console.WriteLine("Killer Queen!");
        }
        int Hoper.PublicMethodReturn(int A)
        {
            int a = 4;

            a = A;
            return a;
        }




    }
    interface Hoper
    {
        public int PublicMethodReturn(int A);
    }
}
