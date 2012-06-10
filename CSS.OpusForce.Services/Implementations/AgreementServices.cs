using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.Agreements;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class AgreementServices : IAgreementServices
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IAgreementTypeRepository _agreementTypeRepository;
        private readonly IAgreementStatusRepository _agreementStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgreementServices(IAgreementRepository agreementRepository,
            IAgreementTypeRepository agreementTypeRepository,
            IAgreementStatusRepository agreementStatusRepository,
            IUnitOfWork unitOfWork)
        {
            _agreementRepository = agreementRepository;
            _agreementTypeRepository = agreementTypeRepository;
            _agreementStatusRepository = agreementStatusRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*             AgreementType Implementations               */
        /*********************************************************/
        #region AgreementType Implementations
        public CreateAgreementTypeResponse CreateAgreementType(CreateAgreementTypeRequest request)
        {
            CreateAgreementTypeResponse response = new CreateAgreementTypeResponse();
            response.ExceptionState = false;

            AgreementType agreementType = new AgreementType();
            agreementType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            agreementType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<AgreementType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_agreementTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir sözleşme tipi zaten var. Lütfen sözleşme tipi adını benzersiz bir isim olarak düzenleyin.";

                response.AgreementType = agreementType.ConvertToAgreementTypeView();

                return response;
            }

            object identityToken = _agreementTypeRepository.Add(agreementType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Sözleşme tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.AgreementType = _agreementTypeRepository.FindBy((int)identityToken).ConvertToAgreementTypeView();

            return response;
        }

        public ReadAgreementTypeResponse ReadAgreementType(ReadAgreementTypeRequest request)
        {
            ReadAgreementTypeResponse response = new ReadAgreementTypeResponse();
            response.ExceptionState = false;

            response.AgreementType = _agreementTypeRepository.FindBy(request.Id).ConvertToAgreementTypeView();

            return response;
        }

        public UpdateAgreementTypeResponse UpdateAgreementType(UpdateAgreementTypeRequest request)
        {
            UpdateAgreementTypeResponse response = new UpdateAgreementTypeResponse();
            response.ExceptionState = false;

            AgreementType agreementType = new AgreementType();
            agreementType.Id = request.Id;
            agreementType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            agreementType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (agreementType.Name != _agreementTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<AgreementType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_agreementTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir sözleşme tipi zaten var. Lütfen sözleşme tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.AgreementType = agreementType.ConvertToAgreementTypeView();

                    return response;
                }
            }

            _agreementTypeRepository.Save(agreementType);
            _unitOfWork.Commit();

            response.AgreementType = agreementType.ConvertToAgreementTypeView();

            return response;
        }

        public DeleteAgreementTypeResponse DeleteAgreementType(DeleteAgreementTypeRequest request)
        {
            DeleteAgreementTypeResponse response = new DeleteAgreementTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Agreement>(c => c.AgreementType.Id, request.Id, CriteriaOperator.Equal));
            if (_agreementRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini sözleşme tipini kullanan sözleşmeler var. Lütfen önce bu sözleşmeleri silip ya da düzenleyip tekrar deneyin.";
                response.AgreementTypes = _agreementTypeRepository.FindAll().ConvertToAgreementTypeSummaryView();

                return response;
            }

            _agreementTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.AgreementTypes = _agreementTypeRepository.FindAll().ConvertToAgreementTypeSummaryView();

            return response;
        }

        public ListAgreementTypesResponse ListAgreementTypes(ListAgreementTypesRequest request)
        {
            ListAgreementTypesResponse response = new ListAgreementTypesResponse();
            response.ExceptionState = false;

            response.AgreementTypes = _agreementTypeRepository.FindAll().ConvertToAgreementTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*            AgreementStatus Implementations              */
        /*********************************************************/
        #region AgreementStatus Implementations
        public CreateAgreementStatusResponse CreateAgreementStatus(CreateAgreementStatusRequest request)
        {
            CreateAgreementStatusResponse response = new CreateAgreementStatusResponse();
            response.ExceptionState = false;

            AgreementStatus agreementStatus = new AgreementStatus();
            agreementStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            agreementStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<AgreementStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_agreementStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir sözleşme durumu zaten var. Lütfen sözleşme durumu adını benzersiz bir isim olarak düzenleyin.";

                response.AgreementStatus = agreementStatus.ConvertToAgreementStatusView();

                return response;
            }

            object identityToken = _agreementStatusRepository.Add(agreementStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Sözleşme durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.AgreementStatus = _agreementStatusRepository.FindBy((int)identityToken).ConvertToAgreementStatusView();

            return response;
        }

        public ReadAgreementStatusResponse ReadAgreementStatus(ReadAgreementStatusRequest request)
        {
            ReadAgreementStatusResponse response = new ReadAgreementStatusResponse();
            response.ExceptionState = false;

            response.AgreementStatus = _agreementStatusRepository.FindBy(request.Id).ConvertToAgreementStatusView();

            return response;
        }

        public UpdateAgreementStatusResponse UpdateAgreementStatus(UpdateAgreementStatusRequest request)
        {
            UpdateAgreementStatusResponse response = new UpdateAgreementStatusResponse();
            response.ExceptionState = false;

            AgreementStatus agreementStatus = new AgreementStatus();
            agreementStatus.Id = request.Id;
            agreementStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            agreementStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (agreementStatus.Name != _agreementStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<AgreementStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_agreementStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir sözleşme durumu zaten var. Lütfen sözleşme durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.AgreementStatus = agreementStatus.ConvertToAgreementStatusView();

                    return response;
                }
            }

            _agreementStatusRepository.Save(agreementStatus);
            _unitOfWork.Commit();

            response.AgreementStatus = agreementStatus.ConvertToAgreementStatusView();

            return response;
        }

        public DeleteAgreementStatusResponse DeleteAgreementStatus(DeleteAgreementStatusRequest request)
        {
            DeleteAgreementStatusResponse response = new DeleteAgreementStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Agreement>(c => c.AgreementStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_agreementRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğiniz sözleşme durumunu kullanan sözleşmeler var. Lütfen önce bu sözleşmeleri silip ya da düzenleyip tekrar deneyin.";
                response.AgreementStatuses = _agreementStatusRepository.FindAll().ConvertToAgreementStatusSummaryView();

                return response;
            }

            _agreementStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.AgreementStatuses = _agreementStatusRepository.FindAll().ConvertToAgreementStatusSummaryView();

            return response;
        }

        public ListAgreementStatusesResponse ListAgreementStatuses(ListAgreementStatusesRequest request)
        {
            ListAgreementStatusesResponse response = new ListAgreementStatusesResponse();
            response.ExceptionState = false;

            response.AgreementStatuses = _agreementStatusRepository.FindAll().ConvertToAgreementStatusSummaryView();

            return response;
        }
        #endregion
    }
}
