using Asp.Net.Core.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository
{
    public interface IUserAuthenticate
    {
        Task<Users> Login(string User_Name, string Password);
        //long EncryptKey(string key);
    }
}
