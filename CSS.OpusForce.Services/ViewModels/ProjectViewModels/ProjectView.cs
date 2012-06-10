using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSS.OpusForce.Services.ViewModels
{
    public class ProjectView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Lütfen Proje Adını Giriniz.")]
        [DataType(DataType.Text)]
        [StringLength(128, ErrorMessage = "Proje Adı 128 Karakterden Büyük Olamaz.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(512, ErrorMessage = "Proje Açıklaması 512 Karakterden Büyük Olamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen Projenin Durumunu Seçiniz.")]
        public int ProjectStatusId { get; set; }
        public string ProjectStatusName { get; set; }

        [Required(ErrorMessage = "Lütfen Projenin Türünü Seçiniz.")]
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }

        [Required(ErrorMessage = "Lütfen Projenin Bağlı Olduğu Firmayı Seçiniz.")]
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Lütfen Projenin Başlangıç Tarihini Seçiniz.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public System.Nullable<DateTime> EndDate { get; set; }

        // TODO: End date on sonlandi
    }
}
