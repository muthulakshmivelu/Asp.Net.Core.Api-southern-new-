using Asp.Net.Core.Business.Services.Designation;
using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.DataModel.Models.Department;
using MediatR;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Net.Core.Business.Services.Department
{
    //public class DepartmentListHandler : IRequestHandler<DepartmentListService, List<DepartmentEntity>>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public DepartmentListHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<List<DepartmentEntity>> Handle(DepartmentListService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.DepartmentRepository.GetDepartmentList();
    //        return user;
    //    }
    //}

    //public class DepartmentSaveHandler : IRequestHandler<DepartmentSaveService, int>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public DepartmentSaveHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<int> Handle(DepartmentSaveService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.DepartmentRepository.DeartmentSave(request.Department);
    //        unitOfWork.Commit();
    //        return user;
    //    }
    //}

    //public class DepartmentFetchHandler : IRequestHandler<DepartmentFetchService, List<DepartmentEntity>>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public DepartmentFetchHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<List<DepartmentEntity>> Handle(DepartmentFetchService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.DepartmentRepository.DepartmentFetch(request.Department);
    //        return user;
    //    }
    //}

    //public class DepartmentDeleteHandler : IRequestHandler<DepartmentDeleteService, int>
    //{
    //    private readonly IUnitOfWork unitOfWork;

    //    public DepartmentDeleteHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }

    //    public async Task<int> Handle(DepartmentDeleteService request, CancellationToken cancellationToken)
    //    {
    //        var user = await unitOfWork.DepartmentRepository.DepartmentDelete(request.Department);
    //        unitOfWork.Commit();
    //        return user;
    //    }
    //}
    //public class DepartmentListReporteHandler : IRequestHandler<DepartmentReportService, DataSet>
    //{
    //    private readonly IUnitOfWork unitOfWork;
    //    public DepartmentListReporteHandler(IUnitOfWork unitOfWork)
    //    {
    //        this.unitOfWork = unitOfWork;
    //    }
    //    public async Task<DataSet> Handle(DepartmentReportService request, CancellationToken cancellationToken)
    //    {
    //        var result = await unitOfWork.DepartmentRepository.DepartmentListReport(request.Active);
    //        unitOfWork.Commit();
    //        return result;
    //    }
    //}

    public class DepartmentSaveHandler : IRequestHandler<DepartmentSaveService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentSaveHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DepartmentSaveService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DepartmentRepository.DepartmentSave(request.DepartmentSave);
            unitOfWork.Commit();
            return user;
        }
    }

    public class DepartmentListHandler : IRequestHandler<DepartmentListService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentListHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DepartmentListService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DepartmentRepository.DepartmentList();
            return user;
        }
    }
    public class DepartmentFetchHandler : IRequestHandler<DepartmentFetchService, string>
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentFetchHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(DepartmentFetchService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DepartmentRepository.DepartmentFetch(request.DepartmentFetch);
            unitOfWork.Commit();
            return user;
        }
    }

    public class DepartmentDeleteHandler : IRequestHandler<DepartmentDeleteService, int>
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentDeleteHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DepartmentDeleteService request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.DepartmentRepository.DepartmentDelete(request.DepartmentDelete);
            unitOfWork.Commit();
            return user;
        }
    }

}
