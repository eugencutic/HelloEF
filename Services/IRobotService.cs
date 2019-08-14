using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Services
{
    interface IRobotService
    {
        Task CreateRobotAsync(string name);
    }
}
