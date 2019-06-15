using System;

namespace Core
{
    public abstract class Transaction
    {
        public readonly int Id;
        protected static int _id;
        public User User;
        public DateTime Date;
        public decimal Amount;

        public override string ToString()
        {
            return $"ID: {Id,00000}| {User} | Amount:{Amount,-5} | {Date.Day}";
        }

        public abstract void Execute();

        protected Transaction(User user, decimal amount)
        {
            User = user;
            Id = _id++;
            Amount = amount;
            Date = DateTime.Now;
        }
    }

    public class BuyTransaction : Transaction
    {
        public Product Product;
        public BuyTransaction(User user, Product product) : base(user, product.Price )
        {
            Product = product;
        }

        public override void Execute()
        {
            User.Balance -= User.Balance - Amount < 0 ? throw new InsufficientCreditsException(User, Product) : Amount;
        }

        public override string ToString() => "PURCHASE" + base.ToString();
    }

    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount) { }

        public override void Execute()
        {
            User.Balance += Amount;
        }

        public override string ToString() => "DEPOSIT " + base.ToString();
    }

    public class InsufficientCreditsException : Exception
    {
        public Product Product;
        public User User;
        public override string Message => $"The User {User} don't have enough credit on his account";

        public InsufficientCreditsException(User user, Product product) : base()
        {
            User = user;
            Product = product;
        }
        public InsufficientCreditsException() : base() { }
        public InsufficientCreditsException(string s) : base(s) { }
        public InsufficientCreditsException(string s, Exception ex): base(s, ex) { }
    }
}