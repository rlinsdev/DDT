using System.Text.Json;
using CommandAPI.Data;
using CommandAPI.Models;
using StackExchange.Redis;

namespace CommandApi.Data
{
    public class RedisCommandRepo : ICommandRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisCommandRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        public async Task CreateCommandAsync(Command cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException(nameof(cmd));
            
            var db = _redis.GetDatabase();

            var serialCommand = JsonSerializer.Serialize(cmd);

            await db.HashSetAsync($"commands", new HashEntry[] {new HashEntry(cmd.CommandId, serialCommand)});
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Command?>?> GetAllCommandsAsync()
        {
            var db = _redis.GetDatabase();

            var completeSet = await db.HashGetAllAsync("commands");
            if (completeSet.Length > 0)
            {
                return Array.ConvertAll(completeSet, val => JsonSerializer.Deserialize<Command>(val.Value));
            }

            return new List<Command>();
        }

        public Task<Command?> GetCommandByIdAsync(string commandId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            Console.WriteLine("--> Save Changes");
            await Task.CompletedTask;
        }
    }
}