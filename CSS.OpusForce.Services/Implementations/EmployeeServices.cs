using System;
using System.Linq;
using System.Globalization;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.Employees;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeDebitRepository _employeeDebitRepository;
        private readonly IDebitTypeRepository _debitTypeRepository;
        private readonly IDebitStatusRepository _debitStatusRepository;
        private readonly IEmployeeFileRepository _employeeFileRepository;
        private readonly IFileTypeRepository _fileTypeRepository;
        private readonly IFileStatusRepository _fileStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeServices(IEmployeeDebitRepository employeeDebitRepository,
            IDebitTypeRepository debitTypeRepository,
            IDebitStatusRepository debitStatusRepository,
            IEmployeeFileRepository fileRepository,
            IFileTypeRepository fileTypeRepository,
            IFileStatusRepository fileStatusRepository,
            IUnitOfWork unitOfWork)
        {
            _employeeDebitRepository = employeeDebitRepository;
            _debitTypeRepository = debitTypeRepository;
            _debitStatusRepository = debitStatusRepository;
            _employeeFileRepository = fileRepository;
            _fileTypeRepository = fileTypeRepository;
            _fileStatusRepository = fileStatusRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*               FileType Implementations                */
        /*********************************************************/
        #region FileType Implementations
        public CreateFileTypeResponse CreateFileType(CreateFileTypeRequest request)
        {
            CreateFileTypeResponse response = new CreateFileTypeResponse();
            response.ExceptionState = false;

            FileType fileType = new FileType();
            fileType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            fileType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<FileType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_fileTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir dosya tipi zaten var. Lütfen dosya tipi adını benzersiz bir isim olarak düzenleyin.";

                response.FileType = fileType.ConvertToFileTypeView();

                return response;
            }

            object identityToken = _fileTypeRepository.Add(fileType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Dosya tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.FileType = _fileTypeRepository.FindBy((int)identityToken).ConvertToFileTypeView();

            return response;
        }

        public ReadFileTypeResponse ReadFileType(ReadFileTypeRequest request)
        {
            ReadFileTypeResponse response = new ReadFileTypeResponse();
            response.ExceptionState = false;

            response.FileType = _fileTypeRepository.FindBy(request.Id).ConvertToFileTypeView();

            return response;
        }

        public UpdateFileTypeResponse UpdateFileType(UpdateFileTypeRequest request)
        {
            UpdateFileTypeResponse response = new UpdateFileTypeResponse();
            response.ExceptionState = false;

            FileType fileType = new FileType();
            fileType.Id = request.Id;
            fileType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            fileType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (fileType.Name != _fileTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<FileType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_fileTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir dosya tipi zaten var. Lütfen dosya tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.FileType = fileType.ConvertToFileTypeView();

                    return response;
                }
            }

            _fileTypeRepository.Save(fileType);
            _unitOfWork.Commit();

            response.FileType = fileType.ConvertToFileTypeView();

            return response;
        }

        public DeleteFileTypeResponse DeleteFileType(DeleteFileTypeRequest request)
        {
            DeleteFileTypeResponse response = new DeleteFileTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<EmployeeFile>(c => c.FileType.Id, request.Id, CriteriaOperator.Equal));
            if (_employeeFileRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini dosya tipini kullanan dosyalar var. Lütfen önce bu dosyaları silip ya da düzenleyip tekrar deneyin.";
                response.FileTypes = _fileTypeRepository.FindAll().ConvertToFileTypeSummaryView();

                return response;
            }

            _fileTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.FileTypes = _fileTypeRepository.FindAll().ConvertToFileTypeSummaryView();

            return response;
        }

        public ListFileTypesResponse ListFileTypes(ListFileTypesRequest request)
        {
            ListFileTypesResponse response = new ListFileTypesResponse();
            response.ExceptionState = false;

            response.FileTypes = _fileTypeRepository.FindAll().ConvertToFileTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*              FileStatus Implementations               */
        /*********************************************************/
        #region FileStatus Implementations
        public CreateFileStatusResponse CreateFileStatus(CreateFileStatusRequest request)
        {
            CreateFileStatusResponse response = new CreateFileStatusResponse();
            response.ExceptionState = false;

            FileStatus fileStatus = new FileStatus();
            fileStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            fileStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<FileStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_fileStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir dosya durumu zaten var. Lütfen dosya durumu adını benzersiz bir isim olarak düzenleyin.";

                response.FileStatus = fileStatus.ConvertToFileStatusView();

                return response;
            }

            object identityToken = _fileStatusRepository.Add(fileStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Dosya durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.FileStatus = _fileStatusRepository.FindBy((int)identityToken).ConvertToFileStatusView();

            return response;
        }

        public ReadFileStatusResponse ReadFileStatus(ReadFileStatusRequest request)
        {
            ReadFileStatusResponse response = new ReadFileStatusResponse();
            response.ExceptionState = false;

            response.FileStatus = _fileStatusRepository.FindBy(request.Id).ConvertToFileStatusView();

            return response;
        }

        public UpdateFileStatusResponse UpdateFileStatus(UpdateFileStatusRequest request)
        {
            UpdateFileStatusResponse response = new UpdateFileStatusResponse();
            response.ExceptionState = false;

            FileStatus fileStatus = new FileStatus();
            fileStatus.Id = request.Id;
            fileStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            fileStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (fileStatus.Name != _fileStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<FileStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_fileStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir dosya durumu zaten var. Lütfen dosya durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.FileStatus = fileStatus.ConvertToFileStatusView();

                    return response;
                }
            }

            _fileStatusRepository.Save(fileStatus);
            _unitOfWork.Commit();

            response.FileStatus = fileStatus.ConvertToFileStatusView();

            return response;
        }

        public DeleteFileStatusResponse DeleteFileStatus(DeleteFileStatusRequest request)
        {
            DeleteFileStatusResponse response = new DeleteFileStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<EmployeeFile>(c => c.FileStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_employeeFileRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini dosya durumunu kullanan dosyalar var. Lütfen önce bu dosyaları silip ya da düzenleyip tekrar deneyin.";
                response.FileStatuses = _fileStatusRepository.FindAll().ConvertToFileStatusSummaryView();

                return response;
            }

            _fileStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.FileStatuses = _fileStatusRepository.FindAll().ConvertToFileStatusSummaryView();

            return response;
        }

        public ListFileStatusesResponse ListFileSatuses(ListFileStatusesRequest request)
        {
            ListFileStatusesResponse response = new ListFileStatusesResponse();
            response.ExceptionState = false;

            response.FileStatuses = _fileStatusRepository.FindAll().ConvertToFileStatusSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*               DebitType Implementations               */
        /*********************************************************/
        #region DebitType Implementations
        public CreateDebitTypeResponse CreateDebitType(CreateDebitTypeRequest request)
        {
            CreateDebitTypeResponse response = new CreateDebitTypeResponse();
            response.ExceptionState = false;

            DebitType debitType = new DebitType();
            debitType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            debitType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<DebitType>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_debitTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir bakiye tipi zaten var. Lütfen bakiye tipi adını benzersiz bir isim olarak düzenleyin.";

                response.DebitType = debitType.ConvertToDebitTypeView();

                return response;
            }

            object identityToken = _debitTypeRepository.Add(debitType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bakiye tipi kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.DebitType = _debitTypeRepository.FindBy((int)identityToken).ConvertToDebitTypeView();

            return response;
        }

        public ReadDebitTypeResponse ReadDebitType(ReadDebitTypeRequest request)
        {
            ReadDebitTypeResponse response = new ReadDebitTypeResponse();
            response.ExceptionState = false;

            response.DebitType = _debitTypeRepository.FindBy(request.Id).ConvertToDebitTypeView();

            return response;
        }

        public UpdateDebitTypeResponse UpdateDebitType(UpdateDebitTypeRequest request)
        {
            UpdateDebitTypeResponse response = new UpdateDebitTypeResponse();
            response.ExceptionState = false;

            DebitType debitType = new DebitType();
            debitType.Id = request.Id;
            debitType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            debitType.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (debitType.Name != _debitTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<DebitType>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_debitTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir bakiye tipi zaten var. Lütfen bakiye tipi adını benzersiz bir isim olarak düzenleyin.";

                    response.DebitType = debitType.ConvertToDebitTypeView();

                    return response;
                }
            }

            _debitTypeRepository.Save(debitType);
            _unitOfWork.Commit();

            response.DebitType = debitType.ConvertToDebitTypeView();

            return response;
        }

        public DeleteDebitTypeResponse DeleteDebitType(DeleteDebitTypeRequest request)
        {
            DeleteDebitTypeResponse response = new DeleteDebitTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<EmployeeDebit>(c => c.DebitType.Id, request.Id, CriteriaOperator.Equal));
            if (_employeeDebitRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini bakiye tipini kullanan personel bakiyleri var. Lütfen önce bu personel bakiyelerini silip ya da düzenleyip tekrar deneyin.";
                response.DebitTypes = _debitTypeRepository.FindAll().ConvertToDebitTypeSummaryView();

                return response;
            }

            _debitTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.DebitTypes = _debitTypeRepository.FindAll().ConvertToDebitTypeSummaryView();

            return response;
        }

        public ListDebitTypesResponse ListDebitTypes(ListDebitTypesRequest request)
        {
            ListDebitTypesResponse response = new ListDebitTypesResponse();
            response.ExceptionState = false;

            response.DebitTypes = _debitTypeRepository.FindAll().ConvertToDebitTypeSummaryView();

            return response;
        }
        #endregion

        /*********************************************************/
        /*              DebitStatus Implementations              */
        /*********************************************************/
        #region DebitStatus Implementations
        public CreateDebitStatusResponse CreateDebitStatus(CreateDebitStatusRequest request)
        {
            CreateDebitStatusResponse response = new CreateDebitStatusResponse();
            response.ExceptionState = false;

            DebitStatus debitStatus = new DebitStatus();
            debitStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            debitStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<DebitStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
            if (_debitStatusRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir bakiye durumu zaten var. Lütfen bakiye durumu adını benzersiz bir isim olarak düzenleyin.";

                response.DebitStatus = debitStatus.ConvertToDebitStatusView();

                return response;
            }

            object identityToken = _debitStatusRepository.Add(debitStatus);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bakiye durumu kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.DebitStatus = _debitStatusRepository.FindBy((int)identityToken).ConvertToDebitStatusView();

            return response;
        }

        public ReadDebitStatusResponse ReadDebitStatus(ReadDebitStatusRequest request)
        {
            ReadDebitStatusResponse response = new ReadDebitStatusResponse();
            response.ExceptionState = false;

            response.DebitStatus = _debitStatusRepository.FindBy(request.Id).ConvertToDebitStatusView();

            return response;
        }

        public UpdateDebitStatusResponse UpdateDebitStatus(UpdateDebitStatusRequest request)
        {
            UpdateDebitStatusResponse response = new UpdateDebitStatusResponse();
            response.ExceptionState = false;

            DebitStatus debitStatus = new DebitStatus();
            debitStatus.Id = request.Id;
            debitStatus.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            debitStatus.Description = request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (debitStatus.Name != _debitStatusRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<DebitStatus>(c => c.Name, request.Name, CriteriaOperator.Equal));
                if (_debitStatusRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir bakiye durumu zaten var. Lütfen bakiye durumu adını benzersiz bir isim olarak düzenleyin.";

                    response.DebitStatus = debitStatus.ConvertToDebitStatusView();

                    return response;
                }
            }

            _debitStatusRepository.Save(debitStatus);
            _unitOfWork.Commit();

            response.DebitStatus = debitStatus.ConvertToDebitStatusView();

            return response;
        }

        public DeleteDebitStatusResponse DeleteDebitStatus(DeleteDebitStatusRequest request)
        {
            DeleteDebitStatusResponse response = new DeleteDebitStatusResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<EmployeeDebit>(c => c.DebitStatus.Id, request.Id, CriteriaOperator.Equal));
            if (_employeeDebitRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğini bakiye durumunu kullanan personel bakiyeleri var. Lütfen önce bu personel bakiyelerini silip ya da düzenleyip tekrar deneyin.";
                response.DebitStatuses = _debitStatusRepository.FindAll().ConvertToDebitStatusSummaryView();

                return response;
            }

            _debitStatusRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.DebitStatuses = _debitStatusRepository.FindAll().ConvertToDebitStatusSummaryView();

            return response;
        }

        public ListDebitStatusesResponse ListDebitSatuses(ListDebitStatusesRequest request)
        {
            ListDebitStatusesResponse response = new ListDebitStatusesResponse();
            response.ExceptionState = false;

            response.DebitStatuses = _debitStatusRepository.FindAll().ConvertToDebitStatusSummaryView();

            return response;
        }
        #endregion
    }
}
