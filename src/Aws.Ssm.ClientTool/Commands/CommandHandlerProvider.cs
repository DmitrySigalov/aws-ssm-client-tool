using Aws.Ssm.ClientTool.Commands.Handlers;

namespace Aws.Ssm.ClientTool.Commands;

public class CommandHandlerProvider
{
    private readonly HelpCommandHandler _helpCommandHandler;

    public CommandHandlerProvider(IEnumerable<ICommandHandler> handlers)
    {
        handlers = handlers.ToArray();
        
        _helpCommandHandler = new HelpCommandHandler(handlers);
        
        All = new [] { _helpCommandHandler } 
            .Union(handlers)
            .ToDictionary(h => h.Name, h => h);
    }
    
    public IDictionary<string, ICommandHandler> All { get; }

    public ICommandHandler Get(string? commandName)
    {
        if (string.IsNullOrEmpty(commandName))
        {
            Console.WriteLine("Set command argument");
            
            return _helpCommandHandler;
        }

        if (!All.TryGetValue(commandName, out var handler))
        {
            Console.WriteLine("Invalid command argument");
            
            return _helpCommandHandler;
        }

        return handler;
    }
}