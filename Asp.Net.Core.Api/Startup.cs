using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PartialResponse.Extensions.DependencyInjection;
using Asp.Net.Core.Api.Filters;
using Asp.Net.Core.Api.MediatR;
using Asp.Net.Core.Api.Middlewares;
using Asp.Net.Core.Api.Validators;
using Asp.Net.Core.Business;
using Asp.Net.Core.Business.Behaviours;
using Asp.Net.Core.Business.Helpers;
using Asp.Net.Core.DataModel;
using Asp.Net.UserControl.DataContext.UnitOfWork;
using ERP.UserControl.DataContext.UnitOfWork;
using FluentValidation;
using Asp.Net.Core.Business.Services.Login;
using Asp.Net.Core.Business.Services.Menus;
using Asp.Net.Core.Business.Services.Department;
using Asp.Net.Core.DataModel.DBContext;
using Asp.Net.Core.Business.Services.Manpower;
using Asp.Net.Core.Business.Services.Contract;
using Asp.Net.Core.Business.Services.Attendance;
using Asp.Net.Core.Business.Services.Common.Country;
using Asp.Net.Core.DataModel.Models;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Asp.Net.Core.DataModel.Utilities;
using Asp.Net.Core.Business.Services.Contract.CustomerMaster;
using Asp.Net.Core.Business.Services.Contract.CustomerSiteMapping;
using Asp.Net.Core.Business.Services.Invoice;
using Asp.Net.Core.Business.Services.Designation;
using Asp.Net.Core.Business.Services.Masters.State;
using ConfigurationManager = Asp.Net.Core.Business.Helpers.ConfigurationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Asp.Net.Core.Business.Services.orders;
using Asp.Net.Core.Business.Services.Taxslab;
using Asp.Net.Core.Business.Services.salarycomponent;
using Asp.Net.Core.Business.Services.Payslip;
using Asp.Net.Core.Business.Services.PayrollAttendance;
using Asp.Net.Core.Business.Services.Holiday;
using Asp.Net.Core.Business.Services.EmployeeSalaryMasterMapping;
using Asp.Net.Core.Business.Services.Employeeinfo;
using Asp.Net.Core.Business.Services.EmployeeLeaveMapping;
using Asp.Net.Core.Business.Services.EmployeeLeaveType;
using static Asp.Net.Core.Business.Services.EmployeeLeaveType.EmployeeLeaveTypeService;

