using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityGameFramework.Runtime;

public class CommandComponent : GameFrameworkComponent
{
    List<BaseCommand> m_CommandList = new List<BaseCommand>();
    public ICommandResultHandler DefaultResultHandler { get; set; }

    public SequenceCommand Sequence()
    {
        var command = new SequenceCommand();
        m_CommandList.Add(command);
        return command;
    }

    private void Start()
    {
        DefaultResultHandler = new DefaultResultHandler();
    }

    private void Update()
    {
        if (m_CommandList.Count <= 0)
        {
            return;
        }

        List<BaseCommand> waitingList = new List<BaseCommand>();
        foreach (var command in m_CommandList)
        {
            var result = command.Execute();
            if (result == ECommandResult.Waiting)
            {
                waitingList.Add(command);
            }
            else
            {
                var hasHandled = command.HandleResult(result);
                if (!hasHandled)
                {
                    if (DefaultResultHandler != null)
                    {
                        DefaultResultHandler.HandleResult(result);
                    }
                    Log.Info(result);
                }
            }
        }
        m_CommandList.Clear();
        m_CommandList = waitingList;
    }
}
