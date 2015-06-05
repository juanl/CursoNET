using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prueba1.Models
{
    public enum Provincias
    {
        CABA = 1,
        [Display(Name = "Santa Fe")]
        SantaFe = 2,
        Tucuman = 23,
    }

}