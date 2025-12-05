using System.ComponentModel.DataAnnotations;

namespace Prigione.Models
{
    public class VerbaleModel
    {
        [Key]
        [Required]
        public Guid VerbaleID { get; set; }
        [Required]
        public DateTime DataViolazione { get; set; }
        [Required]
        public string IndirizzoViolazione { get; set; }
        [Required]
        public DateTime DataVerbale { get; set; }
        [Required]
        public decimal Importo { get; set; }
        [Required]
        public int DecurtamentoPunti { get; set; }

        //foreign key
        [Required]
        public Guid TrasgressoreID { get; set; }
        public TrasgressoreModel Trasgressore { get; set; }

        [Required]
        public Guid ViolazioneID { get; set; }
        public ViolazioneModel Violazione { get; set; }
    }
}
