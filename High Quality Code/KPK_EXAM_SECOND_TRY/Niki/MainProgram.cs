namespace Computers
{
    using System;
    public class MainProgram
    {
        private static Computer pc, laptop, server;

        public static void Main()
        {
            var manufacturer = Console.ReadLine();

            pc = ComputerFactory.ManufacturePCFrom(manufacturer);
            laptop = ComputerFactory.ManufactureLaptopFrom(manufacturer);
            server = ComputerFactory.ManufactureServerFrom(manufacturer);
            while (true)
            {
                CommandReader.ReadCommandsFor(pc, server, laptop);
            }
        }
    }
}
