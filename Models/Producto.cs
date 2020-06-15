using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Maceta_Inteligente.Models
{
    public class Producto
    {
        
        [JsonProperty(PropertyName="codigo")]
        public int codigo { get; set; }
           public int ID { get; set; }

        [JsonProperty(PropertyName="fecha")]
        public string fecha { get; set; }

        [JsonProperty(PropertyName="estado")]
        public string estado { get; set; }


        [JsonProperty(PropertyName="humedad")]
        public string humedad{get;set;}
        
        [JsonProperty(PropertyName="temp")]
        public string temp{get;set;}

        [JsonProperty(PropertyName="alumno")]
        public string  AlumnoID {get; set;}

        [JsonProperty(PropertyName="tipoPlanta")]
        public string TipoPlantaID { get; set; }

        
    }
}