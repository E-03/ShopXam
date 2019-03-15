using ShopXam.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data.Entities.Country
{
    public class Country : IEntity
    {
        public int Id { get ; set ; }
        public string Nombre { get; set; }
    }
}
