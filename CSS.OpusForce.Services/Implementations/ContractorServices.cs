using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Model.Contractors;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class ContractorServices : IContractorServices
    {
        private readonly IContractorRepository _contractorRepository;
        private readonly IContractorStatusRepository _contractorStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractorServices(IContractorRepository contractorRepository,
            IContractorStatusRepository contractorStatusRepository,
            IUnitOfWork unitOfWork)
        {
            _contractorRepository = contractorRepository;
            _contractorStatusRepository = contractorStatusRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*             Contractor Implementations                */
        /*********************************************************/
        #region Contractor Implementations
        public CreateContractorResponse CreateContractor(CreateContractorRequest request)
        {
            CreateContractorResponse response = new CreateContractorResponse();
            response.ExceptionState = false;

            Contractor contractor = new Contractor();
            contractor.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            contractor.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));
            contractor.ResponsibleHead = request.ResponsibleHead.ToUpper(new CultureInfo("tr-TR"));
            contractor.Address = request.Address.ToUpper(new CultureInfo("tr-TR"));
            contractor.PhoneNumber1 = request.PhoneNumber1.ToUpper(new CultureInfo("tr-TR"));
            contractor.PhoneNumber2 = request.PhoneNumber2.ToUpper(new CultureInfo("tr-TR"));
            contractor.MailAddress = request.MailAddress.ToUpper(new CultureInfo("tr-TR"));
            contractor.BankAccountNumber = request.BankAccountNumber.ToUpper(new CultureInfo("tr-TR"));
            contractor.InvoiceName = request.InvoiceName.ToUpper(new CultureInfo("tr-TR"));
            contractor.MailAddress = request.MailAddress.ToUpper(new CultureInfo("tr-TR"));
            contractor.TaxOffice = request.TaxOffice.ToUpper(new CultureInfo("tr-TR"));
            contractor.TaxNumber = request.TaxNumber.ToUpper(new CultureInfo("tr-TR"));
            contractor.ContractorStatus = _contractorStatusRepository.FindBy(request.ContractorStatusId);

            Query query = new Query();
            query.Add(Criterion.Create<Contractor>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_contractorRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir taşeron zaten var. Lütfen taşeron adını benzersiz bir isim olarak düzenleyin.";

                response.Contractor = contractor.ConvertToContractorView();

                return response;
            }

            object identityToken = _contractorRepository.Add(contractor);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Taşeron kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.Contractor = _contractorRepository.FindBy((int)identityToken).ConvertToContractorView();

            return response;
        }

        public ReadContractorResponse ReadContractor(ReadContractorRequest request)
        {
            ReadContractorResponse response = new ReadContractorResponse();
            response.ExceptionState = false;

            response.Contractor = _contractorRepository.FindBy(request.Id).ConvertToContractorView();

            return response;
        }

        public UpdateContractorResponse UpdateContractor(UpdateContractorRequest request)
        {
            UpdateContractorResponse response = new UpdateContractorResponse();
            response.ExceptionState = false;

            Contractor contractor = new Contractor();
            contractor.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            contractor.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));
            contractor.ResponsibleHead = request.ResponsibleHead.ToUpper(new CultureInfo("tr-TR"));
            contractor.Address = request.Address.ToUpper(new CultureInfo("tr-TR"));
            contractor.PhoneNumber1 = request.PhoneNumber1.ToUpper(new CultureInfo("tr-TR"));
            contractor.PhoneNumber2 = request.PhoneNumber2.ToUpper(new CultureInfo("tr-TR"));
            contractor.MailAddress = request.MailAddress.ToUpper(new CultureInfo("tr-TR"));
            contractor.BankAccountNumber = request.BankAccountNumber.ToUpper(new CultureInfo("tr-TR"));
            contractor.InvoiceName = request.InvoiceName.ToUpper(new CultureInfo("tr-TR"));
            contractor.MailAddress = request.MailAddress.ToUpper(new CultureInfo("tr-TR"));
            contractor.TaxOffice = request.TaxOffice.ToUpper(new CultureInfo("tr-TR"));
            contractor.TaxNumber = request.TaxNumber.ToUpper(new CultureInfo("tr-TR"));
            contractor.ContractorStatus = _contractorStatusRepository.FindBy(request.ContractorStatusId);

            if (contractor.Name != _contractorRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<Contractor>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_contractorRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir taşeron zaten var. Lütfen taşeron adını benzersiz bir isim olarak düzenleyin.";

                    response.Contractor = contractor.ConvertToContractorView();

                    return response;
                }
            }

            _contractorRepository.Save(contractor);
            _unitOfWork.Commit();

            response.Contractor = contractor.ConvertToContractorView();

            return response;
        }

        public DeleteContractorResponse DeleteContractor(DeleteContractorRequest request)
        {
            // UNDONE : Prevent Deletion
            DeleteContractorResponse response = new DeleteContractorResponse();
            response.ExceptionState = false;

            _contractorRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.Contractors = _contractorRepository.FindAll().ConvertToContractorSummaryView();

            return response;
        }

        public ListContractorsResponse ListContractors(ListContractorsRequest request)
        {
            ListContractorsResponse response = new ListContractorsResponse();
            response.ExceptionState = false;

            response.Contractors = _contractorRepository.FindAll().ConvertToContractorSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*          ContractorStatus Implementations             */
        /*********************************************************/
        #region ContractorStatus Implementations
        public CreateContractorStatusResponse CreateContractorStatus(CreateContractorStatusRequest request)
        {
            CreateContractorStatusResponse response = new CreateContractorStatusResponse();
            response.ExceptionState = false;

            ContractorStatus contractorStatus = new ContractorStatus();
            contractorStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            contractorStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<ContractorStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if(_contractorStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir taşeron durumu zaten var. Lütfen taşeron durumu adını benzersiz bir isim olarak düzenleyin.";

                response.ContractorStatus = contractorStatus.ConvertToContractorStatusView();

                return response;
            }

            object identityToken = _contractorStatusRepository.Add(contractorStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Taşeron durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.ContractorStatus = _contractorStatusRepository.FindBy((int)identityToken).ConvertToContractorStatusView();

            return response;
        }

        public ReadContractorStatusResponse ReadContractorStatus(ReadContractorStatusRequest request)
        {
            ReadContractorStatusResponse response = new ReadContractorStatusResponse();
            response.ExceptionState = false;

            response.ContractorStatus = _contractorStatusRepository.FindBy(request.Id).ConvertToContractorStatusView();

            return response;
        }

        public UpdateContractorStatusResponse UpdateContractorStatus(UpdateContractorStatusRequest request)
        {
            UpdateContractorStatusResponse response = new UpdateContractorStatusResponse();
            response.ExceptionState = false;

            ContractorStatus contractorStatus = new ContractorStatus();
            contractorStatus.Id = request.Id;
            contractorStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            contractorStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (contractorStatus.Name != _contractorStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<ContractorStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_contractorStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir taşeron durumu zaten var. Lütfen taşeron durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.ContractorStatus = contractorStatus.ConvertToContractorStatusView();

                    return response;
                }
            }

            _contractorStatusRepository.Save(contractorStatus);
            _unitOfWork.Commit();

            response.ContractorStatus = contractorStatus.ConvertToContractorStatusView();

            return response;
        }

        public DeleteContractorStatusResponse DeleteContractorStatus(DeleteContractorStatusRequest request)
        {
            DeleteContractorStatusResponse response = new DeleteContractorStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Contractor>(c => c.ContractorStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_contractorRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini taşeron durumunu kullanan taşeronlar var. Lütfen önce bu taşeronları silip ya da düzenleyip tekrar deneyin.";
                response.ContractorStatuses = _contractorStatusRepository.FindAll().ConvertToContractorStatusSummaryView();

                return response;
            }

            _contractorStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.ContractorStatuses = _contractorStatusRepository.FindAll().ConvertToContractorStatusSummaryView();

            return response;
        }

        public ListContractorStatusesResponse ListContractorSatuses(ListContractorStatusesRequest request)
        {
            ListContractorStatusesResponse response = new ListContractorStatusesResponse();
            response.ExceptionState = false;

            response.ContractorStatuses = _contractorStatusRepository.FindAll().ConvertToContractorStatusSummaryView();

            return response;
        }
        #endregion
    }
}
