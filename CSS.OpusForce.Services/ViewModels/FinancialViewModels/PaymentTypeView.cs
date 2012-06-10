using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class PaymentTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Ödeme Tipi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Ödeme Tipi Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Ödeme Tipi Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
