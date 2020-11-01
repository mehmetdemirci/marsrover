using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Abstraction.CommandSplitter
{
    public abstract class CommandSplitterBase<TResult> : ICommandSplitter<TResult>
    {
        public abstract Regex CommandPattern { get; }

        public bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }

        public TResult Split(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                throw new CommandFormatException($"{GetType().Name} {nameof(command)} null or empty.");
            }

            if (this.Match(command) == false)
            {
                throw new CommandFormatException($"{GetType().Name} {nameof(command)} {command} not matched {CommandPattern}");
            }

            return SplitCommand(command);
        }

        protected abstract TResult SplitCommand(string command);
    }
}
