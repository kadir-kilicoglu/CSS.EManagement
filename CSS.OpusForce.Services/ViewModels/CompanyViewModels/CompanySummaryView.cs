namespace CSS.OpusForce.Services.ViewModels
{
    public class CompanySummaryView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentCompanyName { get; set; }
        public string CompanyTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
