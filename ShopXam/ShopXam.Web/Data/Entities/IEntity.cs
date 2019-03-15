using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data.Entities
{
    //TODO:Obligar a las entidades a tener un ID
    public interface IEntity
    {
        int Id { get; set; }
    }
}
