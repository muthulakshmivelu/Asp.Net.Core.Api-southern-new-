using Asp.Net.Core.DataContext.InterfaceRepository;
using Asp.Net.Core.DataContext.InterfaceRepository.Attendance;
using Asp.Net.Core.DataContext.InterfaceRepository.Common;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerMaster;
using Asp.Net.Core.DataContext.InterfaceRepository.Contract.CustomerSiteMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.Department;
using Asp.Net.Core.DataContext.InterfaceRepository.Designation;
using Asp.Net.Core.DataContext.InterfaceRepository.Invoice;
using Asp.Net.Core.DataContext.InterfaceRepository.ManPower;
using Asp.Net.Core.DataContext.InterfaceRepository.Master;
using Asp.Net.Core.DataContext.InterfaceRepository.Menus;
using Asp.Net.Core.DataContext.Repositories;
using Asp.Net.Core.DataContext.Repositories.Attendance;
using Asp.Net.Core.DataContext.Repositories.Contract;
using Asp.Net.Core.DataContext.Repositories.Contract.CustomerMaster;
using Asp.Net.Core.DataContext.Repositories.Contract.CustomerSiteMapping;
using Asp.Net.Core.DataContext.Repositories.Country;
using Asp.Net.Core.DataContext.Repositories.Department;
using Asp.Net.Core.DataContext.Repositories.Designation;
using Asp.Net.Core.DataContext.Repositories.Invoice;
using Asp.Net.Core.DataContext.Repositories.ManPower;
using Asp.Net.Core.DataContext.Repositories.Master;
using Asp.Net.Core.DataContext.Repositories.Menus;
using Asp.Net.Core.DataModel.DBContext;
using Npgsql;
using ERP.UserControl.DataContext.UnitOfWork;
using System;
using System.Data;
using System.Data.SqlClient;
using Asp.Net.Core.DataContext.InterfaceRepository.orders;
using Asp.Net.Core.DataContext.Repositories.orders;
using Asp.Net.Core.DataContext.InterfaceRepository.Employeeinfo;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeLeaveType;
using Asp.Net.Core.DataContext.InterfaceRepository.EmployeeSalaryMasterMapping;
using Asp.Net.Core.DataContext.InterfaceRepository.Holiday;
using Asp.Net.Core.DataContext.InterfaceRepository.PayrollAttendance;
using Asp.Net.Core.DataContext.InterfaceRepository.Payslip;
using Asp.Net.Core.DataContext.InterfaceRepository.SalaryComponent;
using Asp.Net.Core.DataContext.InterfaceRepository.Taxlab;
using Asp.Net.Core.DataContext.Repositories.Employeeinfo;
using Asp.Net.Core.DataContext.Repositories.EmployeeLeaveMapping;
using Asp.Net.Core.DataContext.Repositories.EmployeeLeaveType;
using Asp.Net.Core.DataContext.Repositories.EmployeeSalaryMasterMapping;
using Asp.Net.Core.DataContext.Repositories.Holiday;
using Asp.Net.Core.DataContext.Repositories.PayrollAttendance;
using Asp.Net.Core.DataContext.Repositories.Payslip;
using Asp.Net.Core.DataContext.Repositories.SalaryComponent;
using Asp.Net.Core.DataContext.Repositories.Taxlab;

