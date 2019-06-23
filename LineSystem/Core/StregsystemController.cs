using System;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Core
{
    public class StregsystemController
    {
        enum commandType
        {
            User,
            Purchase,
            Multibuy
        };

        private string _commandString;
        private string[] _commandStrings;

        private User _user;
        private Product _product;

        private IStregsystem _ss;
        private IStregsystemUI _ui;
        public StregsystemController(IStregsystemUI UI, IStregsystem ss)
        {
            _ui = UI;
            _ui.CommandEntered += CommandParser;
            _ss = ss;
            //_ss.UserBalanceWarning; void UserBalanceNotification(User user, decimal balance)
        }



        private void CommandParser(string commandStrings)
        {
            _commandString = commandStrings;
            _commandStrings = _commandString.Split(' ');

            if (commandStrings[0].Equals(':'))
            {
                Console.WriteLine("[ADMIN]");
                AdminCommand();
            }
            else {
                try
                {
                    switch (CommandPattern())
                    {
                        case commandType.User:
                            DisplayUser();
                            break;
                        case commandType.Purchase:
                            Purchase();
                            break;
                        case commandType.Multibuy:
                            MultiBuy();
                            break;
                    }
                }
                catch (UserNotFoundException e)
                {
                    _ui.DisplayUserNotFound(e.UserName);
                }
                catch (ProductNotFoundException e)
                {
                    _ui.DisplayProductNotFound(e.Product);
                }
                catch (InsufficientCreditsException e)
                {
                   _ui.DisplayInsufficientCash(e.User, e.Product);
                }
                
                catch (Exception e)
                {
                    _ui.DisplayGeneralError(e.Message);
                }

            }
        }


        private void DisplayUser()
        {
            _ui.DisplayUserInfo(_user);
        }
        private void Purchase()
        {
            var transaction = _ss.BuyProduct(_user, _product);
            _ui.DisplayUserBuysProduct(transaction);
        }

        private void MultiBuy()
        {
            var count = Int32.Parse(_commandStrings[1]);
            for(int i = 0; i < count; i++)
            {
                Purchase();
            }

        }

        private commandType CommandPattern()
        {
            if (Regex.IsMatch(_commandString, @"[\w]\s[0-9]\s[0-9]"))
            {
                _user = _ss.GetUserByUsername(_commandStrings[0]);
                _product = _ss.GetProductByID(Int32.Parse(_commandStrings[2]));
                return commandType.Multibuy;
            }
            if (Regex.IsMatch(_commandString, @"[\w]\s[0-9]"))
            {
                _user = _ss.GetUserByUsername(_commandStrings[0]);
                _product = _ss.GetProductByID(Int32.Parse(_commandStrings[1]));
                return commandType.Purchase;
            }
            if (Regex.IsMatch(_commandString, @"[\w]"))
            {
                _user = _ss.GetUserByUsername(_commandStrings[0]);
                return commandType.User;
            }
            return 0;
        }
        private void AdminCommand()
        {
            
        }
    }
}