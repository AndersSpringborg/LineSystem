using System;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class User
    {
        // Backing Fields
        private static uint ID = 100;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;

        // Properties
        public uint MyId { get; private set; }
        public string FirstName
        {
            get => _firstName; set { _firstName = StringCheckSetter(value, "A-z"); }
        }
        public string LastName
        {
            get => _lastName; set { _lastName = StringCheckSetter(value, "A-z"); }
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

        public User(string firstName, string lastName, string userName, string email)
        {
            ID++;
            MyId = ID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FirstName} " +
                $"{LastName} " +
                $"\n -----> ID:{MyId.ToString().PadLeft(6, '0')} " +
                $"Username: {UserName}" +
                $"\n        Email: {Email}";
        }

        private string StringCheckSetter (string value, string restriction)
        {
            if (!String.IsNullOrEmpty(value))
            {
                // Argument exception?
                return Regex.IsMatch(value, @"^[" + restriction + "]+$") ? value : throw new ArgumentException();
            }
            throw new ArgumentException();
            //throw new input exceptiop??


        }
    }
}
