using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class ListScoreCardVarianceTypesResponse : ResponseBase
    {
        public IEnumerable<ScoreCardVarianceTypeSummaryView> ScoreCardVarianceTypes { get; set; }
    }
}
