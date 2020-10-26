using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Zona
    {
        [Key]
        public int IdZona { get; set; }
        public string ZonaNome { get; set; }
        public string BairrosAtendidos { get; set; }
        public int FaixaCeps { get; set; }


        public ICollection<Motoboy> Motoboys { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
