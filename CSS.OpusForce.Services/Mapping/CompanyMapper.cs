using System.Collections;
using System.Collections.Generic;

using CSS.Infrastructure.Domain;
using CSS.OpusForce.Model.Companies;
using CSS.OpusForce.Services.Messaging;
using CSS.OpusForce.Services.ViewModels;

namespace CSS.OpusForce.Services.Mapping
{
    public static class CompanyMapper
    {
        public static IEnumerable<CompanySummaryView> ConvertToCompanySummaryView(this IEnumerable<Company> companies)
        {
            List<CompanySummaryView> tempList = new List<CompanySummaryView>();

            foreach (Company c in companies)
            {
                CompanySummaryView tempView = new CompanySummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;
                tempView.CompanyTypeName = c.CompanyType.Name;
                if (c.ParentCompany == null)
                {
                    tempView.ParentCompanyName = string.Empty;                    
                }
                else
                {
                    tempView.ParentCompanyName = c.ParentCompany.Name;
                }
                tempView.IsActive = c.IsActive;

                tempList.Add(tempView);
            }
            

            return tempList;
        }

        public static CompanyView ConvertToCompanyView(this Company company)
        {
            CompanyView tempView = new CompanyView();
            if (company == null)
            {
                return null;
            }

            tempView.Id = company.Id;
            tempView.Name = company.Name;
            tempView.Description = company.Description;
            tempView.IsActive = company.IsActive;
            tempView.CompanyTypeId = company.CompanyType.Id;
            tempView.CompanyTypeName = company.CompanyType.Name;
            if (company.ParentCompany == null)
            {
                tempView.ParentCompanyId = 0;
                tempView.ParentCompanyName = string.Empty;
            }
            else
            {
                tempView.ParentCompanyId = company.ParentCompany.Id;
                tempView.ParentCompanyName = company.ParentCompany.Name;
            }            

            return tempView;
        }

        public static IEnumerable<CompanyTypeSummaryView> ConvertToCompanyTypeSummaryView(this IEnumerable<CompanyType> companyTypes)
        {
            List<CompanyTypeSummaryView> tempList = new List<CompanyTypeSummaryView>();

            foreach (CompanyType c in companyTypes)
            {
                CompanyTypeSummaryView tempView = new CompanyTypeSummaryView();
                tempView.Id = c.Id;
                tempView.Name = c.Name;            

                tempList.Add(tempView);
            }

            return tempList;
        }

        public static CompanyTypeView ConvertToCompanyTypeView(this CompanyType companyType)
        {
            CompanyTypeView tempView = new CompanyTypeView();
            tempView.Id = companyType.Id;
            tempView.Name = companyType.Name;
            tempView.Description = companyType.Description;

            return tempView;
        }

        public static CompanyType ConvertFromCompanyTypeView(this CompanyTypeView companyTypeView)
        {
            CompanyType tempEntity = new CompanyType();
            tempEntity.Id = companyTypeView.Id;
            tempEntity.Name = companyTypeView.Name;
            tempEntity.Description = companyTypeView.Description;

            return tempEntity;
        }
    }
}
