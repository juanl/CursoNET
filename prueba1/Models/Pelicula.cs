using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace prueba1.Models
{
    public class Pelicula
    {
        [Required]
        public string Nombre { get; set; }
        public int Id { get; set; }

        [Required]
        public string Genero { get; set; }

        [Display(Name = "Año de lanzamiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-YYY}", ApplyFormatInEditMode = true)]
        public DateTime AnioLanzamiento { get; set; }

        [EmailAddress]
        public string direccioncorreo { get; set; }
    }

    public class PeliculaDBContext : DbContext
    {
        public DbSet<Pelicula> Peliculas { get; set; }
    }

}