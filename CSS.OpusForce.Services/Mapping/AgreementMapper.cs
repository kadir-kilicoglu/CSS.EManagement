using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Agreements;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class AgreementMapper
    {
        public static IEnumerable<AgreementTypeSummaryView> ConvertToAgreementTypeSummaryView(this IEnumerable<AgreementType> agreementTypes)
        {
            List<AgreementTypeSummaryView> tempList = new List<AgreementTypeSummaryView>();

            foreach (AgreementType p in agreementTypes)
            {
                AgreementTypeSummaryView tempView = new AgreementTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static AgreementTypeView ConvertToAgreementTypeView(this AgreementType agreementType)
        {
            AgreementTypeView tempView = new AgreementTypeView();
            tempView.Id = agreementType.Id;
            tempView.Name = agreementType.Name;
            tempView.Description = agreementType.Description;

            return tempView;
        }

        public static IEnumerable<AgreementStatusSummaryView> ConvertToAgreementStatusSummaryView(this IEnumerable<AgreementStatus> agreementStatuses)
        {
            List<AgreementStatusSummaryView> tempList = new List<AgreementStatusSummaryView>();

            foreach (AgreementStatus p in agreementStatuses)
            {
                AgreementStatusSummaryView tempView = new AgreementStatusSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static AgreementStatusView ConvertToAgreementStatusView(this AgreementStatus agreementStatus)
        {
            AgreementStatusView tempView = new AgreementStatusView();
            tempView.Id = agreementStatus.Id;
            tempView.Name = agreementStatus.Name;
            tempView.Description = agreementStatus.Description;

            return tempView;
        }
    }
}
