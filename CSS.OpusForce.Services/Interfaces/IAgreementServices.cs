using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IAgreementServices
    {
        CreateAgreementStatusResponse CreateAgreementStatus(CreateAgreementStatusRequest request);
        ReadAgreementStatusResponse ReadAgreementStatus(ReadAgreementStatusRequest request);
        UpdateAgreementStatusResponse UpdateAgreementStatus(UpdateAgreementStatusRequest request);
        DeleteAgreementStatusResponse DeleteAgreementStatus(DeleteAgreementStatusRequest request);
        ListAgreementStatusesResponse ListAgreementStatuses(ListAgreementStatusesRequest request);

        CreateAgreementTypeResponse CreateAgreementType(CreateAgreementTypeRequest request);
        ReadAgreementTypeResponse ReadAgreementType(ReadAgreementTypeRequest request);
        UpdateAgreementTypeResponse UpdateAgreementType(UpdateAgreementTypeRequest request);
        DeleteAgreementTypeResponse DeleteAgreementType(DeleteAgreementTypeRequest request);
        ListAgreementTypesResponse ListAgreementTypes(ListAgreementTypesRequest request);
    }
}
