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
                User kurt = new User("Anders", "Springborg", "888_aaen", "aaspringborg@gmail.com");
                Console.WriteLine(kurt);
                User kurt2 = new User("Ugler", "Mosen", "skrrt69_", "lil@spurt.onTheBeat");
                Console.WriteLine(kurt);
                Console.WriteLine(kurt2);
                Console.WriteLine();

                kurt.Withdraw(100);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Keep within input guidelines");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
