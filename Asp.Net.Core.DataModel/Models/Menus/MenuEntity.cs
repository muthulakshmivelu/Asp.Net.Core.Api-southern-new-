using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.DataModel.Models.Menus
{
    public class MenuItemsEntity
    {
        public int MenuId { get; set; }
        public string DisplayName { get; set; }
        public string IconName { get; set; }
        public int MenuOrder { get; set; }
        public string Route { get; set; }
        public List<MenuItemsEntity> Children { get; set; }
        public int? ParentId { get; set; }
        public List<Rights_Master> Rights { get; set; }
    }

    public class Rights_Master
    {
        public bool Status { get; set; }
        public int Right_ID { get; set; }
        public string Right_Name { get; set; }
    }

    public class MenusParamsEntity
    {
        public int User_ID { get; set; }
        public int Module_ID { get; set; }
    }

    public class MenusParameterDTO
    {
        public int user_id { get; set; }
        public int module_id { get; set; }
    }

    public class MenuEntity
    {
        public int Menu_ID { get; set; }
        public int Module_ID { get; set; }
        public string Menu_Display_Name { get; set; }
        public string Menu_Path { get; set; }
        public bool Is_Menu_Group { get; set; }
        public int? Parent_Menu_ID { get; set; }
        public bool Admin { get; set; }
        public int Order_In_Group { get; set; }
        public List<Rights_Master> Rights { get; set; }
        public bool Active { get; set; }
    }
}
