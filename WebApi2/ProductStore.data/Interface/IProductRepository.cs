using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.data.Models;

namespace ProductStore.data.Interface
{
     public interface IProductRepository
    {
        List<Product> getallproducts();
       Product getproductbyid(int id);
    }
}
