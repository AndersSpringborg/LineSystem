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
        private string _info;
        private IStregsystem _stregsystem;
        public string Command;
        public StregsystemCLI(IStregsystem stregsystem)
        {
            _stregsystem = stregsystem;
            _info = "Write your username and the product you want to buy, separated with a space";
        }


        public void DisplayUserNotFound(string username)
        {
            _info = $"User: {username}  was not fount";
        }

        public void DisplayProductNotFound(string product)
        {
            _info = $"Product: {product} was not found";
        }

        public void DisplayUserInfo(User user)
        {
            _info = user.ToString();
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            _info = $"The command \"{command}\" had too many arguments, try again with more simple command :)";
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            _info = $"\"{adminCommand}\" was not found in the system";
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            _info = transaction.ToString();
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            _info = $"You bought {count} {transaction}";
        }

        public void Close()
        {
            _running = false;
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            _info = $"sry {user.UserName}, you have insufficient cash. You are {user.Balance - product.Price} short";
        }

        public void DisplayGeneralError(string errorString)
        {
            _info = $"sry man, i relly don't get this: \"{errorString}\"";
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
            Console.Clear();
            Console.WriteLine(String.Format("{0, 4} | {1, -40} | {2}", "ID", "Product", "Price"));
            Console.WriteLine("----------------------------------------------------------");
            foreach (var product in _stregsystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(_info);
        }

        private void Prompt()
        {
            Console.Write(": ");
            Command = Console.ReadLine();
        }
    }
}
