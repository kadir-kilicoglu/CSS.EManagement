using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class FinancialActivityTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Mali Hareket Tipi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Mali Hareket Tipi Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Mali Hareket Tipi Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
