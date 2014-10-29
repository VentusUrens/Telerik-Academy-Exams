namespace Computers
{
    using System;

    public static class CommandReader
    {
        public static string[] ReadCommandsFor(Computer pc, Computer server, Computer laptop)
        {
            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == null || commandLine.StartsWith("Exit"))
                {
                    System.Environment.Exit(5);
                    return new string[] { "" };
                }

                var commandParams = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParams.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                CommandExecutor.ExecuteCommandsOn(commandParams, pc, server, laptop);
                return commandParams;
            }
        }
    }
}
