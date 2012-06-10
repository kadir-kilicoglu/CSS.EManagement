using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class AgreementStatusView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Sözleşme Durumu Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Sözleşme Durumu Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Sözleşme Durumu Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
