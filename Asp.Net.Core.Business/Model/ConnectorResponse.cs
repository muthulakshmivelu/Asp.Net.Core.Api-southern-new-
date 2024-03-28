using System;
using System.Collections.Generic;

namespace Asp.Net.UserControl.Business.Model
{
    public class ConnectorResponse
    {
        public string TokenType { get; set; }

        public string Token { get; set; }

        public DateTime ExpiredAt { get; set; }

        //public List<MenuItemsEntity> menuItems {get;set;} 
    }
}