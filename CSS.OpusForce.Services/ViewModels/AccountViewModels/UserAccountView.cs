using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class UserAccountView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(32, ErrorMessage = "Kullanıcı Adı 32 Karakterden Büyük Olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Şifresini Giriniz.")]
        [DataType(DataType.Password)]
        [StringLength(32, ErrorMessage = "Kullanıcı Şifresi 32 Karakterden Büyük Olamaz.")]
        public string Password { get; set; }

        public CompanyView Company { get; set; }

        public IEnumerable<RoleView> Roles { get; set; }
    }
}
