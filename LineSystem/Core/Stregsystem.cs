using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Core
{
    public delegate void UserBalanceNotification(User user, decimal balance);
    class Stregsystem : IStregsystem
    {
        private StreamWriter _logFile;
        private List<Transaction> _transactions = new List<Transaction>();
        private readonly List<Product> _products = new List<Product>();
        private readonly List<User> _users = new List<User>();
        public event UserBalanceNotification UserBalanceWarning;
        public IEnumerable<Product> ActiveProducts => _products.Where(x => x.Active);


        public Stregsystem()
        {
            ProductLoading();
            UserLoading();
            _logFile = File.AppendText(@"..\..\..\InputFiles\Log.txt");
        }

        public static void Log(string logMessage, TextWriter logFile)
        {
            logFile.Write("\r\nLog Entry : ");
            logFile.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            logFile.WriteLine("  :");
            logFile.WriteLine($"  :{logMessage}");
            logFile.WriteLine("-------------------------------");
        }

        private void ProductLoading()
        {
            
            var reader = new StreamReader(@"..\..\..\InputFiles\products.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var lineRead = reader.ReadLine()?.Split(';');
                if (lineRead != null)
                {
                    var id = Int32.Parse(lineRead[0]);
                    var name = Regex.Replace(lineRead[1], "\"", "");
                    var price = Decimal.Parse(lineRead[2]);
                    var active = lineRead[3] == "1"; 
                    _products.Add(new Product(id, name, price, active));
                }
            }
        }

        private void UserLoading()
        { 
            var reader = new StreamReader(@"..\..\..\InputFiles\userbase.csv");
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var lineRead = reader.ReadLine()?.Split(';');
                if (lineRead != null)
                {
                    var firstname = Regex.Replace(lineRead[0], "\"", "");
                    var lastname = Regex.Replace(lineRead[1], "\"", "");
                    var username = Regex.Replace(lineRead[2], "\"", "");
                    var email = Regex.Replace(lineRead[3], "\"", "");
                    var newUser = new User(firstname, lastname, username, email);
                    newUser.UserBalanceNotification = UserBalanceWarning;
                    _users.Add(newUser);
                }
            }
        }


        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            var newTransaction = new InsertCashTransaction(user, amount);
            return newTransaction;
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            _transactions.Add(transaction);
            Log(transaction.ToString(), _logFile);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction newTransaction;
            try
            {
                newTransaction = new BuyTransaction(user, product);
            }
            catch (InsufficientCreditsException e)
            {
                throw;
            }
            ExecuteTransaction(newTransaction);
            return newTransaction;

        }

        public Product GetProductByID(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions
                .Where(x => x.User.Equals(user))
                .Reverse()
                .Take(count);
        }

        public User GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate).First();
        }

        public User GetUserByUsername(string username)
        {
            var User = _users.Find(x => x.UserName.Equals(username));
            if (User != null)
            {
                return User;
            }

            throw new UserNotFoundException(username, "User not found");
        }
    }

    internal class UserNotFoundException : Exception
    {
        public string UserName;
        public UserNotFoundException(string userName, string s) : base(s)
        {
            UserName = userName;
        }
    }
    internal class ProductNotFoundException : Exception
    {
        public string Product;
        public ProductNotFoundException(string product, string s) : base(s)
        {
            Product = product;
        }
    }
}
