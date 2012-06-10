using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{    
    public class CompanyTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Firma Faaliyet Alanı Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Firma Faaliyet Alanı Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Firma Faaliyet Alanı Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
