using System.ComponentModel.DataAnnotations;

namespace BuckTI.Models
{
    public class CadSetores
    {
        [Key]
        public int IdSetor { get; set; }
        public string NomeSetor { get; set; }
        public string ResponsavelSetor { get; set; }
    }
}
