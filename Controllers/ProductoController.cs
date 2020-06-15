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
    public class ProductoController : Controller
    {
        private MascomacetaContext _context;
         public ProductoController(MascomacetaContext x) {
            _context = x;
        }

        public IActionResult Index(){


              ProductoCollection productos;
            var cliente = new HttpClient();
           var task = cliente.GetAsync("https://macetafunction.azurewebsites.net/api/ListarMaceta");
            var resultado = task.Result;
         
            var readTask = resultado.Content.ReadAsAsync<ProductoCollection>();
                readTask.Wait();

                productos = readTask.Result;
                
                
            
            
            return View(productos.Productos);
      }


    


        [HttpPost]
        public IActionResult Registrar(Producto prod)
        {
            

            var cliente = new HttpClient();
             var json = JsonConvert.SerializeObject(prod);
             var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");

             String url="https://macetafunction.azurewebsites.net/api/RegistrarMaceta";
            var response =  cliente.PostAsync(url, ContentJson);

            var result = response.Result;
            if(result.IsSuccessStatusCode){
                return RedirectToAction("Inicio");
            }
          return View();
            
        }

    public IActionResult Registrar(){

         
        return View();
    }
        
        public ActionResult Delete(int codigo )
    {
        var cliente = new HttpClient();
        Producto p=new Producto();
        p.codigo=codigo;
     
             var json = JsonConvert.SerializeObject(p);
             var ContentJson = new StringContent(json, Encoding.UTF8, "application/json");

             String url="https://macetafunction.azurewebsites.net/api/Eliminar";
            var response =  cliente.PostAsync(url, ContentJson);

            var result = response.Result;
           

        return RedirectToAction("Index");
    }

    


    }
}