namespace Asp.Net.UserControl.DataContext.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection connection;
        private IDbTransaction transaction;
        private bool disposed;

        private IUserAuthenticate userAuthenticate;
        private IMenusRepository menusRepository;
        private IDepartmentRepository departmentRepository;
        private IReportRepository reportRepository;
        private ImanpowerRepository manpowerRepository;
        private IContractRepository contractRepository;
        private IAttendanceRepository attendanceRepository;
        private ICountryRepository countryRepository;
        private ICustomerMasterRepository customerMasterRepository;
        private ICustomerSiteMappingRepository customerSiteMappingRepository;
        private IInvoiceRepository invoiceRepository;
        private IDesignationRepository designationRepository;
        private IStateRepository stateRepository;
        private IordersRepository ordersRepository;
        private ISalaryComponentsRepository salarycomponentsRepository;
        private IEmployeeSalaryRepository employeesalaryRepository;
        public IEmployeeinfoRepository employeeinfoRepository;
        public IEmpLeaMapRepository empleaMapRepository;
        public IEmployeeLeaveTypeRepository employeeleaveTypeRepository;
        public IPayrollAttendanceRepository payrollAttendanceRepository;
        public IHolidayRepository holidayRepository;
        public ITaxslabRepository taxslabRepository;
        public IPayslipRepository payslipRepository;

        //public UnitOfWork(string connectionString)
        //{
        //    connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    transaction = connection.BeginTransaction();
        //}

        public UnitOfWork(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
            transaction = connection.BeginTransaction();
        }
       
        public IUserAuthenticate UserAuthenticate
        {
            get { return userAuthenticate ?? (userAuthenticate = new UserAuthenticate(transaction)); }
        }

        public IMenusRepository MenusRepository
        {
            get { return menusRepository ?? (menusRepository = new MenusRepository(transaction)); }
        }

        public IDepartmentRepository DepartmentRepository
        {
            get { return departmentRepository ?? (departmentRepository = new DepartmentRepository(transaction)); }
        }
        public ImanpowerRepository ManpowerRepository
        {
            get { return manpowerRepository ?? (manpowerRepository = new ManpowerRepository(transaction)); }
        }
        public IContractRepository ContractRepository
        {
            get { return contractRepository ?? (contractRepository = new ContractRepository(transaction)); }
        }
        public IAttendanceRepository AttendanceRepository
        {
            get { return attendanceRepository ?? (attendanceRepository = new AttendanceRepository(transaction)); }
        }
        public ICountryRepository CountryRepository
        {
            get { return countryRepository ?? (countryRepository = new CountryRepository(transaction)); }
        }
        public ICustomerMasterRepository CustomerMasterRepository
        {
            get { return customerMasterRepository ?? (customerMasterRepository = new CustomerMasterRepository(transaction)); }
        }
        public ICustomerSiteMappingRepository CustomerSiteMappingRepository
        {
            get { return customerSiteMappingRepository ?? (customerSiteMappingRepository = new CustomerSiteMappingRepository(transaction)); }
        }
        public IInvoiceRepository InvoiceRepository
        {
            get { return invoiceRepository ?? (invoiceRepository = new InvoiceRepository(transaction)); }
        }
        public IDesignationRepository DesignationRepository
        {
            get { return designationRepository ?? (designationRepository = new DesignationRepository(transaction)); }
        }
        public IStateRepository StateRepository
        {
            get { return stateRepository ?? (stateRepository = new StateRepository(transaction)); }
        }

        public IordersRepository OrdersRepository
        {
            get { return ordersRepository ?? (ordersRepository = new OrdersRepository(transaction)); }
        
        }


        public ISalaryComponentsRepository SalaryComponentsRepository
        {
            get { return salarycomponentsRepository ?? (salarycomponentsRepository = new SalaryComponentsRepository(transaction)); }
        }
        public IEmployeeSalaryRepository EmployeeLeaveRepository
        {
            get { return employeesalaryRepository ?? (employeesalaryRepository = new EmployeeSalaryRepository(transaction)); }
        }
        public IEmployeeinfoRepository EmployeeinfoRepository
        {
            get { return employeeinfoRepository ?? (employeeinfoRepository = new EmployeeinfoRepository(transaction)); }
        }
        public IEmpLeaMapRepository EmpLeaMapRepository
        {
            get { return empleaMapRepository ?? (empleaMapRepository = new EmpLeaMapRepository(transaction)); }
        }
        public IEmployeeLeaveTypeRepository EmployeeLeaveTypeRepository
        {
            get { return employeeleaveTypeRepository ?? (employeeleaveTypeRepository = new EmployeeLeaveTypeRepository(transaction)); }
        }
        public IPayrollAttendanceRepository PayrollAttendanceRepository
        {
            get { return payrollAttendanceRepository ?? (payrollAttendanceRepository = new PayrollAttendanceRepository(transaction)); }
        }
        public IHolidayRepository HolidayRepository
        {
            get { return holidayRepository ?? (holidayRepository = new HolidayRepository(transaction)); }
        }
        public ITaxslabRepository TaxslabRepository
        {
            get { return taxslabRepository ?? (taxslabRepository = new TaxslabRepository(transaction)); }
        }
        public IPayslipRepository PayslipRepository
        {
            get { return payslipRepository ?? (payslipRepository = new PayslipRepository(transaction)); }
        }

        public void Commit()
        {
            try
            {
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
                transaction = connection.BeginTransaction();
                resetRepositories();
            }
        }
        private void resetRepositories()
        {
            userAuthenticate = null;
            menusRepository = null;
            departmentRepository = null;
            reportRepository = null;
            attendanceRepository = null;
            countryRepository = null;
            customerMasterRepository = null;
            customerSiteMappingRepository = null;
            invoiceRepository = null;
            designationRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing )
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                        transaction = null;
                    }
                    if (connection != null)
                    {
                        connection.Dispose();
                        connection = null;
                    }
                }
                disposed = true;
            }
        }
        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
