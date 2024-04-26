using System.Collections.Generic;

public class EventQueue
{
    private Stack<ICommand> commands;

    public EventQueue() 
    {
        commands = new Stack<ICommand>();
    }

    public void QueueCommand(ICommand command)
    {
        command.Execute();
        commands.Push(command);
    }
}
