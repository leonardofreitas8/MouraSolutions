using System;
using System.ComponentModel.DataAnnotations;

namespace MouraSolutionsWeb.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        [Display(Name = "Tipo do Endereço")]
        public string Tipo_Endereco { get; set; }
        [Display(Name = "Rua")]
        public string Rua { get; set; }
        [Display(Name = "Número")]
        public int Numero { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }
        [Display(Name = "Zona/Setor")]
        public string Zona_Setor { get; set; }
        public string UF { get; set; }
        [Display(Name = "Nome para Contato")]
        public string Nome_Contato { get; set; }
        [Display(Name = "Telefone Comercial")]
        public string Telefone_Comercial { get; set; }
        [Display(Name = "Telefone Celular")]
        public string Telefone_Celular { get; set; }
        [Display(Name = "Telefone Recado")]
        public string Telefone_Recado { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        [Display(Name = "Observações importantes")]
        public string Obs { get; set; }
        [Display(Name = "Data Registro")]
        public DateTime Data_Registro { get; set; }

        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }


    }
}
