using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopXam.Web.Data.Entities.Country
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
