using Castle.Core.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EfConsoleApp2.Caching
{
    class RedisConnector
    {
        public static ILogger Logger { get; set; }

        public static IDatabase Database => ConnectionMultiplexer.GetDatabase();

        public static IServer Server => ConnectionMultiplexer.GetServer(GetEndpoint());

        public static ConnectionMultiplexer ConnectionMultiplexer => LazyCacheConnection.Value;

        private static readonly Lazy<ConnectionMultiplexer> LazyCacheConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var redisConnection = ConnectionMultiplexer.Connect(GetConfiguration());

            redisConnection.ConnectionFailed += (sender, args) =>
            {
                Logger.Error($"Redis Connection failed: {args.FailureType}, {args.Exception}");
            };

            redisConnection.ConnectionRestored += (sender, args) =>
            {
                Logger.Info("Redis Connection restored");
            };

            redisConnection.InternalError += (sender, args) =>
            {
                Logger.Error($"Redis Internal error: {args.Exception}, args.Origin");
            };

            redisConnection.ErrorMessage += (sender, args) =>
            {
                Logger.Error($"Redis error {args.Message}");
            };

            return redisConnection;
        });

        private static ConfigurationOptions GetConfiguration()
        {
            var config = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                Password = RedisSettings.Password
            };

            config.EndPoints.Add(GetEndpoint());

            return config;
        }

        private static EndPoint GetEndpoint()
        {
            return new DnsEndPoint(RedisSettings.Server, RedisSettings.Port);
        }
    }
}
