namespace Computers
{
    public class LaptopBattery : ILaptopBattery
    {
        internal int Percentage { get; set; }
        public void Charge(int p)
        {
            Percentage += p;
            if (Percentage > 100) 
            { 
                Percentage = 100; 
            }

            if (Percentage < 0) 
            { 
                Percentage = 0; 
            }
        }

        internal LaptopBattery()
        {
            this.Percentage = 100 / 2;
        }
    }
}
