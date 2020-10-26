using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Pedido
    {
        [Key]
        [Display(Name = " Número do Pedido")]
        public int Id { get; set; }

        [Display(Name = "Cliente Cadastrado")]
        public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data criação do Pedido")]
        public DateTime DataPedidoRetirada { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Horário do Pedido")]
        public DateTime HorarioPedido { get; set; }

        [Display(Name = "Autor do pedido")]
        public string NomeSolicitante { get; set; }

        [Display(Name = "Data para Retirada")]
        public DateTime DataRetirada { get; set; }

        [Display(Name = "Data para Entrega")]
        public DateTime DataEntrega { get; set; }

        //Lista de Pacientes
        public List<Paciente> Pacientes { get; set; }

        [Display(Name = "Status Pedido")]
        public int statusPedidoId { get; set; }
        public StatusPedido statusPedido { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "Observações importantes")]
        public string Obsercao { get; set; }

        [Display(Name = "Zona")]
        public int ZonaId { get; set; }
        public Zona Zona { get; set; }

        public Pedido()
        {
            Pacientes = new List<Paciente>();

        }


    }
}
