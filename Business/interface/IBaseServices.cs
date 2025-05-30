using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBaseServices<Dto>
    {
        Task<IEnumerable<Dto>> GetAllAsync();
        Task<Dto> GetByIdAsync(int id);
        Task<Dto> CreateAsync(Dto entityDto);
        Task<Object> UpdateAsync(Dto dto);


    }
}
