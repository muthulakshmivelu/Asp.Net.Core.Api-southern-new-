using Asp.Net.Core.DataModel.Models.Menus;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Asp.Net.Core.Business.Services.Contract;

namespace Asp.Net.Core.Business.Services.Menus
{
    public class MenusHandler : IRequestHandler<MenusService, String>
    {
        private readonly IUnitOfWork unitOfWork;
        public MenusHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<String> Handle(MenusService request, CancellationToken cancellationToken)
        {
            var menusparams = new MenusParamsEntity()
            {
                User_ID = request.User_ID,
                Module_ID = request.Module_ID
            };
            var result = await unitOfWork.MenusRepository.GetMenus(menusparams);
            return result;
        }
    }
    public class getmenulistHandler : IRequestHandler<getmenulistService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public getmenulistHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(getmenulistService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.MenusRepository.getmenulist();
            return user;
        }
    }
}
