using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public delegate bool HandleResultDelegate(ECommandResult result);

public class SequenceCommand : BaseCommand
{
    Queue<BaseCommand> m_CommandQueue = new Queue<BaseCommand>();
    private HandleResultDelegate m_ResultHandler;

    public SequenceCommand AppendCommand(BaseCommand command)
    {
        m_CommandQueue.Enqueue(command);
        return this;
    }

    public SequenceCommand AppendResultHandler(HandleResultDelegate handler)
    {
        m_ResultHandler = handler;
        return this;
    }

    public override ECommandResult Execute()
    {
        while (m_CommandQueue.Count > 0)
        {
            var command = m_CommandQueue.Dequeue();
            var result = command.Execute();
            if (result != ECommandResult.Success)
            {
                return result;
            }
        }
        return ECommandResult.Success;
    }

    public override bool HandleResult(ECommandResult result)
    {
        if (m_ResultHandler != null)
        {
            return m_ResultHandler.Invoke(result);
        }

        return false;
    }
}
