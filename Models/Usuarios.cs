   using Newtonsoft.Json;
namespace Maceta_Inteligente.Models
{
    public class Usuarios
    {


        public Usuarios() { }
    
   
   
        
        [JsonProperty(PropertyName="id")]
        public string ID { get; set; }


        [JsonProperty(PropertyName="correo")]
        public string correo { get; set; }


        [JsonProperty(PropertyName="contrasena")]
        public string contrasena { get; set; }

        

    }
    
}