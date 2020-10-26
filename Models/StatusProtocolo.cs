using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class StatusProtocolo
    {
        [Key]
        public int IdStatus { get; set; }
        public string Status { get; set; }
        [Display(Name = "Descrição do Status")]
        public string Descricao { get; set; }
        public ICollection<Paciente> pacienteStatus { get; set; }
    }
}
