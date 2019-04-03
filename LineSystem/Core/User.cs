using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class User
    {
        class User
        {
            // Backing Fields
            private string _firstName;
            private string _lastName;
            private string _userName;
            
            // Properties
            public uint ID { get; set; }
            public string FirstName { get => _firstName; set { CheckSetter(value, v => v.All(Char.IsLetter), ref _firstName); } }
            public string LastName { get => _lastName; set { CheckSetter(value, v => v.All(Char.IsLetter), ref _lastName); } }
            public string UserName
            {
                get
                {
                    return _userName;
                }
                set
                {
                    CheckSetter(value, v => v.All(Char.IsLetterOrDigit), ref _userName);

                    //if (value.All(Char.IsLetterOrDigit))
                    //    _userName = value;
                    //else
                    //{
                    //    _userName = "Forkert navn";
                    //    throw new Exception();
                    //}
                }
            }

            // Methods
            public User(uint iD, string firstName, string lastName, string userName)
            {
                ID = iD;
                FirstName = firstName;
                LastName = lastName;
                UserName = userName;
            }

            public override string ToString() => $"{FirstName} {LastName} \n\tID: {ID.ToString().PadLeft(10)} Username: {UserName}";

            // Genereic function, that valides an input. Validates in line with the methods parameter
            private void CheckSetter<T>(T value, Predicate<T> checkFunction, ref T field)
            {
                field = checkFunction(value) ? value : throw new ArgumentException("value stemmer ikke overens med krav (checkfunction)");
                //if (checkFunction(value))
                //{
                //    field = value;
                //}
                //else
                //{
                //    throw new ArgumentException("value stemmer ikke overens med krav (checkfunction)");
                //}
            }
        }
