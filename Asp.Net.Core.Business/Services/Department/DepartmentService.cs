using Asp.Net.Core.DataModel.Models.Department;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Asp.Net.Core.Business.Services.Department
{
    //public class DepartmentListService : IRequest<List<DepartmentEntity>>
    //{
    //}
    //public class DepartmentSaveService : IRequest<int>
    //{
    //    public DepartmentEntity Department { get; set; }
    //}
    //public class DepartmentFetchService : IRequest<List<DepartmentEntity>>
    //{
    //    public DepartmentIdEntity Department { get; set; }
    //}
    //public class DepartmentDeleteService : IRequest<int>
    //{
    //    public DepartmentIdEntity Department { get; set; }
    //}
    //public class DepartmentReportService : IRequest<DataSet>
    //{
    //    public bool Active { get; set; }
    //}

    public class DepartmentSaveService : IRequest<int>
    {
        public string DepartmentSave { get; set; }
    }
    public class DepartmentListService : IRequest<string>
    {

    }
    public class DepartmentFetchService : IRequest<string>
    {
        public string DepartmentFetch { get; set; }
    }
    public class DepartmentDeleteService : IRequest<int>
    {
        public string DepartmentDelete { get; set; }
    }
}
