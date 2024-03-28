using Asp.Net.Core.DataModel.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.Net.Core.Business.Services.Contract
{
    public class ContractSaveService : IRequest<int>
    {
        public string Contract { get; set; }
    }
    public class ContractDeleteService : IRequest<int>
    {
        public string Contract { get; set; }
    }
    public class GetConsumableRequirementService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetContractByAllCustomerService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetContractDetailsService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetContractService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetContractMasterService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetAllCustomerService : IRequest<string>
    {
        public string Contract { get; set; }
    }
    public class GetContractsListByCustomerIdService : IRequest<string>
    {
        public string Contract { get; set; }
    }

    public class GetDeparmentAsServiceListService : IRequest<string>
    {

    }
    public class GetDesignetionByServiceIDService : IRequest<string>
    {
        public string DesignetionByServiceID { get; set; }
    }
    public class GetCustomerNameListService : IRequest<string>
    {

    }
    public class ContractDetailsFetchService : IRequest<Table6>
    {
        public string ContractDetailsFetch { get; set; }
    }
    public class getclienttypeService : IRequest<string>
    {

    }
}
