using Asp.Net.Core.DataContext.InterfaceRepository.Menus;
using Asp.Net.Core.DataContext.RepositoryBases;
using Asp.Net.Core.DataModel.Models;
using Asp.Net.Core.DataModel.Models.Menus;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.Repositories.Menus
{
    public class MenusRepository : RepositoryBase, IMenusRepository
    {
        public MenusRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public async Task<String> GetMenus(MenusParamsEntity menusParams)
        {
            DynamicParameters datas = new DynamicParameters();
            var list = new List<MenusParameterDTO>();
            var obj = new MenusParameterDTO
            {
                user_id = menusParams.User_ID,
                module_id = menusParams.Module_ID
            };
            list.Add(obj);
            datas.Add("@v_txt", JsonConvert.SerializeObject(list));
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"common.fn_menu_select",
                 datas, commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }

        private List<MenuItemsEntity> GetMenusList(List<MenuEntity> menuList)
        {
            List<MenuItemsEntity> lstresult = new List<MenuItemsEntity>();

            foreach (var menu in menuList)
            {
                var tempMenu = new MenuItemsEntity
                {
                    MenuId = menu.Menu_ID,
                    DisplayName = menu.Menu_Display_Name,
                    ParentId = menu.Parent_Menu_ID,
                    Route = menu.Menu_Path,
                    IconName = "fa fa-chevron-circle-down",
                    MenuOrder = menu.Order_In_Group,
                    Rights = menu.Rights
                };
                lstresult.Add(tempMenu);
            }

            var tempMenuList = new List<MenuItemsEntity>();

            foreach (var menu in lstresult.Where(m => m.ParentId == 0))
            {
                menu.Children = GetSubMenuList(menu, lstresult);
                tempMenuList.Add(menu);
            }

            return tempMenuList.OrderBy(m => m.MenuOrder).ToList();
        }

        private List<MenuItemsEntity> GetSubMenuList(MenuItemsEntity menu, List<MenuItemsEntity> menuList)
        {
            if (menuList.Where(m => m.ParentId == menu.MenuId).ToList().Count > 0)
            {
                var list = (from m in menuList
                            where menu.MenuId == m.ParentId
                            select m).ToList();
                foreach (var m in list)
                {
                    m.Children = GetSubMenuList(m, menuList);
                }
                return list.OrderBy(m => m.MenuOrder).ToList();
            }
            else
            {
                return new List<MenuItemsEntity>();
            }
        }

        public async Task<string> getmenulist()
        {
            var response = await Connection.QueryFirstOrDefaultAsync<Table>($"common.fn_menu_list",
                 commandType: CommandType.StoredProcedure, transaction: Transaction);
            return response.Records;
        }
    }
}
