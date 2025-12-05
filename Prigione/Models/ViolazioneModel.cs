using System.ComponentModel.DataAnnotations;

namespace Prigione.Models
{
    public class ViolazioneModel
    {
        [Key]
        [Required]
        public int ViolazioneID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descrizione { get; set; }
        public ICollection<VerbaleModelTest> Verbali { get; set; } = new List<VerbaleModelTest>();
    }
}