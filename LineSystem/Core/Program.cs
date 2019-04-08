using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                User kurt = new User("Anders", "Springborg", "888_aaen");
                Console.WriteLine(kurt);
                User kurt2 = new User("anders", "Springborg", "aaen");
                Console.WriteLine(kurt);
                Console.WriteLine(kurt2);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("En værdi må ikke være ingenting");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
