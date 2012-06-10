using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class OperationCenterTypeView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Faaliyet Merkezi Tipi Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Faaliyet Merkezi Tipi Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Faaliyet Merkezi Tipi Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
