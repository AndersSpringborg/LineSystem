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

        private MainWindow Application = new MainWindow();
        public event StregsystemEvent CommandEntered;

        public LineSystemUI(MainWindow application)
        {
            Application = application;
        }

        public void Close()
        {   
            Application.Close();
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            MessageBox.Show("The admin input " + adminCommand + " is not a valid command.", "Input invalid", MessageBoxButton.OK);
        }

        public void DisplayGeneralError(string errorString)
        {
            MessageBox.Show($"There was a general error: {errorString}", "General error", MessageBoxButton.OK);
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            MessageBox.Show($"{user.UserName} you don't have sufficient cash to purchase {product.ToString()}" , "Black hole discovered", MessageBoxButton.OK);
        }

        public void DisplayProductNotFound(string product)
        {
            throw new NotImplementedException();
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

    }
}
