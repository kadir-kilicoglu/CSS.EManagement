using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class CalendarDayTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Gün Türü Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Gün Türü Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Gün Türü Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