namespace Asp.Net.Core.Api
{
    public class Startup
    {
        readonly string CorsOnly = "CorsPolicy";
        readonly string AllowedOrg = "AllowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("14.99.125.147"));
            });
            services.AddLogging();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<ConfigurationManager>(Configuration); 
            var appSettingDTO = new AppSettingDTO();
            appSettingDTO.AddToConfiguration(Configuration);
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();

            services
            .AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiClientValidationExceptionAttribute));
                options.Filters.Add(typeof(FluentValidationExceptionAttribute));
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(GlobalExceptionFilter));
                //options.Filters.Add(typeof(ApiIActionFilter));
                //options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
            }).AddPartialJsonFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //}).AddJsonOptions(options => options.JsonSerializerOptions = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() });
            //);
            // .AddPartialJsonOptions(options =>
            //{
            //    // Return JSON responses in LowerCase?
            //    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            //    // Resolve Looping navigation properties
            //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            //}).AddJsonOptions(jsonOptions =>
            //{
            //    jsonOptions.Serialize
            //    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            //    jsonOptions.JsonSerializerOptions.DictionaryKeyPolicy = null;
            //    jsonOptions.JsonSerializerOptions.PropertyNameCaseInsensitive = false;

            //}).AddPartialJsonFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // Configure MediatR design pattern
            services.AddMediatR(typeof(AssemblyMaker));
            //services.AddScoped<IMediator, SynchronousMediator>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: CorsOnly,
            //     builder =>
            //     {
            //         builder.WithOrigins(Configuration.GetSection(AllowedOrg)
            //                              .Get<string[]>())
            //                             .AllowAnyHeader()
            //                             .AllowAnyMethod();
            //     });
            //});


            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsOnly,
                 builder =>
                 {
                     builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                 });
            });

            // Configure Fluent Validation
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // configure jwt authentication
            var key = System.Text.Encoding.ASCII.GetBytes(Configuration.GetValue<string>("JwtSettings:JwtPublicKey"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuers = Configuration.GetSection("JwtSettings:Issuers").Get<string[]>()
                };
            });


            string jwtPublicKey = Configuration.GetValue<string>("JwtSettings:JwtPublicKey");
            string Issuer = Configuration.GetValue<string>("JwtSettings:Issuer");
            services.AddTransient<IJwtTokenValidator>(jwtTokenValidator => new JwtTokenValidator(jwtPublicKey, Issuer));

            services.AddSignalR().AddJsonProtocol(options => { options.PayloadSerializerOptions.PropertyNamingPolicy = null; });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                //c.DescribeAllEnumsAsStrings();
                //c.DescribeStringEnumsInCamelCase();
                c.DescribeAllParametersInCamelCase();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asp.Net Launching API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            },
                            //Scheme = "oauth2",
                            Scheme = "ApiKeys",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                        }
                    });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            // Configure FluentValidation
            services.AddScoped<IValidator<LoginService>, LoginValidation>();

            //Menus FluentValidation
            services.AddScoped<IValidator<MenusService>, MenusValidation>();
            services.AddScoped<IValidator<getmenulistService>, getmenulistValidation>();

            //Department FluentValidation
            //services.AddScoped<IValidator<DepartmentListService>, DepartmentListValidation>();
            //services.AddScoped<IValidator<DepartmentSaveService>, DepartmentSaveValidation>();
            //services.AddScoped<IValidator<DepartmentFetchService>, DepartmentFetchValidation>();
            //services.AddScoped<IValidator<DepartmentDeleteService>, DepartmentDeleteValidation>();
            //services.AddScoped<IValidator<DepartmentReportService>, DepartmentReportValidation>();

            services.AddScoped<IValidator<DepartmentSaveService>, DepartmentSaveValidation>();
            services.AddScoped<IValidator<DepartmentListService>, DepartmentListValidation>();
            services.AddScoped<IValidator<DepartmentFetchService>, DepartmentFetchValidation>();
            services.AddScoped<IValidator<DepartmentDeleteService>, DepartmentDeleteValidation>();

            //State FluentValidation
            services.AddScoped<IValidator<StateSaveService>, StateSaveValidation>();
            services.AddScoped<IValidator<StateListService>, StateListValidation>();
            services.AddScoped<IValidator<StateFetchService>, StateFetchValidation>();
            services.AddScoped<IValidator<StateDeleteService>, StateDeleteValidation>();

            //orders FluentValidation
            services.AddScoped<IValidator<ordersSaveService>, ordersSaveValidation>();
            services.AddScoped<IValidator<ordersListService>, ordersListValidation>();
            services.AddScoped<IValidator<ordersFetchService>, ordersFetchValidation>();
            services.AddScoped<IValidator<ordersDeleteService>, ordersDeleteValidation>();



            //Taxslab FluentValidation
            services.AddScoped<IValidator<TaxslabDeleteService>, TaxslabDeleteValidation>();
            services.AddScoped<IValidator<TaxslabService>, TaxslabValidation>();
            services.AddScoped<IValidator<TaxslabListService>, TaxslabListValidation>();


            //SalaryComponent FluentValidation
            services.AddScoped<IValidator<SalaryComponentSaveService>, SalaryComponentSaveValidation>();
            services.AddScoped<IValidator<SalaryComponentListService>, SalaryComponentListValidation>();
            services.AddScoped<IValidator<SalaryComponentDeleteService>, SalaryComponentDeleteValidation>();



            //PaysLip FluentValidation
            services.AddScoped<IValidator<PayslipService>, PayslipValidation>();
            services.AddScoped<IValidator<PayslipListService>, PayslipListValidation>();
            services.AddScoped<IValidator<PayslipDeleteService>, PayslipDeleteValidation>();



            //PayrollAttendance FluentValidation
            services.AddScoped<IValidator<PayrollAttendanceService>, PayrollAttendanceValidation>();
            services.AddScoped<IValidator<PayrollAttendanceListService>, PayrollAttendanceListValidation>();
            services.AddScoped<IValidator<PayrollAttendanceDeleteService>, PayrollAttendanceDeleteValidation>();
            services.AddScoped<IValidator<PayrollAttendanceGetByIdService>, PayrollAttendanceGetByIdValidation>();


            //  HolidayService FluentValidation
            services.AddScoped<IValidator<HolidayService>, HolidayValidation>();
            services.AddScoped<IValidator<HolidayListService>, HolidayListValidation>();
            services.AddScoped<IValidator<HolidayDeleteService>, HolidayDeleteValidation>();

            //employeeinfo
            services.AddScoped<IValidator<EmployeeinfoListService>, EmployeeinfoValidation>();

            //employeeleavemapping
            services.AddScoped<IValidator<EmpLeaMapService>, EmpLeaMapValidation>();
            services.AddScoped<IValidator<EmpLeaMapListService>, EmpLeaMapListValidation>();
            services.AddScoped<IValidator<GetEmpLeaveByIdService>, GetEmpLeaveByIdValidation>();
            services.AddScoped<IValidator<EmpLeaMapDeleteService>, EmpLeaMapDeleteValidation>();

            //employeeleavetype
            services.AddScoped<IValidator<EmployeeLeaveTypeListService>, EmployeeLeaveTypeValidation>();

            //employeesalarymastermapping
            services.AddScoped<IValidator<EmployeeSalarySaveService>, EmployeeSalaryValidation>();
            services.AddScoped<IValidator<EmployeeSalaryListService>, EmployeeSalaryListValidation>();
            services.AddScoped<IValidator<GetByIdService>, GetByIdValidation>();
            services.AddScoped<IValidator<EmployeeSalaryDeleteService>, EmployeeSalaryDeleteValidation>();

            //ManPowerDetails FluentValidation
            services.AddScoped<IValidator<GetCompanyListService>, GetCompanyListValidation>();
            services.AddScoped<IValidator<GetCountryListService>, GetCountryListValidation>();
            services.AddScoped<IValidator<GetStateListService>, GetStateListValidation>();
            services.AddScoped<IValidator<GetCityListService>, GetCityListValidation>();
            services.AddScoped<IValidator<GetBankListService>, GetBankListValidation>();
            services.AddScoped<IValidator<GetDesignationListService>, GetDesignationListValidation>();
            services.AddScoped<IValidator<GetPaymentModeListService>, GetPaymentModeListValidation>();
            services.AddScoped<IValidator<GetProofListService>, GetProofListValidation>();
            services.AddScoped<IValidator<GetAccountTypeListService>, GetAccountTypeListValidation>();
            services.AddScoped<IValidator<ManPowerDetailSaveService>, ManPowerDetailSaveValidation>();
            services.AddScoped<IValidator<ManPowerBankDetailSaveService>, ManPowerBankDetailSaveValidation>();
            services.AddScoped<IValidator<ManPowerFamilyDetailSaveService>, ManPowerFamilyDetailSaveValidation>();
            services.AddScoped<IValidator<ManPowerProofDetailSaveService>, ManPowerProofDetailSaveValidation>();
            services.AddScoped<IValidator<GetManpowerListService>, GetManpowerListValidation>();
            services.AddScoped<IValidator<GetManpowerBankListService>, GetManpowerBankListValidation>();
            services.AddScoped<IValidator<GetManpowerFamilyListService>, GetManpowerFamilyListValidation>();
            services.AddScoped<IValidator<GetManpowerProofListService>, GetManpowerProofListValidation>();
            services.AddScoped<IValidator<ManPowerBankDeleteService>, ManPowerBankDeleteValidation>();
            services.AddScoped<IValidator<ManPowerFamilyDeleteService>, ManPowerFamilyDeleteValidation>();
            services.AddScoped<IValidator<ManPowerProofDeleteService>, ManPowerProofDeleteValidation>();
            services.AddScoped<IValidator<ManPowerDetailFetchService>, ManPowerDetailFetchValidation>();

            // Assign Manpower
            services.AddScoped<IValidator<GetClassificationListService>, GetClassificationListValidation>();
            services.AddScoped<IValidator<GetContractIdListService>, GetContractIdListValidation>();
            services.AddScoped<IValidator<GetServiceListService>, GetServiceListValidation>();
            services.AddScoped<IValidator<GetManpowerNameListService>, GetManpowerNameListValidation>();
            services.AddScoped<IValidator<GetAssignManpowerListService>, GetAssignManpowerListValidation>();
            services.AddScoped<IValidator<GetAssignManpowerSaveService>, GetAssignManpowerSaveValidation>();
            services.AddScoped<IValidator<GetAssignManpowerDeleteService>, GetAssignManpowerDeleteValidation>();
            services.AddScoped<IValidator<GetManpowerDirectService>,GetManpowerDirectValidation> ();
            services.AddScoped<IValidator<SaveManpowerdirectService>, SaveManpowerdirectValidation>();
            services.AddScoped<IValidator<GetShiftdetailsdirectService>, GetShiftdetailsdirectValidation>();

            //////////////////// Allocate Manpower ////////////
            services.AddScoped<IValidator<AllocateManpowerSaveService>, AllocateManpowerSiteSaveValidation>();
            services.AddScoped<IValidator<GetMAServiceListService>, GetMAServiceListValidation>();
            services.AddScoped<IValidator<AllocateManpowerSiteListService>, AllocateManpowerSiteListValidation>();
            services.AddScoped<IValidator<AllocateManpowerSiteDeleteService>, AllocateManpowerSiteDeleteValidation>();


            // Assign Field Officer
            services.AddScoped<IValidator<GetFieldOfficerSaveService>, GetFieldOfficerSaveValidation>();
            services.AddScoped<IValidator<GetFieldOfficerDeleteService>, GetFieldOfficerDeleteValidation>();
            services.AddScoped<IValidator<GetFieldOfficerService>, GetFieldOfficerValidation>();
            services.AddScoped<IValidator<GetAllManpowerNameService>, GetAllManpowerNameValidation>();

            //Invoice
            services.AddScoped<IValidator<GenerateTaxInvoiceReportService>, GenerateTaxInvoiceReportValidation>();



            //Contract
            services.AddScoped<IValidator<ContractSaveService>, ContractSaveValidation>();
            services.AddScoped<IValidator<ContractDeleteService>, ContractDeleteValidation>();
            services.AddScoped<IValidator<GetConsumableRequirementService>, GetConsumableRequirementValidation>();
            services.AddScoped<IValidator<GetContractByAllCustomerService>, GetContractByAllCustomerValidation>();
            services.AddScoped<IValidator<GetContractDetailsService>, GetContractDetailsValidation>();
            services.AddScoped<IValidator<GetContractService>, GetContractValidation>();
            services.AddScoped<IValidator<GetContractMasterService>, GetContractMasterValidation>();
            services.AddScoped<IValidator<GetAllCustomerService>, GetAllCustomerValidation>();
            services.AddScoped<IValidator<GetContractsListByCustomerIdService>, GetContractsListByCustomerIdValidation>();
            services.AddScoped<IValidator<GetDeparmentAsServiceListService>, GetDeparmentAsServiceListValidation>();
            services.AddScoped<IValidator<GetDesignetionByServiceIDService>, GetDesignetionByServiceIDValidation>();
            services.AddScoped<IValidator<GetCustomerNameListService>, GetCustomerNameListValidation>();
            services.AddScoped<IValidator<ContractDetailsFetchService>, ContractDetailsFetchValidation>();
            services.AddScoped<IValidator<SaveLocationService>, SaveLocationValidation>();
            services.AddScoped<IValidator<GetLocationService>, GetLocationValidation>();
            services.AddScoped<IValidator<DeleteLocationService>, DeleteLocationValidation>();
            services.AddScoped<IValidator<GetContractListService>, GetContractListValidation>();
            services.AddScoped<IValidator<LocationFetchService>, LocationFetchValidation>();
            services.AddScoped<IValidator<LocationlistService>, LocationlistValidation>(); 
            services.AddScoped<IValidator<ContractListAllocateService>, ContractListAllocateValidation>();
            services.AddScoped<IValidator<ContractServiceListService>, ContractServiceListValidation>();
            services.AddScoped<IValidator<ContractListbyCustomerService>, ContractManpowerListValidation>();
            services.AddScoped<IValidator<AllocationListService>, AllocationListValidation>();
            services.AddScoped<IValidator<getclienttypeService>,getclienttypeValidation>();

            //Attendance
            services.AddScoped<IValidator<CustomerBranchSiteDropDownListService>, CustomerBranchSiteDropDownListValidation>();
            services.AddScoped<IValidator<GetManpowerDetailsListService>, GetManpowerDetailsListValidation>();
            services.AddScoped<IValidator<AttendanceStatusListService>, AttendanceStatusListValidation>();
            services.AddScoped<IValidator<ManPowerAttendanceSaveService>, ManPowerAttendanceSaveValidation>();
            services.AddScoped<IValidator<GetManpowerPivotDetailsListService>, GetManpowerPivotDetailsListValidation>();

            //Customer Master
            services.AddScoped<IValidator<CustomerSaveService>, CustomerSaveValidation>();
            services.AddScoped<IValidator<CustomerListService>, CustomerListValidation>();
            services.AddScoped<IValidator<CustomerFetchService>, CustomerFetchValidation>();

            //Designation Master
            services.AddScoped<IValidator<DesignationSaveService>, DesignationSaveValidation>();
            services.AddScoped<IValidator<DesignationListService>, DesignationListValidation>();
            services.AddScoped<IValidator<DesignationFetchService>, DesignationFetchValidation>();
            services.AddScoped<IValidator<DesignationDeleteService>, DesignationDeleteValidation>();


            //Common
            services.AddScoped<IValidator<CountrySaveService>, CountrySaveValidation>();
            services.AddScoped<IValidator<CountryListService>, CountryListValidation>();
            services.AddScoped<IValidator<CountryByIdService>, CountryByIdValidation>();
            services.AddScoped<IValidator<CountryDeleteService>, CountryDeleteValidation>();

            // customer site mapping
            services.AddScoped<IValidator<GetCustomerDropDownService>, GetCustomerDropDownValidation>();
            services.AddScoped<IValidator<BranchMasterDeleteService>, BranchMasterDeleteValidation>();
            services.AddScoped<IValidator<SiteMasterDeleteService>, SiteMasterDeleteValidation>();
            services.AddScoped<IValidator<ClassificationMasterDeleteService>, ClassificationMasterDeleteValidation>();
            services.AddScoped<IValidator<GetBranchMasterListService>, GetBranchMasterListValidation>();
            services.AddScoped<IValidator<GetSiteMasterListService>, GetSiteMasterListValidation>();
            services.AddScoped<IValidator<GetClassificationMasterListService>, GetClassificationMasterListValidation>();
            services.AddScoped<IValidator<BranchMasterSaveService>, BranchMasterSaveValidation>();
            services.AddScoped<IValidator<SiteMasterSaveService>, SiteMasterSaveValidation>();
            services.AddScoped<IValidator<ClassificationMasterSaveService>, ClassificationMasterSaveValidation>();

            //Connect the database
            //services.AddDbContext<Asp.NetUserControlContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConnectionString"]));
            //services.AddTransient<IUnitOfWork, UnitOfWork>(ctx => new UnitOfWork(Configuration["ConnectionStrings:ConnectionString"]));

            //pgsql database connect
            services.AddDbContext<APIUserControlContext>(options => options.UseNpgsql(Configuration["DatabaseConfig:PostgresSQL"]));
            services.AddDbContext<DBPostgresContext>(options => options.UseNpgsql(Configuration["DatabaseConfig:PostgresSQL"]));
            services.AddTransient<IUnitOfWork, UnitOfWork>(ctx => new UnitOfWork(Configuration["DatabaseConfig:PostgresSQL"]));

            //Entity Framework
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(CorsOnly);
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<AuthorizationMiddleware>();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(AppSettingDTO.GetValue.ImagePath),
            //    RequestPath = "/StaticFiles"
            //});

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP Net Core System V1");
            });
            app.UseRouting();

            app.UseAuthorization();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
