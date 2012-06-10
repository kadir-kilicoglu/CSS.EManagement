using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class CalendarView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Takvim Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Takvim Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Takvim Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
