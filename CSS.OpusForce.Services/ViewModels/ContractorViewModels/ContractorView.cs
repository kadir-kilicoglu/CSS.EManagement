using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class ContractorView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Taşeron Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Firma Faaliyet Alanı Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Taşeron Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen Sorumlu Kişi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Sorumlu Kişi Adı 128 Karakterden Büyük Olamaz.")]
        public string ResponsibleHead { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Adres 512 Karakterden Büyük Olamaz.")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Telefon Numarası 32 Karakterden Büyük Olamaz.")]
        public string PhoneNumber1 { get; set; }

        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Telefon Numarası 32 Karakterden Büyük Olamaz.")]
        public string PhoneNumber2 { get; set; }
                
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Eposta Adresi 32 Karakterden Büyük Olamaz.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Lütfen Geçerli Bir Eposta Adresi Giriniz.")]
        public string MailAddress { get; set; }

        [DataType(DataType.Text)]
        [StringLength(29, ErrorMessage = "IBAN Numarası 29 Karakterden Büyük Olamaz.")]
        [RegularExpression(@"^TR\d{2}[ ]\d{4}[ ]00[ ]\d{16}$", ErrorMessage = "Lütfen Geçerli Bir IBAN Numarası Giriniz.")]
        public string BankAccountNumber { get; set; }

        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Fatura Adı 128 Karakterden Büyük Olamaz.")]
        public string InvoiceName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Fatura Adresi 512 Karakterden Büyük Olamaz.")]
        public string InvoiceAddress { get; set; }

        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Vergi Dairesi Adı Karakterden Büyük Olamaz.")]
        public string TaxOffice { get; set; }

        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "Vergi Numarası 10 Karakterden Büyük Olamaz.")]
        [RegularExpression(@"^\d{10}", ErrorMessage = "Lütfen Geçerli Bir Vergi Numarası Giriniz.")]
        public string TaxNumber { get; set; }
                
        [Required(ErrorMessage = "Lütfen Taşeron Durumunu Seçiniz.")]
        [Range(1, 1000000, ErrorMessage = "Lütfen Taşeron Durumunu Seçiniz.")]
        public int ContractorStatusId { get; set; }
    }
}
