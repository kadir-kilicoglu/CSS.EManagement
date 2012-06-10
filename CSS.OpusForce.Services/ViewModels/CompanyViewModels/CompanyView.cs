using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class CompanyView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Firma Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Firma Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Firma Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Lütfen Firma Faaliyet Alanını Seçiniz.")]
        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }

        public int? ParentCompanyId { get; set; }
        public string ParentCompanyName { get; set; }
    }
}
