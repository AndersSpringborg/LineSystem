using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class User
    {
        // Backing Fields
        private string _firstName;
        private string _lastName;
        private string _userName;

        // Properties
        public uint ID { get; set; }
        public string FirstName { get => _firstName; set { _firstName = StringCheckSetter(value, @"[A-z]"); } }
        public string LastName { get => _lastName; set { _lastName = StringCheckSetter(value, @"[A-z]"); } }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = StringCheckSetter(value, @"[a-zA-Z0-9]");
            }
        }

        public User(uint iD, string firstName, string lastName, string userName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }

        public override string ToString() => $"{FirstName} {LastName} \n -----> ID: {ID.ToString().PadLeft(6, '0')} Username: {UserName}";

        private string StringCheckSetter (string value, string restriction)
        {
            return Regex.IsMatch(value, restriction) ? value : throw new ArgumentException("value stemmer ikke overens med krav (checkfunction)");
        }
    }
}
