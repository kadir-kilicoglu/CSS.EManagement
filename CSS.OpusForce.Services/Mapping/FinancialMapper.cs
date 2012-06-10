using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Financials;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class FinancialMapper
    {
        public static IEnumerable<FinancialActivityTypeSummaryView> ConvertToFinancialActivityTypeSummaryView(this IEnumerable<FinancialActivityType> financialActivityTypes)
        {
            List<FinancialActivityTypeSummaryView> tempList = new List<FinancialActivityTypeSummaryView>();

            foreach (FinancialActivityType p in financialActivityTypes)
            {
                FinancialActivityTypeSummaryView tempView = new FinancialActivityTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static FinancialActivityTypeView ConvertToFinancialActivityTypeView(this FinancialActivityType financialActivityType)
        {
            FinancialActivityTypeView tempView = new FinancialActivityTypeView();
            tempView.Id = financialActivityType.Id;
            tempView.Name = financialActivityType.Name;
            tempView.Description = financialActivityType.Description;

            return tempView;
        }

        public static IEnumerable<PaymentTypeSummaryView> ConvertToPaymentTypeSummaryView(this IEnumerable<PaymentType> paymentTypes)
        {
            List<PaymentTypeSummaryView> tempList = new List<PaymentTypeSummaryView>();

            foreach (PaymentType p in paymentTypes)
            {
                PaymentTypeSummaryView tempView = new PaymentTypeSummaryView();
                tempView.Id = p.Id;
                tempView.Name = p.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static PaymentTypeView ConvertToPaymentTypeView(this PaymentType paymentType)
        {
            PaymentTypeView tempView = new PaymentTypeView();
            tempView.Id = paymentType.Id;
            tempView.Name = paymentType.Name;
            tempView.Description = paymentType.Description;

            return tempView;
        }
    }
}
