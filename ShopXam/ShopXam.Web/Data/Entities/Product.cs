using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo debe tener {1} Caracteres o menos")]
        [Required]
        public string Nombre { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Ultima Compra")]
        public DateTime? UltimaCompra { get; set; }

        [Display(Name = "Ultima Venta")]
        public DateTime? UltimaVenta { get; set; }

        [Display(Name = "Disponible?")]
        public bool Disponible { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User user { get; set; }
        //public string ImageFullPath
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(this.ImageUrl))
        //        {
        //            return null;
        //        }
        //        return $"";
        //    }
        //}
    }
}
