using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.ScoreCards;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class ScoreCardMapper
    {
        public static IEnumerable<ScoreCardVarianceTypeSummaryView> ConvertToScoreCardVarianceTypeSummaryView(this IEnumerable<VarianceType> varianceTypes)
        {
            List<ScoreCardVarianceTypeSummaryView> tempList = new List<ScoreCardVarianceTypeSummaryView>();

            foreach (VarianceType c in varianceTypes)
            {
                ContractorSummaryView tempView = new ContractorSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;
            }

            return tempList;
        }

        public static ScoreCardVarianceTypeView ConvertToScoreCardVarianceTypeView(this VarianceType varianceType)
        {
            ScoreCardVarianceTypeView tempView = new ScoreCardVarianceTypeView();
            tempView.Id = varianceType.Id;
            tempView.Name = varianceType.Name;
            tempView.Description = varianceType.Description;

            return tempView;
        }
    }
}
