using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IContractorServices
    {
        CreateContractorResponse CreateContractor(CreateContractorRequest request);
        ReadContractorResponse ReadContractor(ReadContractorRequest request);
        UpdateContractorResponse UpdateContractor(UpdateContractorRequest request);
        DeleteContractorResponse DeleteContractor(DeleteContractorRequest request);
        ListContractorsResponse ListContractors(ListContractorsRequest request);

        CreateContractorStatusResponse CreateContractorStatus(CreateContractorStatusRequest request);
        ReadContractorStatusResponse ReadContractorStatus(ReadContractorStatusRequest request);
        UpdateContractorStatusResponse UpdateContractorStatus(UpdateContractorStatusRequest request);
        DeleteContractorStatusResponse DeleteContractorStatus(DeleteContractorStatusRequest request);
        ListContractorStatusesResponse ListContractorSatuses(ListContractorStatusesRequest request);
    }
}
