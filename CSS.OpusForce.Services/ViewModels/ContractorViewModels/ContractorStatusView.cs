using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class ContractorStatusView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Taşeron Durumu Adını Giriniz.")]   
        [DataType(DataType.Text)]             
        [StringLength(128, ErrorMessage= "Taşeron Durumu Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Taşeron Durumu Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
