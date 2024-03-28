using Asp.Net.Core.DataModel.Models.Department;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.Core.DataContext.InterfaceRepository.Department
{
    public interface IDepartmentRepository
    {
        //Task<List<DepartmentEntity>> GetDepartmentList();
        //Task<int> DeartmentSave(DepartmentEntity value);
        //Task<List<DepartmentEntity>> DepartmentFetch(DepartmentIdEntity value);
        //Task<int> DepartmentDelete(DepartmentIdEntity value);
        //Task<DataSet> DepartmentListReport(bool Active);
        Task<int> DepartmentSave(string value);
        Task<string> DepartmentList();
        Task<string> DepartmentFetch(string value);
        Task<int> DepartmentDelete(string value);
    }
}
