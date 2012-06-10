using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IEmployeeServices
    {
        CreateDebitTypeResponse CreateDebitType(CreateDebitTypeRequest request);
        ReadDebitTypeResponse ReadDebitType(ReadDebitTypeRequest request);
        UpdateDebitTypeResponse UpdateDebitType(UpdateDebitTypeRequest request);
        DeleteDebitTypeResponse DeleteDebitType(DeleteDebitTypeRequest request);
        ListDebitTypesResponse ListDebitTypes(ListDebitTypesRequest request);

        CreateDebitStatusResponse CreateDebitStatus(CreateDebitStatusRequest request);
        ReadDebitStatusResponse ReadDebitStatus(ReadDebitStatusRequest request);
        UpdateDebitStatusResponse UpdateDebitStatus(UpdateDebitStatusRequest request);
        DeleteDebitStatusResponse DeleteDebitStatus(DeleteDebitStatusRequest request);
        ListDebitStatusesResponse ListDebitSatuses(ListDebitStatusesRequest request);

        CreateFileTypeResponse CreateFileType(CreateFileTypeRequest request);
        ReadFileTypeResponse ReadFileType(ReadFileTypeRequest request);
        UpdateFileTypeResponse UpdateFileType(UpdateFileTypeRequest request);
        DeleteFileTypeResponse DeleteFileType(DeleteFileTypeRequest request);
        ListFileTypesResponse ListFileTypes(ListFileTypesRequest request);

        CreateFileStatusResponse CreateFileStatus(CreateFileStatusRequest request);
        ReadFileStatusResponse ReadFileStatus(ReadFileStatusRequest request);
        UpdateFileStatusResponse UpdateFileStatus(UpdateFileStatusRequest request);
        DeleteFileStatusResponse DeleteFileStatus(DeleteFileStatusRequest request);
        ListFileStatusesResponse ListFileSatuses(ListFileStatusesRequest request);
    }
}
