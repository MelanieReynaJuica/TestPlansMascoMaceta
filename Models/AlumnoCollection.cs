using System.Collections.Generic;

namespace Maceta_Inteligente.Models
{
    public class AlumnoCollection
    {
        
        List<Alumno> alumnos;

        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
    }
}