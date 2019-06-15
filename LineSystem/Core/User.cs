using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User : IComparable
    {
        public UserBalanceNotification UserBalanceNotification;
        // Backing Fields
        private static uint _id = 100;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        // Properties
        public uint MyId { get; }
        public string FirstName
        {
            get => _firstName; set => _firstName = StringCheckSetter(value, "A-z");
        }
        public string LastName
        {
            get => _lastName; set => _lastName = StringCheckSetter(value, "A-z");
        }
        public string UserName
        {
            get => _userName; set => _userName = StringCheckSetter(value, "A-z0-9_");
        }

        public string Email
        {
            get => _email;
            set => _email = new EmailAddressAttribute().IsValid(value) ? value : "";
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                if (Balance <= 50)
                {
                    UserBalanceNotification(this, Balance);
                }
            }
        }
        
        // Methods
        public User(string firstName, string lastName, string userName, string email)
        {
            MyId = _id++;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} \n" +
                   $" -----> ID:{MyId,0000} Email: {Email}";
        }

        private string StringCheckSetter (string value, string restriction)
        {
            if (!String.IsNullOrEmpty(value))
            {
                return Regex.IsMatch(value, @"^[" + restriction + "]+$") ? value : "syntax error";
            }
            return "";
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            User u = obj as User;
            if ((System.Object)u == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (MyId == u.MyId) && (Email == u.Email);
        }

        public bool Equals(User p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (MyId == p.MyId) && (Email == p.Email);
        }

        public override int GetHashCode()
        {
            return
                (Int32)MyId ^ 
                Int32.Parse(UserName) ^
                Int32.Parse(Email);
        }

        public int CompareTo(object obj)
        {
            return MyId.CompareTo(MyId);
        }
    }
}
