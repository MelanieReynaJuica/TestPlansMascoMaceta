using System.Collections.Generic;
using Newtonsoft.Json;
namespace Maceta_Inteligente.Models
{
  
    public class ProductoCollection
    {
        List<Producto> productos;

        public List<Producto> Productos { get => productos; set => productos = value; }
    }
}