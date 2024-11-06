using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Venta
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public DateTime FechaVenta { get; set; }

        public string NumeroFactura { get; set; }
        public bool Estado { get; set; }
    }
}
