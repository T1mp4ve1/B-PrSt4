using System.ComponentModel.DataAnnotations;

namespace Prigione.Models
{
    public class TrasgressoreModel
    {
        [Key]
        [Required]
        public Guid TrasgressoreID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(200)]
        public string Cognome { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Indirizzo { get; set; }
        [Required]
        [MaxLength(100)]
        public string Citta { get; set; }
        [Required]
        public int CAP { get; set; }
        [Required]
        [MaxLength(16)]
        public string CF { get; set; }

        public ICollection<VerbaleModelTest> Verbali { get; set; } = new List<VerbaleModelTest>();
    }
}
