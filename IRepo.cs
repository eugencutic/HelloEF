using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2
{
    public interface IRepo<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task PostAsync(T arg);
        Task UpdateAsync(T arg, int id);
        Task DeleteAsync(int id);
    }
}
