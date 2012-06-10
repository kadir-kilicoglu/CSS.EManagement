using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class RoleView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Rol Adını Giriniz.")]   
        [DataType(DataType.Text)]             
        [StringLength(128, ErrorMessage= "Rol Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Rol Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }
    }
}
