using System;
using Newtonsoft.Json;

namespace Maceta_Inteligente.Models
{
    public class Alumno
    {
        [JsonProperty (PropertyName="id")]
        public int id{ get; set; }

        [JsonProperty (PropertyName="nombre")]
        public string nombre { get; set; }

        [JsonProperty (PropertyName="apePat")]
        public string apePat { get; set; }

        [JsonProperty (PropertyName="apeMat")]
        public string apeMat { get; set; }

        [JsonProperty (PropertyName="fecNac")]
        public DateTime fecNac { get; set; }

        [JsonProperty (PropertyName="correo")]
        public string correo { get; set; }

        [JsonProperty (PropertyName="contrasena")]
        public string contrasena { get; set; }

        [JsonProperty (PropertyName="telefono")]
        public int telefono{ get; set; }            
    }
}