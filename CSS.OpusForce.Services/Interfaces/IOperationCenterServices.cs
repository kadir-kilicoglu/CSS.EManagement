using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IOperationCenterServices
    {
        CreateOperationCenterTypeResponse CreateOperationCenterType(CreateOperationCenterTypeRequest request);
        ReadOperationCenterTypeResponse ReadOperationCenterType(ReadOperationCenterTypeRequest request);
        UpdateOperationCenterTypeResponse UpdateOperationCenterType(UpdateOperationCenterTypeRequest request);
        DeleteOperationCenterTypeResponse DeleteOperationCenterType(DeleteOperationCenterTypeRequest request);
        ListOperationCenterTypesResponse ListOperationCenterTypes(ListOperationCenterTypesRequest request);

        CreateOperationCenterStatusResponse CreateOperationCenterStatus(CreateOperationCenterStatusRequest request);
        ReadOperationCenterStatusResponse ReadOperationCenterStatus(ReadOperationCenterStatusRequest request);
        UpdateOperationCenterStatusResponse UpdateOperationCenterStatus(UpdateOperationCenterStatusRequest request);
        DeleteOperationCenterStatusResponse DeleteOperationCenterStatus(DeleteOperationCenterStatusRequest request);
        ListOperationCenterStatusesResponse ListOperationCenterSatuses(ListOperationCenterStatusesRequest request);
    }
}
