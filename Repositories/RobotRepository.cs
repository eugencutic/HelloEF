using EfConsoleApp2.Caching;
using EfConsoleApp2.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EfConsoleApp2.Repositories
{
    public class RobotRepository : IRepo<Robot>
    {
        private const string RobotCacheKey = "robot";

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Robot> GetByIdAsync(int id)
        {
            var cachedValue = await RedisConnector.Database.HashGetAsync(RobotCacheKey, id);

            if (cachedValue != default)
            {
                var cachedRobot = JsonConvert.DeserializeObject<Robot>(cachedValue);
                return await Task.FromResult(cachedRobot);
            }
            
            using (var db = new Context())
            {
                var robot = db.Robots.FirstOrDefault(r => r.Id == id);
                if (robot == default)
                    return default;

                var settings = new JsonSerializerSettings();
                settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                await RedisConnector.Database.HashSetAsync(RobotCacheKey, new HashEntry[]
                {
                    new HashEntry(id, JsonConvert.SerializeObject(robot, settings))
                });

                Console.WriteLine($"Got robot {robot.Name} from db.");

                return await Task.FromResult(robot);
            }
        }

        public async Task<IEnumerable<Robot>> GetAllAsync()
        {
            using (var db = new Context())
            {
                return await Task.FromResult(new List<Robot>(db.Robots));
            }
        }

        public async Task PostAsync(Robot arg)
        {
            using (var db = new Context())
            {
                db.Robots.Add(arg);
                await db.SaveChangesAsync();
            }
        }

        public Task UpdateAsync(Robot arg, int id)
        {
            throw new NotImplementedException();
        }
    }
}
