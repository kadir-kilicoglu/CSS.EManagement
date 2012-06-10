using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Model.Employees;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Model.Financials;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class FinancialServices : IFinancialServices
    {
        private readonly IAssignedDutyRepository _assignedDutyRepository;
        private readonly IEmployeeFinanceRecordRepository _employeeFinanceRecordRepository;
        private readonly IFinancialActivityTypeRepository _financialActivityTypeRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinancialServices(IAssignedDutyRepository assignedDutyRepository,
            IEmployeeFinanceRecordRepository employeeFinanceRecordRepository,
            IFinancialActivityTypeRepository financialActivityTypeRepository,
            IPaymentTypeRepository paymentTypeRepository,
            IUnitOfWork unitOfWork)
        {            
            _assignedDutyRepository = assignedDutyRepository;
            _employeeFinanceRecordRepository = employeeFinanceRecordRepository;
            _financialActivityTypeRepository = financialActivityTypeRepository;
            _paymentTypeRepository = paymentTypeRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*        FinancialActivityType Implementations          */
        /*********************************************************/
        #region FinancialActivityType Implementations
        public CreateFinancialActivityTypeResponse CreateFinancialActivityType(CreateFinancialActivityTypeRequest request)
        {
            CreateFinancialActivityTypeResponse response = new CreateFinancialActivityTypeResponse();
            response.ExceptionState = false;

            FinancialActivityType financialActivityType = new FinancialActivityType();
            financialActivityType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            financialActivityType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<FinancialActivityType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_financialActivityTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir mali hareket tipi zaten var. Lütfen mali hareket tipi adını benzersiz bir isim olarak düzenleyin.";

                response.FinancialActivityType = financialActivityType.ConvertToFinancialActivityTypeView();

                return response;
            }

            object identityToken = _financialActivityTypeRepository.Add(financialActivityType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Mali hareket tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.FinancialActivityType = _financialActivityTypeRepository.FindBy((int)identityToken).ConvertToFinancialActivityTypeView();

            return response;
        }

        public ReadFinancialActivityTypeResponse ReadFinancialActivityType(ReadFinancialActivityTypeRequest request)
        {
            ReadFinancialActivityTypeResponse response = new ReadFinancialActivityTypeResponse();
            response.ExceptionState = false;

            response.FinancialActivityType = _financialActivityTypeRepository.FindBy(request.Id).ConvertToFinancialActivityTypeView();

            return response;
        }

        public UpdateFinancialActivityTypeResponse UpdateFinancialActivityType(UpdateFinancialActivityTypeRequest request)
        {
            UpdateFinancialActivityTypeResponse response = new UpdateFinancialActivityTypeResponse();
            response.ExceptionState = false;

            FinancialActivityType financialActivityType = new FinancialActivityType();
            financialActivityType.Id = request.Id;
            financialActivityType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            financialActivityType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (financialActivityType.Name != _financialActivityTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<FinancialActivityType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_financialActivityTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir mali hareket tipi zaten var. Lütfen mali hareket tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.FinancialActivityType = financialActivityType.ConvertToFinancialActivityTypeView();

                    return response;
                }
            }

            _financialActivityTypeRepository.Save(financialActivityType);
            _unitOfWork.Commit();

            response.FinancialActivityType = financialActivityType.ConvertToFinancialActivityTypeView();

            return response;
        }

        public DeleteFinancialActivityTypeResponse DeleteFinancialActivityType(DeleteFinancialActivityTypeRequest request)
        {
            DeleteFinancialActivityTypeResponse response = new DeleteFinancialActivityTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<EmployeeFinanceRecord>(c => c.FinancialActivityType.Id, request.Id, CriteriaOperator.Equal));
            if (_employeeFinanceRecordRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini mali hareket tipini kullanan mali hareketler var. Lütfen önce bu mali hareketleri silip ya da düzenleyip tekrar deneyin.";
                response.FinancialActivityTypes = _financialActivityTypeRepository.FindAll().ConvertToFinancialActivityTypeSummaryView();

                return response;
            }

            _financialActivityTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.FinancialActivityTypes = _financialActivityTypeRepository.FindAll().ConvertToFinancialActivityTypeSummaryView();

            return response;
        }

        public ListFinancialActivityTypesResponse ListFinancialActivityTypes(ListFinancialActivityTypesRequest request)
        {
            ListFinancialActivityTypesResponse response = new ListFinancialActivityTypesResponse();
            response.ExceptionState = false;

            response.FinancialActivityTypes = _financialActivityTypeRepository.FindAll().ConvertToFinancialActivityTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*             PaymentType Implementations               */
        /*********************************************************/
        #region PaymentType Implementations
        public CreatePaymentTypeResponse CreatePaymentType(CreatePaymentTypeRequest request)
        {
            CreatePaymentTypeResponse response = new CreatePaymentTypeResponse();
            response.ExceptionState = false;

            PaymentType paymentType = new PaymentType();
            paymentType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            paymentType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<PaymentType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_paymentTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir ödeme tipi zaten var. Lütfen ödeme tipi adını benzersiz bir isim olarak düzenleyin.";

                response.PaymentType = paymentType.ConvertToPaymentTypeView();

                return response;
            }

            object identityToken = _paymentTypeRepository.Add(paymentType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Ödeme tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.PaymentType = _paymentTypeRepository.FindBy((int)identityToken).ConvertToPaymentTypeView();

            return response;
        }

        public ReadPaymentTypeResponse ReadPaymentType(ReadPaymentTypeRequest request)
        {
            ReadPaymentTypeResponse response = new ReadPaymentTypeResponse();
            response.ExceptionState = false;

            response.PaymentType = _paymentTypeRepository.FindBy(request.Id).ConvertToPaymentTypeView();

            return response;
        }

        public UpdatePaymentTypeResponse UpdatePaymentType(UpdatePaymentTypeRequest request)
        {
            UpdatePaymentTypeResponse response = new UpdatePaymentTypeResponse();
            response.ExceptionState = false;

            PaymentType paymentType = new PaymentType();
            paymentType.Id = request.Id;
            paymentType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            paymentType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (paymentType.Name != _paymentTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<PaymentType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_paymentTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir ödeme tipi zaten var. Lütfen ödeme tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.PaymentType = paymentType.ConvertToPaymentTypeView();

                    return response;
                }
            }

            _paymentTypeRepository.Save(paymentType);
            _unitOfWork.Commit();

            response.PaymentType = paymentType.ConvertToPaymentTypeView();

            return response;
        }

        public DeletePaymentTypeResponse DeletePaymentType(DeletePaymentTypeRequest request)
        {
            DeletePaymentTypeResponse response = new DeletePaymentTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<AssignedDuty>(c => c.PaymentType.Id, request.Id, CriteriaOperator.Equal));
            if (_assignedDutyRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini ödeme tipini kullanan atanmış görevler var. Lütfen önce bu atanmış görevleri silip ya da düzenleyip tekrar deneyin.";
                response.PaymentTypes = _paymentTypeRepository.FindAll().ConvertToPaymentTypeSummaryView();

                return response;
            }

            _paymentTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.PaymentTypes = _paymentTypeRepository.FindAll().ConvertToPaymentTypeSummaryView();

            return response;
        }

        public ListPaymentTypesResponse ListPaymentTypes(ListPaymentTypesRequest request)
        {
            ListPaymentTypesResponse response = new ListPaymentTypesResponse();
            response.ExceptionState = false;

            response.PaymentTypes = _paymentTypeRepository.FindAll().ConvertToPaymentTypeSummaryView();

            return response;
        }
        #endregion
    }
}
