using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class StregsystemCLI : IStregsystemUI
    {
        public event StregsystemEvent CommandEntered;
        private bool _running = true;
        private IStregsystem _stregsystem;
        public string Command;
        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
        }


        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User: {username}  was not fount");    
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"Product: {product} was not found");
        }

        public void DisplayUserInfo(User user)
        {
            Console.WriteLine(user.ToString());
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"The command \"{command}\" had too many arguments, try again with more simple command :)");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"\"{adminCommand}\" was not found in the system");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction.ToString());
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine($"You bought {count} {transaction}");
        }

        public void Close()
        {
            _running = false;
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.WriteLine($"sry {user.UserName}, you have insufficient cash. You are {user.Balance - product.Price} short");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"sry man, i relly don't get this: \"{errorString}\"");
        }

        public void Start()
        {
            do
            {
                Draw();
                Prompt();
                if (CommandEntered != null) CommandEntered(Command);
            } while (_running);
        }

        private void Draw()
        {
            Console.WriteLine("Write your username and the product you want to buy, separated with a space");
            Console.WriteLine(String.Format("{0, 4} | {1, -40} | {2}", "ID", "Product", "Price"));
            Console.WriteLine("----------------------------------------------------------");
            foreach (var product in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------------");
        }

        private void Prompt()
        {
            Console.Write(": ");
            Command = Console.ReadLine();
        }
    }
}
