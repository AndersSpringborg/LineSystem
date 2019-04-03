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
                User kurt = new User(1, "Anders", "Springborg", Console.ReadLine());
                Console.WriteLine(kurt);
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
