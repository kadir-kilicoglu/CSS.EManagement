namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateCompanyRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int CompanyTypeId { get; set; }
        public int? ParentCompanyId { get; set; }
    }
}
