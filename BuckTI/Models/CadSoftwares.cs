using System.ComponentModel.DataAnnotations;

namespace BuckTI.Models
{
    public class CadSoftwares
    {
        [Key]
        public int IdSoftware { get; set; }
        public string NomeSoftware { get; set; }
        public string VersaoSoftware { get; set; }
        public string ValidadeSoftware { get; set; }
    }
}
