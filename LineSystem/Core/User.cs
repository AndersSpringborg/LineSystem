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
        private static uint ID = 100;
        private uint _myId;
        private string _firstName;
        private string _lastName;
        private string _userName;

        // Properties
        public uint MyId { get { return _myId; } }
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

        public User(string firstName, string lastName, string userName)
        {
            ID++;
            _myId = ID;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }

        public override string ToString() => $"{FirstName} {LastName} \n -----> ID: {ID.ToString().PadLeft(6, '0')} Username: {UserName}";

        private string StringCheckSetter (string value, string restriction)
        {
            if (!String.IsNullOrEmpty(value))
            {
                // Argument exception?
                return Regex.IsMatch(value, @"^[" + restriction + "]+$") ? value : throw new ArgumentException(restriction);
            }
            throw new Exception();
            //throw new input exceptiop??


        }
    }
}
