namespace Computers
{
    using System.Collections.Generic;

    public class Computer
    {
        private IEnumerable<HardDrive> HardDriver { get; set; }

        private HardDrive VideoCard { get; set; }

        internal void ChargeBattery(int percentage)
        {
            this.battery.Charge(percentage);
            ////BUG FIXED -> % added
            this.VideoCard.Draw(string.Format("Battery status: {0}%", this.battery.Percentage));
        }

        private ICpu Cpu
        {
            get;
            set;
        }

        private readonly LaptopBattery battery;
        private IRam Ram
        {
            get;
            set;
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = Ram.LoadValue();
            if (number != guessNumber)
            {
                VideoCard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                VideoCard.Draw("You win!");
            }
        }

        internal void Process(int data)
        {
            Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }

        internal Computer(ComputerType type, ICpu cpu, IRam ram, IEnumerable<HardDrive> hardDrives, HardDrive videoCard, LaptopBattery battery)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDriver = hardDrives;
            this.VideoCard = videoCard;
            if (type != ComputerType.Laptop && type != ComputerType.PC)
            {
                VideoCard.IsMonochrome = true;
            }

            this.battery = battery;
        }
    }
}
