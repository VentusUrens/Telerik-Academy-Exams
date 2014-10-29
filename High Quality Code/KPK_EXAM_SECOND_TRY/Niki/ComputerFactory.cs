namespace Computers
{
    using System.Collections.Generic;
    using Computers.Exceptions;

    public static class ComputerFactory
    {
        public static Computer ManufacturePCFrom(string manufacturer)
        {
            if (manufacturer == "Dell")
            {
                // MANUFACTURING DELL PC BELOW
                var dellPcType = ComputerType.PC;
                var dellPcRam = new Ram(ComputerComponentsInformation.DELL_PC_RAM);
                var dellPcVideoCard = new HardDrive() { IsMonochrome = false };
                var dellPcCpu = new Cpu(ComputerComponentsInformation.DELL_PC_CPU_NUMBER_OF_CORES,
                                        ComputerComponentsInformation.DELL_PC_BITS, dellPcRam, dellPcVideoCard);
                var dellPcHardDrives = new[] { new HardDrive(ComputerComponentsInformation.DELL_PC_HARD_DRIVE_CAPACITY, false, 0) };

                return new Computer(dellPcType, dellPcCpu, dellPcRam, dellPcHardDrives, dellPcVideoCard, null);
            }
            else if (manufacturer == "HP")
            {
                // MANUFACTURING HP PC BELOW
                var pcType = ComputerType.PC;
                var pcRam = new Ram(ComputerComponentsInformation.HP_PC_RAM);
                var pcVideoCard = new HardDrive() { IsMonochrome = false };
                var pcCpu = new Cpu(ComputerComponentsInformation.HP_PC_CPU_NUMBER_OF_CORES,
                                    ComputerComponentsInformation.HP_PC_BITS, pcRam, pcVideoCard);
                var pcHardDrives = new[] { new HardDrive(ComputerComponentsInformation.HP_PC_HARD_DRIVE_CAPACITY, false, 0) };

                return new Computer(pcType, pcCpu, pcRam, pcHardDrives, pcVideoCard, null);
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }

        public static Computer ManufactureLaptopFrom(string manufacturer)
        {
            if (manufacturer == "Dell")
            {
                // MANUFACTURING DELL LAPTOP BELOW
                var laptopType = ComputerType.Laptop;
                var laptopRam = new Ram(ComputerComponentsInformation.DELL_LAPTOP_RAM);
                var laptopVideoCard = new HardDrive() { IsMonochrome = false };
                var laptopCpu = new Cpu(ComputerComponentsInformation.DELL_LAPTOP_CPU_NUMBER_OF_CORES,
                                        ComputerComponentsInformation.DELL_LAPTOP_BITS, laptopRam, laptopVideoCard);
                var laptopHardDrives = new[] { new HardDrive(ComputerComponentsInformation.DELL_LAPTOP_HARD_DRIVE_CAPACITY, false, 0) };
                return new Computer(laptopType, laptopCpu, laptopRam, laptopHardDrives, laptopVideoCard, new LaptopBattery());
            }
            else if (manufacturer == "HP")
            {
                // MANUFACTURING HP LAPTOP BELOW
                var laptopType = ComputerType.Laptop;
                var laptopRam = new Ram(ComputerComponentsInformation.HP_LAPTOP_RAM);
                var laptopVideoCard = new HardDrive() { IsMonochrome = false };
                var laptopCpu = new Cpu(ComputerComponentsInformation.HP_LAPTOP_CPU_NUMBER_OF_CORES,
                                        ComputerComponentsInformation.HP_LAPTOP_BITS, laptopRam, laptopVideoCard);
                var laptopHardDrives = new[] { new HardDrive(ComputerComponentsInformation.HP_LAPTOP_HARD_DRIVE_CAPACITY, false, 0) };
                return new Computer(laptopType, laptopCpu, laptopRam, laptopHardDrives, laptopVideoCard, new LaptopBattery());
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }

        public static Computer ManufactureServerFrom(string manufacturer)
        {
            if (manufacturer == "Dell")
            {
                // MANUFACTURING DELL Server BELOW
                var dellServerType = ComputerType.Server;
                var dellServerRam = new Ram(ComputerComponentsInformation.DELL_SERVER_RAM);
                var dellServerVideoCard = new HardDrive();
                var dellServerCpu = new Cpu(ComputerComponentsInformation.DELL_SERVER_CPU_NUMBER_OF_CORES,
                                            ComputerComponentsInformation.DELL_SERVER_BITS, dellServerRam, dellServerVideoCard);
                var dellServerHardDrives = new List<HardDrive> 
                {
                    new HardDrive(0, true, 2, new List<HardDrive> 
                                                               { 
                                                                 new HardDrive(ComputerComponentsInformation.DELL_SERVER_HARD_DRIVE_CAPACITY, false, 0),
                                                                 new HardDrive(ComputerComponentsInformation.DELL_SERVER_HARD_DRIVE_CAPACITY, false, 0) 
                                                               }) 
                };
                return new Computer(dellServerType, dellServerCpu, dellServerRam, dellServerHardDrives, dellServerVideoCard, null);
            }
            else if (manufacturer == "HP")
            {
                // MANUFACTURING HP SERVER BELOW
                var serverType = ComputerType.Server;
                var serverRam = new Ram(ComputerComponentsInformation.HP_SERVER_RAM);
                var serverVideoCard = new HardDrive();
                var serverCpu = new Cpu(ComputerComponentsInformation.HP_SERVER_CPU_NUMBER_OF_CORES,
                                        ComputerComponentsInformation.HP_SERVER_BITS, serverRam, serverVideoCard);
                var serverHardDrives = new List<HardDrive>
                                {
                                    new HardDrive(0, true, 2, new List<HardDrive> 
                                    {
                                        new HardDrive(ComputerComponentsInformation.HP_SERVER_HARD_DRIVE_CAPACITY, false, 0),
                                        new HardDrive(ComputerComponentsInformation.HP_SERVER_HARD_DRIVE_CAPACITY, false, 0)
                                    })
                                };

                return new Computer(serverType, serverCpu, serverRam, serverHardDrives, serverVideoCard, null);
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}
