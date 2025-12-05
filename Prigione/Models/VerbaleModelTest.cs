using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prigione.Models
{
    public class VerbaleModelTest
    {
        [Key]
        [Required]
        public Guid VerbaleID { get; set; }
        [Required]
        public DateOnly DataViolazione { get; set; }
        [Required]
        public string IndirizzoViolazione { get; set; }
        [Required]
        public DateOnly DataVerbale { get; set; }
        [Required]
        public decimal Importo { get; set; }
        [Required]
        public int DecurtamentoPunti { get; set; }

        //foreign key
        [Required]
        public Guid TrasgressoreID { get; set; }
        [ForeignKey("TrasgressoreID")]
        public TrasgressoreModel? Trasgressore { get; set; }

        [Required]
        public int ViolazioneID { get; set; }
        [ForeignKey("ViolazioneID")]
        public ViolazioneModel? Violazione { get; set; }
    }
}
