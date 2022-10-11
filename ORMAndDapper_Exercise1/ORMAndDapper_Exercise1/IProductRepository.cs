using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMAndDapper_Exercise1
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();



    }
}
