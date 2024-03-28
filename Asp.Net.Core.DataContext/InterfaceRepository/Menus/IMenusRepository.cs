using Asp.Net.Core.DataModel.Models.Menus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Menus
{
    public interface IMenusRepository
    {
        Task<String> GetMenus(MenusParamsEntity menusParams);
        Task<string> getmenulist();
    }
}
