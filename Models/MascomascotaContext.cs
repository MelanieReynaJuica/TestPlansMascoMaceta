
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Maceta_Inteligente.Models;
public class MascomacetaContext: DbContext
    {
        public DbSet<Alumno> Alumno {get;set;}

        public DbSet<Producto> Producto {get;set;}

      //   public DbSet<Usuario> Usuario {get;set;}

        public DbSet<TipoPlanta> TipoPlanta {get;set;}
        
       
        public MascomacetaContext(DbContextOptions<MascomacetaContext> options): base(options){

        } 

    }