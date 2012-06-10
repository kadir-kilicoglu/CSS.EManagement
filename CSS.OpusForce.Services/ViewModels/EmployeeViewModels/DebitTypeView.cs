using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class DebitTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Bakiye Tipi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Bakiye Tipi Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Bakiye Tipi Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
