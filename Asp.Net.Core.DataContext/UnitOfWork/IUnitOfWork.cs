using Asp.Net.Core.DataContext.InterfaceRepository;
using Asp.Net.Core.DataContext.InterfaceRepository.Attendance;
using Asp.Net.Core.DataContext.InterfaceRepository.Common;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerMaster;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerSiteMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.Designation;
using Asp.Net.Core.DataContext.InterfaceRepository.Invoice;
using Asp.Net.Core.DataContext.InterfaceRepository.ManPower;
using Asp.Net.Core.DataContext.InterfaceRepository.Menus;
using System;
using Asp.Net.Core.DataContext.InterfaceRepository.Master;
using Asp.Net.Core.DataContext.InterfaceRepository.Department;
using Asp.Net.Core.DataContext.InterfaceRepository.orders;
using Asp.Net.Core.DataContext.InterfaceRepository.PayrollAttendance;
using Asp.Net.Core.DataContext.InterfaceRepository.Employeeinfo;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveType;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeSalaryMasterMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.Holiday;
using Asp.Net.Core.DataContext.InterfaceRepository.Payslip;
using Asp.Net.Core.DataContext.InterfaceRepository.SalaryComponent;
using Asp.Net.Core.DataContext.InterfaceRepository.Taxlab;

namespace ERP.UserControl.DataContext.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserAuthenticate UserAuthenticate { get; }
        IMenusRepository MenusRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }

        ImanpowerRepository ManpowerRepository { get; }

        IContractRepository ContractRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        ICountryRepository CountryRepository { get; }
        ICustomerMasterRepository CustomerMasterRepository { get; }
        ICustomerSiteMappingRepository CustomerSiteMappingRepository { get; }
        IInvoiceRepository InvoiceRepository { get; }
        IDesignationRepository DesignationRepository { get; }
        IStateRepository StateRepository { get; }

        IordersRepository OrdersRepository { get; }

        ISalaryComponentsRepository SalaryComponentsRepository { get; }
        IEmployeeSalaryRepository EmployeeLeaveRepository { get; }
        IEmployeeinfoRepository EmployeeinfoRepository { get; }
        IEmpLeaMapRepository EmpLeaMapRepository { get; }
        IEmployeeLeaveTypeRepository EmployeeLeaveTypeRepository { get; }
        IPayrollAttendanceRepository PayrollAttendanceRepository { get; }
        IHolidayRepository HolidayRepository { get; }
        ITaxslabRepository TaxslabRepository { get; }
        IPayslipRepository PayslipRepository { get; }
        void Commit();
    }
}
