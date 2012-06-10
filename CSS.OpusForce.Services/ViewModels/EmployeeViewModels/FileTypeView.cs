using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class FileTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Dosya Tipi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Dosya Tipi Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Dosya Tipi Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
