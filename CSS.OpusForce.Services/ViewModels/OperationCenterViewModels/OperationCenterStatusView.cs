using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class OperationCenterStatusView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Faaliyet Merkezi Durumu Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Faaliyet Merkezi Durumu Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Faaliyet Merkezi Durumu Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
