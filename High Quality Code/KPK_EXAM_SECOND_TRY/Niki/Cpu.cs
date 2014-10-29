namespace Computers
{
    using System;
    public class Cpu : ICpu
    {
        private static readonly Random Random = new Random();

        private readonly byte numberOfBits;

        private readonly Ram ram;

        private readonly HardDrive videoCard;


        internal Cpu(byte numberOfCores, byte numberOfBits, Ram ram, HardDrive videoCard)
        {
            this.numberOfBits = numberOfBits;
            this.ram = ram;
            this.NumberOfCores = numberOfCores;
            ////BUG FIXED -> VIDEOCARD ADDED BELOW
            this.videoCard = videoCard;
        }

        private byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            if (this.numberOfBits == 32)
            {
                SquareNumber32();
            }

            if (this.numberOfBits == 64)
            {
                SquareNumber64();
            }
        }

        public void SquareNumber32()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 500)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public void SquareNumber64()
        {
            var data = this.ram.LoadValue();
            if (data < 0)
            {
                this.videoCard.Draw("Number too low.");
            }
            else if (data > 1000)
            {
                this.videoCard.Draw("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.videoCard.Draw(string.Format("Square of {0} is {1}.", data, value));
            }
        }

        public void Rand(int a, int b)
        {
            int randomNumber;
            do
            {
                randomNumber = Random.Next(0, 1000);
            }
            while (!(randomNumber >= a && randomNumber <= b));
            this.ram.SaveValue(randomNumber);
        }
    }
    //// BUG FIXED-> SECOND MAIN METHOD
}
