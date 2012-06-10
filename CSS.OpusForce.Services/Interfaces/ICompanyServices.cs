using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface ICompanyServices
    {
        CreateCompanyResponse CreateCompany(CreateCompanyRequest request);
        ReadCompanyResponse ReadCompany(ReadCompanyRequest request);
        UpdateCompanyResponse UpdateCompany(UpdateCompanyRequest request);
        DeleteCompanyResponse DeleteCompany(DeleteCompanyRequest request);
        ListCompaniesResponse ListCompanies(ListCompaniesRequest request);
        
        CreateCompanyTypeResponse CreateCompanyType(CreateCompanyTypeRequest request);
        ReadCompanyTypeResponse ReadCompanyType(ReadCompanyTypeRequest request);
        UpdateCompanyTypeResponse UpdateCompanyType(UpdateCompanyTypeRequest request);
        DeleteCompanyTypeResponse DeleteCompanyType(DeleteCompanyTypeRequest request);
        ListCompanyTypesResponse ListCompanyTypes(ListCompanyTypesRequest request);
    }
}
