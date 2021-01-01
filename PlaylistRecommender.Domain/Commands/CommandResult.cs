using PlaylistRecommender.Domain.Core;

namespace PlaylistRecommender.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }

    }
}