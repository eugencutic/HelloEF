using EfConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Services
{
    public class RobotService : IRobotService
    {
        private IRepo<Robot> _robotRepository;

        public RobotService(IRepo<Robot> robotRepository)
        {
            _robotRepository = robotRepository;
        }

        public async Task CreateRobotAsync(string name)
        {
            var robot = new Robot { Name = name };
            await _robotRepository.PostAsync(robot);
        }
    }
}
