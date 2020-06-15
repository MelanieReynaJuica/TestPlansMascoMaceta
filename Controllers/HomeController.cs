using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Maceta_Inteligente.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace Maceta_Inteligente.Controllers
{
    public class HomeController : Controller
    {

        private MascomacetaContext _context;

        

        public HomeController(MascomacetaContext x) {
            _context = x;
        }

        public IActionResult Index(){
            return View();

        }

        [HttpPost]
         public IActionResult Index( Usuarios usuario){

            


           var cliente = new HttpClient();
             var json = JsonConvert.SerializeObject(usuario);
             var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");

             String url="https://alumnofunction.azurewebsites.net/api/Function1";
            var task =  cliente.PostAsync(url, ContentJson);
               
             var resultado = task.Result;
         
            var readTask =  resultado.Content.ReadAsAsync<Usuarios>();
          

                Usuarios userConfirm = readTask.Result;

           if(userConfirm!=null){
                  return RedirectToAction("Inicio");
            }else{
            ViewBag.msg= "Usuario o contraseña incorrecta";
            }       
            return View(); 
        
        }

      /*  [HttpPost]
        public IActionResult Index(string correo, string contraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.correo.Equals(correo) && u.contraseña.Equals(contraseña));
                if(usuario!=null){
                    return RedirectToAction("Inicio");
                }else{
                    return RedirectToAction("Index");
                }
                
        }

        [HttpPost]  
        
        public ActionResult Index(string correo,string contrasena)   
        {  
            
                 var usuario = _context.Usuarios.FirstOrDefault(u => u.correo==correo && u.contrasena == contrasena);
                if(usuario!=null){
                    ViewBag.nombre= usuario.nombre;
                    return RedirectToAction("Inicio");
                }
                    ViewBag.msg= "Usuario o contraseña incorrecta";
                    return View();
                
           
        }  

        */

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
