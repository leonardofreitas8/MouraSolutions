using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Motoboy
    {
        [Key]
        public int MotoboyId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        [Display(Name = "Teelefone Fixo")]
        public string TeelefoneFixo { get; set; }
        [Display(Name = "Telefone Celular")]
        public string TeelefoneCelular { get; set; }
        [Display(Name = "Veículo")]
        public string Veiculo { get; set; }
        public string Placa { get; set; }
        [Display(Name = "Data Entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data Saída")]
        public DateTime DataSaida { get; set; }
        public string Status { get; set; }
        public Zona Zona { get; set; }
        public int ZonaId { get; set; }
        public ICollection<Cliente> Clientes { get; set; }




    }
}
