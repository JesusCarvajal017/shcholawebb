using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.interfaces.crud
{
    public interface IQueryAll<T>
    {
        Task<IEnumerable<T>> QueryAllAsyn(); 
    }
}
