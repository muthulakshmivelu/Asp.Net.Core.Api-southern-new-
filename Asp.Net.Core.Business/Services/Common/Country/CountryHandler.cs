using Asp.Net.Core.Business.Services.Contract;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Asp.Net.Core.Business.Services.Common.Country
{

    public class CountrySaveHandler : IRequestHandler<CountrySaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CountrySaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountrySaveService request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.CountryRepository.CountrySave(request.Country);
            unitOfWork.Commit();
            return data;
        }
    }

    public class CountryListHandler : IRequestHandler<CountryListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CountryListService request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.CountryRepository.CountryList(request.Country);
            return data;
        }
    }

    public class CountryByIdHandler : IRequestHandler<CountryByIdService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryByIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(CountryByIdService request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.CountryRepository.CountryById(request.Country);
            return data;
        }
    }

    public class CountryDeleteHandler : IRequestHandler<CountryDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public CountryDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CountryDeleteService request, CancellationToken cancellationToken)
        {
            var data = await unitOfWork.CountryRepository.CountryDelete(request.Country);
            unitOfWork.Commit();
            return data;
        }
    }
}
