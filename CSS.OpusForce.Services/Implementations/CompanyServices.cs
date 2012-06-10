using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

using CSS.Infrastructure.Querying;
using CSS.OpusForce.Model.Companies;
using CSS.Infrastructure.UnitOfWork;
using CSS.OpusForce.Services.Mapping;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.Interfaces;

namespace CSS.OpusForce.Services.Implementations
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyTypeRepository _companyTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyServices(ICompanyRepository companyRepository, 
            ICompanyTypeRepository companyTypeRepository, 
            IUnitOfWork unitOfWork)
        {
            _companyRepository = companyRepository;
            _companyTypeRepository = companyTypeRepository;
            _unitOfWork = unitOfWork;
        }

        /*********************************************************/
        /*                Company Implementations                */
        /*********************************************************/
        #region Company Implementations
        public CreateCompanyResponse CreateCompany(CreateCompanyRequest request)
        {
            CreateCompanyResponse response = new CreateCompanyResponse();
            response.ExceptionState = false;

            Company company = new Company();
            company.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            company.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));
            company.IsActive = request.IsActive;
            company.CompanyType = _companyTypeRepository.FindBy(request.CompanyTypeId);
            company.ParentCompany = _companyRepository.FindBy(request.ParentCompanyId ?? 0);
            
            Query query = new Query();            
            query.Add(Criterion.Create<Company>(c => c.ParentCompany, null, CriteriaOperator.IsNull));

            if (company.ParentCompany == null && _companyRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Zaten bir ana firma var. Lütfen oluşturmaya çalıştığınız firmanın bağlı olduğu firmayı seçiniz.";

                return response;
            }     

            query = new Query();
            query.Add(Criterion.Create<Company>(c => c.Name, company.Name, CriteriaOperator.Equal));
            if (_companyRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir firma zaten var. Lütfen farklı bir firma ekleyin ya da mevcut firmalardan birini düzenleyin.";

                return response;
            }

            object identityToken = _companyRepository.Add(company);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Firma kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.Company = _companyRepository.FindBy((int)identityToken).ConvertToCompanyView();

            return response;
        }

        public ReadCompanyResponse ReadCompany(ReadCompanyRequest request)
        {
            ReadCompanyResponse response = new ReadCompanyResponse();
            response.ExceptionState = false;

            response.Company = _companyRepository.FindBy(request.Id).ConvertToCompanyView();

            return response;
        }

        public UpdateCompanyResponse UpdateCompany(UpdateCompanyRequest request)
        {
            UpdateCompanyResponse response = new UpdateCompanyResponse();
            response.ExceptionState = false;

            Company company = new Company();
            company.Id = request.Id;
            company.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            company.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));
            company.IsActive = request.IsActive;
            company.CompanyType = _companyTypeRepository.FindBy(request.CompanyTypeId);
            company.ParentCompany = _companyRepository.FindBy(request.ParentCompanyId ?? 0);

            Query query = new Query();

            if (company.ParentCompany == null)
            {
                query.Add(Criterion.Create<Company>(c => c.Id, company.Id, CriteriaOperator.NotEqual));
                query.Add(Criterion.Create<Company>(c => c.ParentCompany, null, CriteriaOperator.IsNull));

                if (_companyRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Zaten bir ana firma var. Lütfen oluşturmaya çalıştığınız firmanın bağlı olduğu firmayı seçiniz.";

                    return response;
                }
            }

            if (company.Name != _companyRepository.FindBy(request.Id).Name)
            {
                query = new Query();
                query.Add(Criterion.Create<Company>(c => c.Name, company.Name, CriteriaOperator.Equal));
                if (_companyRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir firma zaten var. Lütfen firma adını benzersiz bir isim olarak düzenleyin.";

                    response.Company = company.ConvertToCompanyView();

                    return response;
                }
            }

            _companyRepository.Save(company);
            _unitOfWork.Commit();

            response.Company = company.ConvertToCompanyView();

            return response;
        }

        public DeleteCompanyResponse DeleteCompany(DeleteCompanyRequest request)
        {
            DeleteCompanyResponse response = new DeleteCompanyResponse();
            response.ExceptionState = false;

            if (_companyRepository.FindBy(request.Id).Companies.Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğiniz firmaya bağlı firmalar var. Lütfen önce bu firmaları silip ya da düzenleyip tekrar deneyin.";
                response.Companies = _companyRepository.FindAll().ConvertToCompanySummaryView();

                return response;
            }


            _companyRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.Companies = _companyRepository.FindAll().ConvertToCompanySummaryView();
            return response;
        }

        public ListCompaniesResponse ListCompanies(ListCompaniesRequest request)
        {
            ListCompaniesResponse response = new ListCompaniesResponse();
            response.ExceptionState = false;

            response.Companies = _companyRepository.FindAll().ConvertToCompanySummaryView();

            return response;
        }
        #endregion
        /*********************************************************/
        /*            CompanyType Implementations                */
        /*********************************************************/
        #region CompanyType Implementations
        public CreateCompanyTypeResponse CreateCompanyType(CreateCompanyTypeRequest request)
        {
            CreateCompanyTypeResponse response = new CreateCompanyTypeResponse();
            response.ExceptionState = false;

            CompanyType companyType = new CompanyType();
            companyType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            companyType.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            Query query = new Query();
            query.Add(Criterion.Create<CompanyType>(c => c.Name, companyType.Name, CriteriaOperator.Equal));
            if (_companyTypeRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Bu isimde bir firma faaliyet alanı zaten var. Lütfen farklı bir faaliyet alanı ekleyin ya da mevcut faaliyet alanlarından birini düzenleyin.";

                return response;
            }

            object identityToken = _companyTypeRepository.Add(companyType);
            _unitOfWork.Commit();

            if (identityToken == null)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Firma faaliyet alanı kaydedilemedi. Lütfen daha sonra tekrar deneyin.";

                return response;
            }

            response.CompanyType = _companyTypeRepository.FindBy((int)identityToken).ConvertToCompanyTypeView();            

            return response;
        }

        public ReadCompanyTypeResponse ReadCompanyType(ReadCompanyTypeRequest request)
        {
            ReadCompanyTypeResponse response = new ReadCompanyTypeResponse();
            response.ExceptionState = false;

            response.CompanyType = _companyTypeRepository.FindBy(request.Id).ConvertToCompanyTypeView();

            return response;
        }

        public UpdateCompanyTypeResponse UpdateCompanyType(UpdateCompanyTypeRequest request)
        {
            UpdateCompanyTypeResponse response = new UpdateCompanyTypeResponse();
            response.ExceptionState = false;

            CompanyType companyType = new CompanyType();
            companyType.Id = request.Id;
            companyType.Name = request.Name.ToUpper(new CultureInfo("tr-TR"));
            companyType.Description = string.IsNullOrEmpty(request.Description) ? string.Empty : request.Description.ToUpper(new CultureInfo("tr-TR"));

            if (companyType.Name != _companyTypeRepository.FindBy(request.Id).Name)
            {
                Query query = new Query();
                query.Add(Criterion.Create<CompanyType>(c => c.Name, companyType.Name, CriteriaOperator.Equal));
                if (_companyTypeRepository.FindBy(query).Count() > 0)
                {
                    response.ExceptionState = true;
                    response.ExceptionMessage = @"Bu isimde bir firma faaliyet alanı zaten var. Lütfen faaliyet alanı adını benzersiz bir isim olarak düzenleyin.";

                    response.CompanyType = companyType.ConvertToCompanyTypeView();

                    return response;
                }
            }

            _companyTypeRepository.Save(companyType);
            _unitOfWork.Commit();

            response.CompanyType = companyType.ConvertToCompanyTypeView();

            return response;
        }

        public DeleteCompanyTypeResponse DeleteCompanyType(DeleteCompanyTypeRequest request)
        {
            DeleteCompanyTypeResponse response = new DeleteCompanyTypeResponse();
            response.ExceptionState = false;

            Query query = new Query();
            query.Add(Criterion.Create<Company>(c => c.CompanyType.Id, request.Id, CriteriaOperator.Equal));
            if (_companyRepository.FindBy(query).Count() > 0)
            {
                response.ExceptionState = true;
                response.ExceptionMessage = @"Silmek istediğiniz faaliyet alanını kullanan firmalar var. Lütfen önce bu firmaları silip ya da düzenleyip tekrar deneyin.";
                response.CompanyTypes = _companyTypeRepository.FindAll().ConvertToCompanyTypeSummaryView();

                return response;
            }


            _companyTypeRepository.Remove(request.Id);
            _unitOfWork.Commit();

            response.CompanyTypes = _companyTypeRepository.FindAll().ConvertToCompanyTypeSummaryView();
            return response;
        }

        public ListCompanyTypesResponse ListCompanyTypes(ListCompanyTypesRequest request)
        {
            ListCompanyTypesResponse response = new ListCompanyTypesResponse();
            response.ExceptionState = false;

            response.CompanyTypes = _companyTypeRepository.FindAll().ConvertToCompanyTypeSummaryView();

            return response;
        }
        #endregion
    }
}