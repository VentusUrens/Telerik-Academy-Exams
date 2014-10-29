namespace Cars.Importer
{
    using Cars.Data;
    using Newtonsoft.Json;
    using Cars.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Cars.Importer;
    using System.Globalization;

    public class Program
    {
        private static CarsDBContext db = new CarsDBContext();
        public static void LoadJson(string filePath)
        {
            var template = new
            {
                Year = "",
                TransmissionType = "",
                ManufacturerName = "",
                Model = "",
                Price = "",
                Dealer = new
                {
                    Name = "",
                    City = ""
                }
            };

            using (StreamReader r = new StreamReader(filePath))
            {
                string completeJson = r.ReadToEnd();
                List<string> separatedJsonStrings = new List<string>();
                completeJson = completeJson.Substring(1, completeJson.Length - 2);
                var partialJasons = completeJson.Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries);

                dynamic year = "";
                string transmission = "";
                string manufacturerName = "";
                string model = "";
                string price = "";
                dynamic dealer;

                foreach (var partialJson in partialJasons)
                {
                    dynamic car;
                    if (!partialJson.StartsWith("{"))
                    {

                        car = JsonConvert.DeserializeAnonymousType("{" + partialJson, template);
                    }
                    else
                    {
                        car = JsonConvert.DeserializeAnonymousType(partialJson, template);
                    }
                    year = car.Year;
                    transmission = car.TransmissionType;
                    manufacturerName = car.ManufacturerName;
                    model = car.Model;
                    price = car.Price;
                    dealer = car.Dealer;

                    Car carObject = new Car()
                    {
                        Year = 2000,
                        TransmissionType = Convert.ToInt32(transmission) == 0 ? TransmissionTypes.Manual : TransmissionTypes.Automatic,
                        Manufacturer = new Manufacturer()
                        {
                            Name = manufacturerName
                        },
                        Model = Convert.ToString(model),
                        Price = Convert.ToInt32(price),
                        Dealer = new Dealer()
                        {
                            Name = "MMCars",
                            Cities = new List<City>(){
                                new City(){
                                    Name = "Sofia",
                                }
                            }
                        }
                    };
                    db.Cars.Add(carObject);
                    db.SaveChanges();
                    Console.WriteLine(JsonConvert.SerializeObject(carObject, Formatting.Indented));
                }
            }
        }
        public class CarsList
        {
            public List<CarsInfo> CarList { get; set; }
        }
        public class CarsInfo
        {
            public int Year { get; set; }
            public TransmissionTypes Transmission { get; set; }

            public string ManufacturerName { get; set; }
            public string Model { get; set; }
            public double Price { get; set; }

            public List<Dealer> Dealer { get; set; }
        }

        public static void Main()
        {
            Console.WriteLine("======================================================================");
            Console.WriteLine("======================================================================");
            Console.WriteLine("==============PLEASE USE ONLY f5 FOR TESTING THE PROJECT!=============");
            Console.WriteLine("==========================NOT CTRL + f5===============================");
            Console.WriteLine("==================Thank you for your understanding.===================");
            Console.WriteLine("======================================================================");
            Console.WriteLine("==============CHECK THE CONNECTION STRING PLEASE !====================");

            LoadJson("data.1.json");

            Console.ReadLine();
        }

    }
}
