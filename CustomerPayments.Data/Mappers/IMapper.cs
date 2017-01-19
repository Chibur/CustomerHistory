using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomerPayments.Data.Mappers
{
    public interface IMapper<T, K> where T: class where K: class
    {
        T Map(K m);
        K Map(T m);
    }
}
