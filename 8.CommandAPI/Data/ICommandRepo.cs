using CommandAPI.Models;

namespace CommandAPI.Data
{
    public interface ICommandRepo
    {
        Task SaveChangesAsync();
        Task<Command?> GetCommandByIdAsync(string commandId);
        Task<IEnumerable<Command?>?> GetAllCommandsAsync();
        Task CreateCommandAsync(Command cmd);
        Task UpdateCommandAsync(Command cmd);
        void DeleteCommand(Command cmd);
    }
}