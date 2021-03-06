using Model;
using Sims_Hospital_Zdravo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_Hospital_Zdravo.Controller
{
    public class AccountController
    {
        private AccountService accountService;

        public AccountController(AccountService accService)
        {
            accountService = accService;
        }

        public void Create(User account)
        {
            accountService.Create(account);
        }

        public List<User> FindAll()
        {
            return  accountService.FindAll();
        }

        public void Update(User account)
        {
            accountService.Update(account);
        }

        public void Delete(User account)
        {
            accountService.Delete(account);
        }

        public User FindAccountById(int id)
        {
            return accountService.FindAccountById(id);
        }

        public User GetAccountByUsernameAndPassword(String username, String password)
        {
            return accountService.GetAccountByUsernameAndPassword(username, password);
        }


        public User GetLoggedAccount()
        {
            return accountService.GetLoggedAccount();
        }

        public void Login(String username, String password)
        {
            accountService.Login(username, password);
        }

        public void Logout()
        {
            accountService.Logout();
        }
    }
}