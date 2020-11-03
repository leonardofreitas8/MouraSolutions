using System.Collections.Generic;

namespace MouraSolutionsWeb.Models.MouraViewModels
{
    public class ClienteIndexData
    {
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Pedido> Pedidos { get; set; }
        public IEnumerable<Paciente> Pacientes { get; set; }
    }
}
