using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class StatusPedido
    {
        [Key]
        public int IdStatus { get; set; }
        public string Status { get; set; }
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        public ICollection<Pedido> pedidosStatus { get; set; }
    }
}
