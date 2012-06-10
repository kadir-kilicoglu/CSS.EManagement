using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.OperationCenters;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class OperationCenterServices : IOperationCenterServices
    {
        private readonly IOperationCenterRepository _operationCenterRepository;
        private readonly IOperationCenterTypeRepository _operationCenterTypeRepository;
        private readonly IOperationCenterStatusRepository _operationCenterStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OperationCenterServices(IOperationCenterRepository operationCenterRepository,
            IOperationCenterTypeRepository operationCenterTypeRepository,
            IOperationCenterStatusRepository operationCenterStatusRepository,
            IUnitOfWork unitOfWork)
        {
            _operationCenterRepository = operationCenterRepository;
            _operationCenterTypeRepository = operationCenterTypeRepository;
            _operationCenterStatusRepository = operationCenterStatusRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*             OperationCenterType Implementations               */
        /*********************************************************/
        #region OperationCenterType Implementations
        public CreateOperationCenterTypeResponse CreateOperationCenterType(CreateOperationCenterTypeRequest request)
        {
            CreateOperationCenterTypeResponse response = new CreateOperationCenterTypeResponse();
            response.ExceptionState = false;

            OperationCenterType operationCenterType = new OperationCenterType();
            operationCenterType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            operationCenterType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<OperationCenterType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_operationCenterTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir faaliyet merkezi tipi zaten var. Lütfen faaliyet merkezi tipi adını benzersiz bir isim olarak düzenleyin.";

                response.OperationCenterType = operationCenterType.ConvertToOperationCenterTypeView();

                return response;
            }

            object identityToken = _operationCenterTypeRepository.Add(operationCenterType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Faaliyet merkezi tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.OperationCenterType = _operationCenterTypeRepository.FindBy((int)identityToken).ConvertToOperationCenterTypeView();

            return response;
        }

        public ReadOperationCenterTypeResponse ReadOperationCenterType(ReadOperationCenterTypeRequest request)
        {
            ReadOperationCenterTypeResponse response = new ReadOperationCenterTypeResponse();
            response.ExceptionState = false;

            response.OperationCenterType = _operationCenterTypeRepository.FindBy(request.Id).ConvertToOperationCenterTypeView();

            return response;
        }

        public UpdateOperationCenterTypeResponse UpdateOperationCenterType(UpdateOperationCenterTypeRequest request)
        {
            UpdateOperationCenterTypeResponse response = new UpdateOperationCenterTypeResponse();
            response.ExceptionState = false;

            OperationCenterType operationCenterType = new OperationCenterType();
            operationCenterType.Id = request.Id;
            operationCenterType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            operationCenterType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (operationCenterType.Name != _operationCenterTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<OperationCenterType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_operationCenterTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir faaliyet merkezi tipi zaten var. Lütfen faaliyet merkezi tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.OperationCenterType = operationCenterType.ConvertToOperationCenterTypeView();

                    return response;
                }
            }

            _operationCenterTypeRepository.Save(operationCenterType);
            _unitOfWork.Commit();

            response.OperationCenterType = operationCenterType.ConvertToOperationCenterTypeView();

            return response;
        }

        public DeleteOperationCenterTypeResponse DeleteOperationCenterType(DeleteOperationCenterTypeRequest request)
        {
            DeleteOperationCenterTypeResponse response = new DeleteOperationCenterTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<OperationCenter>(c => c.OperationCenterType.Id, request.Id, CriteriaOperator.Equal));
            if (_operationCenterRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini faaliyet merkezi tipini kullanan faaliyet merkezleri var. Lütfen önce bu faaliyet merkezlerini silip ya da düzenleyip tekrar deneyin.";
                response.OperationCenterTypes = _operationCenterTypeRepository.FindAll().ConvertToOperationCenterTypeSummaryView();

                return response;
            }

            _operationCenterTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.OperationCenterTypes = _operationCenterTypeRepository.FindAll().ConvertToOperationCenterTypeSummaryView();

            return response;
        }

        public ListOperationCenterTypesResponse ListOperationCenterTypes(ListOperationCenterTypesRequest request)
        {
            ListOperationCenterTypesResponse response = new ListOperationCenterTypesResponse();
            response.ExceptionState = false;

            response.OperationCenterTypes = _operationCenterTypeRepository.FindAll().ConvertToOperationCenterTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*            OperationCenterStatus Implementations              */
        /*********************************************************/
        #region OperationCenterStatus Implementations
        public CreateOperationCenterStatusResponse CreateOperationCenterStatus(CreateOperationCenterStatusRequest request)
        {
            CreateOperationCenterStatusResponse response = new CreateOperationCenterStatusResponse();
            response.ExceptionState = false;

            OperationCenterStatus operationCenterStatus = new OperationCenterStatus();
            operationCenterStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            operationCenterStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<OperationCenterStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_operationCenterStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir faaliyet merkezi durumu zaten var. Lütfen faaliyet merkezi durumu adını benzersiz bir isim olarak düzenleyin.";

                response.OperationCenterStatus = operationCenterStatus.ConvertToOperationCenterStatusView();

                return response;
            }

            object identityToken = _operationCenterStatusRepository.Add(operationCenterStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Faaliyet merkezi durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.OperationCenterStatus = _operationCenterStatusRepository.FindBy((int)identityToken).ConvertToOperationCenterStatusView();

            return response;
        }

        public ReadOperationCenterStatusResponse ReadOperationCenterStatus(ReadOperationCenterStatusRequest request)
        {
            ReadOperationCenterStatusResponse response = new ReadOperationCenterStatusResponse();
            response.ExceptionState = false;

            response.OperationCenterStatus = _operationCenterStatusRepository.FindBy(request.Id).ConvertToOperationCenterStatusView();

            return response;
        }

        public UpdateOperationCenterStatusResponse UpdateOperationCenterStatus(UpdateOperationCenterStatusRequest request)
        {
            UpdateOperationCenterStatusResponse response = new UpdateOperationCenterStatusResponse();
            response.ExceptionState = false;

            OperationCenterStatus operationCenterStatus = new OperationCenterStatus();
            operationCenterStatus.Id = request.Id;
            operationCenterStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            operationCenterStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (operationCenterStatus.Name != _operationCenterStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<OperationCenterStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_operationCenterStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir faaliyet merkezi durumu zaten var. Lütfen faaliyet merkezi durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.OperationCenterStatus = operationCenterStatus.ConvertToOperationCenterStatusView();

                    return response;
                }
            }

            _operationCenterStatusRepository.Save(operationCenterStatus);
            _unitOfWork.Commit();

            response.OperationCenterStatus = operationCenterStatus.ConvertToOperationCenterStatusView();

            return response;
        }

        public DeleteOperationCenterStatusResponse DeleteOperationCenterStatus(DeleteOperationCenterStatusRequest request)
        {
            DeleteOperationCenterStatusResponse response = new DeleteOperationCenterStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<OperationCenter>(c => c.OperationCenterStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_operationCenterRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini faaliyet merkezi durumunu kullanan faaliyet merkezleri var. Lütfen önce bu faaliyet merkezlerini silip ya da düzenleyip tekrar deneyin.";
                response.OperationCenterStatuses = _operationCenterStatusRepository.FindAll().ConvertToOperationCenterStatusSummaryView();

                return response;
            }

            _operationCenterStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.OperationCenterStatuses = _operationCenterStatusRepository.FindAll().ConvertToOperationCenterStatusSummaryView();

            return response;
        }

        public ListOperationCenterStatusesResponse ListOperationCenterSatuses(ListOperationCenterStatusesRequest request)
        {
            ListOperationCenterStatusesResponse response = new ListOperationCenterStatusesResponse();
            response.ExceptionState = false;

            response.OperationCenterStatuses = _operationCenterStatusRepository.FindAll().ConvertToOperationCenterStatusSummaryView();

            return response;
        }
        #endregion
    }
}
