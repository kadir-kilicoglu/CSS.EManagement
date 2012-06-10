using StructureMap;
using StructureMap.Configuration.DSL;

using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Accounts;
using CSS.OpusForce.Model.Agreements;
using CSS.OpusForce.Model.Calendars;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Model.Contractors;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Model.Financials;
using CSS.OpusForce.Model.OperationCenters;
using CSS.OpusForce.Model.Projects;
using CSS.OpusForce.Model.ScoreCards;
using CSS.OpusForce.Services.Interfaces;
using CSS.OpusForce.Repository.NHibernate;
using CSS.OpusForce.Services.Implementations;
using CSS.OpusForce.Repository.NHibernate.Repositories;

namespace CSS.OpusForce.UI.Web.MVC
{
    public static class GlobalVariables
    {
        public static string returnUrl = string.Empty;
    }

    public class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ControllerRegistry>();

            });
        }

        public class ControllerRegistry : Registry
        {
            public ControllerRegistry()
            {
                //Repositories
                ForRequestedType<IUnitOfWork>().TheDefault.Is.OfConcreteType<NHUnitOfWork>();
                ForRequestedType<IRoleRepository>().TheDefault.Is.OfConcreteType<RoleRepository>();
                ForRequestedType<IUserAccountRepository>().TheDefault.Is.OfConcreteType<UserAccountRepository>();
                ForRequestedType<IUserRoleRepository>().TheDefault.Is.OfConcreteType<UserRoleRepository>();
                ForRequestedType<IAgreementRepository>().TheDefault.Is.OfConcreteType<AgreementRepository>();
                ForRequestedType<IAgreementStatusRepository>().TheDefault.Is.OfConcreteType<AgreementStatusRepository>();
                ForRequestedType<IAgreementTypeRepository>().TheDefault.Is.OfConcreteType<AgreementTypeRepository>();
                ForRequestedType<ICalendarRepository>().TheDefault.Is.OfConcreteType<CalendarRepository>();
                ForRequestedType<ICalendarDayRepository>().TheDefault.Is.OfConcreteType<CalendarDayRepository>();
                ForRequestedType<ICalendarDayRuleRepository>().TheDefault.Is.OfConcreteType<CalendarDayRuleRepository>();
                ForRequestedType<ICalendarDayTypeRepository>().TheDefault.Is.OfConcreteType<CalendarDayTypeRepository>();
                ForRequestedType<ICalendarMonthRepository>().TheDefault.Is.OfConcreteType<CalendarMonthRepository>();
                ForRequestedType<IDayRuleRepository>().TheDefault.Is.OfConcreteType<DayRuleRepository>();
                ForRequestedType<ICompanyRepository>().TheDefault.Is.OfConcreteType<CompanyRepository>();
                ForRequestedType<ICompanyTypeRepository>().TheDefault.Is.OfConcreteType<CompanyTypeRepository>();
                ForRequestedType<IContractorRepository>().TheDefault.Is.OfConcreteType<ContractorRepository>();
                ForRequestedType<IContractorStatusRepository>().TheDefault.Is.OfConcreteType<ContractorStatusRepository>();
                ForRequestedType<IAssignedDutyRepository>().TheDefault.Is.OfConcreteType<AssignedDutyRepository>();
                ForRequestedType<ICareerHistoryRepository>().TheDefault.Is.OfConcreteType<CareerHistoryRepository>();
                ForRequestedType<IDebitStatusRepository>().TheDefault.Is.OfConcreteType<DebitStatusRepository>();
                ForRequestedType<IDebitTypeRepository>().TheDefault.Is.OfConcreteType<DebitTypeRepository>();
                ForRequestedType<IEmployeeRepository>().TheDefault.Is.OfConcreteType<EmployeeRepository>();
                ForRequestedType<IEmployeeDebitRepository>().TheDefault.Is.OfConcreteType<EmployeeDebitRepository>();
                ForRequestedType<IEmployeeFileRepository>().TheDefault.Is.OfConcreteType<EmployeeFileRepository>();
                ForRequestedType<IEmployeeFinanceRecordRepository>().TheDefault.Is.OfConcreteType<EmployeeFinanceRecordRepository>();
                ForRequestedType<IFileStatusRepository>().TheDefault.Is.OfConcreteType<FileStatusRepository>();
                ForRequestedType<IFileTypeRepository>().TheDefault.Is.OfConcreteType<FileTypeRepository>();
                ForRequestedType<ISkillRepository>().TheDefault.Is.OfConcreteType<SkillRepository>();
                ForRequestedType<ICurrencyRepository>().TheDefault.Is.OfConcreteType<CurrencyRepository>();
                ForRequestedType<IFinancialActivityTypeRepository>().TheDefault.Is.OfConcreteType<FinancialActivityTypeRepository>();
                ForRequestedType<IPaymenPeriodRepository>().TheDefault.Is.OfConcreteType<PaymentPeriodRepository>();
                ForRequestedType<IPaymentTypeRepository>().TheDefault.Is.OfConcreteType<PaymentTypeRepository>();
                ForRequestedType<IOperationCenterRepository>().TheDefault.Is.OfConcreteType<OperationCenterRepository>();
                ForRequestedType<IOperationCenterStatusRepository>().TheDefault.Is.OfConcreteType<OperationCenterStatusRepository>();
                ForRequestedType<IOperationCenterTypeRepository>().TheDefault.Is.OfConcreteType<OperationCenterTyperRepository>();
                ForRequestedType<IProjectRepository>().TheDefault.Is.OfConcreteType<ProjectRepository>();
                ForRequestedType<IProjectStatusRepository>().TheDefault.Is.OfConcreteType<ProjectStatusRepository>();
                ForRequestedType<IProjectTypeRepository>().TheDefault.Is.OfConcreteType<ProjectTypeRepository>();


                //Services
                ForRequestedType<IAccountServices>().TheDefault.Is.OfConcreteType<AccountServices>();
                ForRequestedType<IAgreementServices>().TheDefault.Is.OfConcreteType<AgreementServices>();
                ForRequestedType<ICalendarServices>().TheDefault.Is.OfConcreteType<CalendarServices>();
                ForRequestedType<ICompanyServices>().TheDefault.Is.OfConcreteType<CompanyServices>();
                ForRequestedType<IContractorServices>().TheDefault.Is.OfConcreteType<ContractorServices>();
                ForRequestedType<IEmployeeServices>().TheDefault.Is.OfConcreteType<EmployeeServices>();
                ForRequestedType<IFinancialServices>().TheDefault.Is.OfConcreteType<FinancialServices>();
                ForRequestedType<IOperationCenterServices>().TheDefault.Is.OfConcreteType<OperationCenterServices>();
                ForRequestedType<IProjectServices>().TheDefault.Is.OfConcreteType<ProjectServices>();
                ForRequestedType<IScoreCardServices>().TheDefault.Is.OfConcreteType<ScoreCardServices>();

            }
        }
    }
}