using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Contractors;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class ContractorMapper
    {
        public static IEnumerable<ContractorStatusSummaryView> ConvertToContractorStatusSummaryView(this IEnumerable<ContractorStatus> contractorStatuses)
        {
            List<ContractorStatusSummaryView> tempList = new List<ContractorStatusSummaryView>();

            foreach (ContractorStatus c in contractorStatuses)
            {
                ContractorStatusSummaryView tempView = new ContractorStatusSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static ContractorStatusView ConvertToContractorStatusView(this ContractorStatus contractorSatus)
        {
            ContractorStatusView tempView = new ContractorStatusView();
            tempView.Id = contractorSatus.Id;
            tempView.Name = contractorSatus.Name;
            tempView.Description = contractorSatus.Description;

            return tempView;
        }

        public static IEnumerable<ContractorSummaryView> ConvertToContractorSummaryView(this IEnumerable<Contractor> contractors)
        {
            List<ContractorSummaryView> tempList = new List<ContractorSummaryView>();

            foreach (Contractor c in contractors)
            {
                ContractorSummaryView tempView = new ContractorSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;
                tempView.ResponsibleHead = c.ResponsibleHead;
                tempView.ContractorStatusName = c.ContractorStatus.Name;
            }

            return tempList;
        }

        public static ContractorView ConvertToContractorView(this Contractor contractor)
        {
            ContractorView tempView = new ContractorView();
            tempView.Id = contractor.Id;
            tempView.Name = contractor.Name;
            tempView.Description = contractor.Description;
            tempView.ResponsibleHead = contractor.ResponsibleHead;
            tempView.Address = contractor.Address;
            tempView.PhoneNumber1 = contractor.PhoneNumber1;
            tempView.PhoneNumber2 = contractor.PhoneNumber2;
            tempView.MailAddress = contractor.MailAddress;
            tempView.BankAccountNumber = contractor.BankAccountNumber;
            tempView.InvoiceName = contractor.InvoiceName;
            tempView.MailAddress = contractor.MailAddress;
            tempView.TaxOffice = contractor.TaxOffice;
            tempView.TaxNumber = contractor.TaxNumber;
            tempView.ContractorStatusId = contractor.ContractorStatus.Id;

            return tempView;
        }
    }
}
