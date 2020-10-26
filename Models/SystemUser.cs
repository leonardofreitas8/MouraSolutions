using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MouraSolutionsWeb.Models
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

    }
}
