using System.Collections.Generic;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Messaging
{
    public class DeleteScoreCardVarianceTypeResponse : ResponseBase
    {
        public IEnumerable<ScoreCardVarianceTypeSummaryView> ScoreCardVarianceTypes { get; set; }
    }
}
