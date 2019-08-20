using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EfConsoleApp2.Caching;
using EfConsoleApp2.Models;
using EfConsoleApp2.Repositories;
using EfConsoleApp2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<IRepo<Robot>>().ImplementedBy<RobotRepository>().LifestyleTransient(),
                Component.For<IRobotService>().ImplementedBy<RobotService>().LifestyleTransient());

            var robotService = container.Resolve<IRobotService>();

            var robot = await robotService.GetByIdAsync(3);

            Console.WriteLine($"Got robot {robot.Name}");
            Console.ReadKey();
        }
    }
}
