using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    
    public class LineSystemUI : ILineSystemUI
    {
        // backing fields
        private MainWindow Application = new MainWindow();

        public LineSystemUI(MainWindow application)
        {
            Application = application;
        }


        public event StregsystemEvent CommandEntered;

        public void Close()
        {
            Application.Close();
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            throw new NotImplementedException();
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

        public delegate void StregsystemEvent(string command);
    }
}
