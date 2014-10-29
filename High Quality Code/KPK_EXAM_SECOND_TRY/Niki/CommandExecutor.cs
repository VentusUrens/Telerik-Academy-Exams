namespace Computers
{
    public static class CommandExecutor
    {
        public static void ExecuteCommandsOn(string[] commandParams, Computer pc, Computer server, Computer laptop)
        {
            var commandName = commandParams[0];
            var commandArgument = int.Parse(commandParams[1]);

            if (commandName == "Charge")
            {
                laptop.ChargeBattery(commandArgument);
            }
            else if (commandName == "Process")
            {
                server.Process(commandArgument);
            }
            else if (commandName == "Play")
            {
                pc.Play(commandArgument);
            }
        }
    }
}
