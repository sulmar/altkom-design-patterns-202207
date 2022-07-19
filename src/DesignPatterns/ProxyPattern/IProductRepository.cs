using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    // Subject
    public interface IProductRepository
    {
        Product Get(int id);
        void Add(Product product);
    }
}
