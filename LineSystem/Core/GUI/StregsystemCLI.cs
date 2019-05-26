using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using StregSystem;
using StregSystem.GUI;

namespace Core.GUI
{
    public class StregsystemCLI :  IStregsystemUI
    {
        



        public void DisplayUserNotFound(string username)
        {
            throw new NotImplementedException();
        }

        public void DisplayProductNotFound(string product)
        {
            throw new NotImplementedException();
        }

        public void DisplayUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            throw new NotImplementedException();
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
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

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public void DisplayGeneralError(string errorString)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {

        }

        public event StregsystemEvent CommandEntered;
    }
}
