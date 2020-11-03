using System;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models.MouraViewModels
{
    public class GrupoPedidosPorData
    {
        //[DataType(DataType.Date)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PedidosCriacao { get; set; }
        public int QtdPedidos { get; set; }
        public int QtdPacientes { get; set; }
    }
}
