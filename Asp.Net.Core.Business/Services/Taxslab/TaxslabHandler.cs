using ERP.UserControl.DataContext.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Taxslab
{
    public class TaxslabHandler : IRequestHandler<TaxslabService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public TaxslabHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(TaxslabService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.TaxslabRepository.TaxslabSave(request.TaxslabSave);
            unitOfWork.Commit();
            return user;
        }
    }
    public class TaxslabListHandler : IRequestHandler<TaxslabListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public TaxslabListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(TaxslabListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.TaxslabRepository.TaxslabList();
            return user;
        }
    }


    public class TaxslabDeleteHandler : IRequestHandler<TaxslabDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public TaxslabDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(TaxslabDeleteService request, CancellationToken cancellationToken)
        {

            var user = await unitOfWork.TaxslabRepository.TaxslabDelete(request.taxslabid);
            unitOfWork.Commit();
            return user;
        }

    }

}
