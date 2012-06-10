using CSS.OpusForce.Services.Messaging;

namespace CSS.OpusForce.Services.Interfaces
{
    public interface IScoreCardServices
    {
        CreateScoreCardVarianceTypeResponse CreateScoreCardVarianceType(CreateScoreCardVarianceTypeRequest request);
        ReadScoreCardVarianceTypeResponse ReadScoreCardVarianceType(ReadScoreCardVarianceTypeRequest request);
        UpdateScoreCardVarianceTypeResponse UpdateScoreCardVarianceType(UpdateScoreCardVarianceTypeRequest request);
        DeleteScoreCardVarianceTypeResponse DeleteScoreCardVarianceType(DeleteScoreCardVarianceTypeRequest request);
        ListScoreCardVarianceTypesResponse ListScoreCardVarianceTypes(ListScoreCardVarianceTypesRequest request);
    }
}
