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
                User kurt = new User("Anders", "Springborg", "hej1");
                Console.WriteLine(kurt);
                User kurt2 = new User("Anders", "Springborg", "hej2");
                Console.WriteLine(kurt);
                Console.WriteLine(kurt2);
            }
            catch (Exception e)
            {
                Console.WriteLine("En værdi må ikke være ingenting");
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
