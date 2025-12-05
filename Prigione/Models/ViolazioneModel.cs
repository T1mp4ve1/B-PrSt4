using System.ComponentModel.DataAnnotations;

namespace Prigione.Models
{
    public class ViolazioneModel
    {
        [Key]
        [Required]
        public int ViolazioneID { get; set; }
        [Required]
        public string Descrizione { get; set; }
    }
}
