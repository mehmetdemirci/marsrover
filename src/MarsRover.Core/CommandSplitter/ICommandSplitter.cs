using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Abstraction.CommandSplitter
{
    public interface ICommandSplitter<TResult>
    {
        TResult Split(string command);
    }
}
