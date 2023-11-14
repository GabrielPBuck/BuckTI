using System.ComponentModel.DataAnnotations;

namespace BuckTI.Models
{
    public class InventarioMaquinasModel
    {
        [Key]
        public int IdMaquina { get; set; }
        public int IdCliente { get; set; }
        public int IdSoftware { get; set; }
        public int IdSetor { get; set; }
        public string TipoMaquina { get; set; }
        public string NumeroMaquina { get; set; }
        public string StatusMaquina { get; set; }
        public string DescricaoMaquina { get; set; }

        public List<CadClientes> ListaClientes { get; set; }
        public List<CadSetores> ListaSetores { get; set; }
        public List<CadSoftwares> ListaSoftwares { get; set; }        
    }
}
