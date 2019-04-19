using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User : IEquatable<User>, IComparable
    {

        #region delegates
        public delegate void UserBalanceNotification(User user, decimal balance);
        public UserBalanceNotification BalanceHandler = (u, b) => Console.WriteLine($"{u.ToString()} Balance: {b}");
        #endregion
        #region backing fields
        private static uint ID = 100;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        #endregion

        #region Properties
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
        public decimal Balance { get; private set;}
        #endregion
        public User(string firstName, string lastName, string userName, string email)
        {
            ID++;
            MyId = ID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Balance = 0;
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
                    ? value : throw new ArgumentException("Sting dosen't fit input guidelines");
            }
            throw new ArgumentException("String is null or empty");
        }
        #region Equals, GetHashCode CompareTo
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

        public int CompareTo (object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (GetType() == obj.GetType())
            {
                return MyId.CompareTo(((User)obj).MyId);
            }
            throw new ArgumentException("Object is not a User");
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
            Balance -= amount;
            if (Balance <= 50)
            {
                Console.WriteLine("low balance");
                BalanceHandler(this, Balance);
            }
            return amount;
        }
        public void Deposit(decimal amount)
        {
            BalanceHandler(this, Balance += amount);
        }
        #endregion

    }
}
