using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.salarycomponent
{
    public class SalaryComponentsSaveHandler: IRequestHandler<SalaryComponentSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public SalaryComponentsSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SalaryComponentSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.SalaryComponentsRepository.SalaryComponentSave(request.SalaryComponentSave);
            unitOfWork.Commit();
            return user;
        }
        public class SalaryComponentListHandler : IRequestHandler<SalaryComponentListService, string>
        {
            private readonly IUnitOfWork unitOfWork;

            public SalaryComponentListHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<string> Handle(SalaryComponentListService request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.SalaryComponentsRepository.SalaryComponentList();
                return user;
            }
        }
        //public class SalaryComponentFetchHandler : IRequestHandler<SalaryComponentFetchService, string>
        //{
        //    private readonly IUnitOfWork unitOfWork;

        //    public SalaryComponentFetchHandler(IUnitOfWork unitOfWork)
        //    {
        //        this.unitOfWork = unitOfWork;
        //    }

        //    public async Task<string> Handle(SalaryComponentFetchService request, CancellationToken cancellationToken)
        //    {
        //        var user = await unitOfWork.SalaryComponentsRepository.SalaryComponentFetch(request.SalaryComponentFetch);
        //        unitOfWork.Commit();
        //        return user;
        //    }
        //}
        public class SalaryComponentDeleteHandler : IRequestHandler<SalaryComponentDeleteService, int>
        {
            private readonly IUnitOfWork unitOfWork;

            public SalaryComponentDeleteHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<int> Handle(SalaryComponentDeleteService request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.SalaryComponentsRepository.SalaryComponentDelete(request.SalaryComponentDelete);
                unitOfWork.Commit();
                return user;
            }
        }

    }
}
