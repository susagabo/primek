using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class prime_searcher
    { 
        void prim_szam(long szam)
        {
            bool Prim_e = true;
            for (int i = 0; i <= szam; i++)
            {
                for (int j = 2; j <= szam; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        Prim_e = false;
                        break;
                    }
                }
                if (Prim_e)
                {
                    Console.WriteLine("Prim:" + i);
                }
                Prim_e = true;
            }
        }
       
    }
}
    

