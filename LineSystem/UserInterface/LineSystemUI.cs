using System;
using Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserInterface
{
    
    public class LineSystemUI : ILineSystemUI
    {
        // backing fields
        private Stregsystem _stregsystem;
        private MainWindow _app;
        public event StregsystemEvent CommandEntered
        {
        }

        public LineSystemUI(Stregsystem stregsystem)
        {
            _stregsystem = stregsystem;
            
        }

        public void Close()
        {
            _app.Close();
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
             _app.CommandOutput.Text = "The admin input " + adminCommand + " is not a valid command.";
        }

        public void DisplayGeneralError(string errorString)
        {
             _app.CommandOutput.Text = $"There was a general error: {errorString}";
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
             _app.CommandOutput.Text = $"{user.UserName} you don't have sufficient cash to purchase {product.ToString()}";
        }

        public void DisplayProductNotFound(string product)
        {
            _app.CommandOutput.Text = $"{product} was not found in the database";
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            _app.CommandOutput.Text = $"{command} have too many arguments, try a different command";
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            _app.CommandOutput.Text = $"Transaction: {transaction} is completed. You can take your product now.";
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserNotFound(string username)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _app = new MainWindow();
        }

    }
}
