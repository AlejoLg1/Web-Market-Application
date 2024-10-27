using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProveedorProducto
    {
        public int IdProveedorProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}
