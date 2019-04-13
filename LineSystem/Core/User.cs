using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User : IEquatable<User>
    {
        // delegates
        #region
        private delegate void UserBalanceNotification(User user, decimal balance);
        #endregion
        // Backing Fields
        private static uint ID = 100;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        // Properties
        public uint MyId { get; private set; }
        public string FirstName
        {
            get => _firstName; set { _firstName = StringCheckSetter(value, "A-z "); }
        }
        public string LastName
        {
            get => _lastName; set { _lastName = StringCheckSetter(value, "A-z "); }
        }
        public string UserName
        {
            get => _userName; set{ _userName = StringCheckSetter(value, "A-z0-9_");}
        }
        public string Email
        {
            get => _email;
            set => _email = new EmailAddressAttribute().IsValid(value) ? value : throw new ArgumentException();
        }
        public decimal Balance
        {
            get => _balance;
        }

        public User(string firstName, string lastName, string userName, string email)
        {
            ID++;
            MyId = ID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            _balance = 0;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Email: {Email}";
        }

        private string StringCheckSetter (string value, string restriction)
        {
            if (!String.IsNullOrEmpty(value))
            {
                // Argument exception?
                return Regex.IsMatch(value, @"^[" + restriction + "]+$") 
                    ? value : throw new ArgumentException();
            }
            throw new ArgumentException();
            //throw new input exceptiop?
        }
        #region Equals and GetHAshCode
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return Equals((User)obj);
        }
        public bool Equals(User other)
        {
            if (GetHashCode() == other.GetHashCode())
            {
                return true;
            }
            return
                MyId.Equals(other.MyId) &&
                Email.Equals(other.Email) &&
                UserName.Equals(other.UserName);

        }
        public override int GetHashCode()
        {
            return
                MyId.GetHashCode() ^
                Email.GetHashCode() ^
                UserName.GetHashCode();
                    
        }
       
        #endregion

        #region Balance Methods
        private void BalanceNotificationToUser(User user, decimal balance) 
            => Console.WriteLine(user + "\nBalance over 50. Current is: " + balance);
        private void BalanceNotificationToBank(User user, decimal balance)
            => Console.WriteLine("Hi bank" + 
                user + "\nbalance over 50. Current is: " + balance);

        public decimal Withdraw(decimal amount)
        {
            UserBalanceNotification Handler = BalanceNotificationToUser;
            Handler += BalanceNotificationToBank;
            _balance -= amount;
            if (_balance <= 50)
            {
                Handler(this, _balance);
            }
            return amount;
        }
        public void Deposit(decimal amount) => _balance += amount;
        #endregion
    }
}
