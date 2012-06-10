using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class ScoreCardVarianceTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Puantaj Varyans Türü Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Puantaj Varyans Türü Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Puantaj Varyans Türü Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
