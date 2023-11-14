using System.ComponentModel.DataAnnotations;

namespace BuckTI.Models
{
    public class CadClientes
    {
        [Key]
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SobrenomeCliente { get; set; }
        public string CPFCliente { get; set; }
        public string TelefoneCliente { get; set; }
    }
}
