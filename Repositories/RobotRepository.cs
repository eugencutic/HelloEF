using EfConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Repositories
{
    public class RobotRepository : IRepo<Robot>
    {
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Robot>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(Robot arg)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Robot arg, int id)
        {
            throw new NotImplementedException();
        }
    }
}
