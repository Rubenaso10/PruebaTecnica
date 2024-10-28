using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParteTres.Models
{
    public class Cliente { 
        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        // para indicarle a Entity Framework que la propiedad Ordenes es una relación uno a muchos
        public ICollection<Orden> Ordenes { get; set; }
    }
}
