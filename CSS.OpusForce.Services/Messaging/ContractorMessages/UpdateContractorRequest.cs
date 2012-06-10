namespace CSS.OpusForce.Services.Messaging
{
    public class UpdateContractorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ResponsibleHead { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string MailAddress { get; set; }
        public string BankAccountNumber { get; set; }
        public string InvoiceName { get; set; }
        public string InvoiceAddress { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public int ContractorStatusId { get; set; }
    }
}
