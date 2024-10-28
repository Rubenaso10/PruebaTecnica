using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParteTres.Models
{
    public class Orden { 
        public int OrdenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        //para indicar que es llave foranea 
        public int ClienteId { get; set; }

        //para navegar a traves de la relacion
        public Cliente Cliente { get; set; }
    }
}
