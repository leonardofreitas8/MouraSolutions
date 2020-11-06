using System;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Paciente
    {
        [Key]
        [Display(Name = "Id Paciente")]
        public int IdPaciente { get; set; }
        [Display(Name = "Nome do Paciente")]
        public string NomePaciente { get; set; }

        [Display(Name = "Número do Protocolo")]
        public string Protocolo { get; set; }

        [Display(Name = "Validação Motoboy")]
        public string ConfMoto { get; set; }

        [Display(Name = "Validação Clínica")]
        public string ConfClinica { get; set; }

        [Display(Name = "Validação Final")]
        public string ConfEscritorio { get; set; }

        public DateTime Tma { get; set; }
        public DateTime DataCheckLab { get; set; }

        [Display(Name = "Observação")]
        public string Obs { get; set; }

        [Display(Name = "Status Protocolo")]
        public int statusProtocolo { get; set; }
        public StatusProtocolo Status { get; set; }

        public int PedidoId { get; set; }
        public Pedido pedido { get; set; }
    }
}
