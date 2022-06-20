using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kalkulatol.Models
{
    [Table("Skladniki")]
    public class SkladnikModel
    {
        [Key]
        public int SkladnikId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole wymagane")]
        [MaxLength(255)]

        public string SkladnikName { get; set; }
        [DisplayName("Białko w 100g")]
        [Required]
        [DefaultValue(0)]
        public int SkladnikProtPer100 { get; set; }
        [DisplayName("Węglowodany w 100g")]
        [Required]
        [DefaultValue(0)]
        public int SkladnikCarbPer100 { get; set; }
        [DisplayName("Tłuszcze w 100g")]
        [Required]
        [DefaultValue(0)]
        public int SkladnikFatPer100 { get; set; }
        [DisplayName("Ilość w gramach")]
        [Required]
        [DefaultValue(0)]
        public double SkladnikIlosc { get; set; }
        [DisplayName("Kcal")]
        [DefaultValue(0)]
        public double SkladnikKcal { get; set; }
    }
}
