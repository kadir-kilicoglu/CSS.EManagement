using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class AgreementTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Sözleşme Türü Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Sözleşme Türü Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Sözleşme Türü Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
