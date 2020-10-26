using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Display(Name = "Data do Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Perfil do Cliente")]
        public string PerfilCliente { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }

        [Display(Name = "Motoboy Assignado")]
        public int MotoboyId { get; set; }
        public Motoboy Motoboy { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
    }
}
