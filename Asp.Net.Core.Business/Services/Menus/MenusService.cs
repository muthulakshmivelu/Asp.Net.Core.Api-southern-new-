using Asp.Net.Core.DataModel.Models.Menus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Menus
{
    public class MenusService : IRequest<String>
    {
        public int User_ID { get; set; }
        public int Module_ID { get; set; }
    }
    public class getmenulistService : IRequest<string>
    {

    }
}
