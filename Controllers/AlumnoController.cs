using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Maceta_Inteligente.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Maceta_Inteligente.Controllers
{
    public class AlumnoController : Controller
    {
        private MascomacetaContext _context;

        public AlumnoController(MascomacetaContext x) {
            _context = x;
        }
        public  IActionResult Index()
        {
          
               
             AlumnoCollection alumnos;
            var cliente = new HttpClient();
           var task = cliente.GetAsync("https://alumnofunction.azurewebsites.net/api/ListarAlumnos");
            var resultado = task.Result;
         
            var readTask = resultado.Content.ReadAsAsync<AlumnoCollection>();
                readTask.Wait();

                alumnos = readTask.Result;
                
            
            
                
           

            return View(alumnos.Alumnos);
        }


   
        
       
        
         public IActionResult Registrar()
        {

            return View();
        }
        [HttpPost]
        public  IActionResult Registrar(Alumno alumno)
        {
            
           var cliente = new HttpClient();
             var json = JsonConvert.SerializeObject(alumno);
             var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");

             String url="https://alumnofunction.azurewebsites.net/api/RegistrarAlumno";
            var response =  cliente.PostAsync(url, ContentJson);

            var result = response.Result;
            if(result.IsSuccessStatusCode){
                return RedirectToAction("Index");
            }
          return View();
          
        }
        

        public IActionResult AgregarAlumno(Producto p){

            var cliente = new HttpClient();
       
             var json = JsonConvert.SerializeObject(p);
             var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");

             String url="https://macetafunction.azurewebsites.net/api/Eliminar";
            var response =  cliente.PostAsync(url, ContentJson);

            var result = response.Result;            

            return View();
        }
    }
}
