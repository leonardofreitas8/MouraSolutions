using MouraSolutionsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MouraSolutionsWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MouraExpressContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Material.Any())
            {
                return;   // DB has been seeded
            }

            var material = new Material[]
            {
            new Material { Descricao="Teste novo material"}
            };
            foreach (Material m in material)
            {
                context.Material.Add(m);
            }
        }
    }
}
