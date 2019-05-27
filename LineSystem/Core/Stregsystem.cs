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
        private readonly List<Product> _products = new List<Product>();
        public Stregsystem()
        {
            ProductLoading();
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
        public IEnumerable<Product> ActiveProducts => _products;

        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public User GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public event UserBalanceNotification UserBalanceWarning;
    }

}
