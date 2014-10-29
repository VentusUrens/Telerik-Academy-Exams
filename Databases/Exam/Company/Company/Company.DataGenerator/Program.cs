namespace Company.DataGenerator
{
    using System.Collections.Generic;
    using System.Linq;
    using Company.Data;
    using System;
    
    internal class Program
    {
        private static void Main()
        {

            Console.WriteLine("====================================================================");
            Console.WriteLine("==============PLEASE CHECK THE CONNECTION STRING====================");
            Console.WriteLine("===========IF IT DOES NOT WORK AFTER AT LEAST 10 seconds============");
            Console.WriteLine("====================================================================");
            var random = RandomDataGenerator.Instance;
            var db = new CompanyEntities();
            db.Configuration.AutoDetectChangesEnabled = false;

            var listOfGenerators = new List<DataGenerator>
            {
                //DONE ->
                new DepartmentDataGenerator(random, db, 100),
                new ProjectDataGenerator(random, db, 1000),
                new EmployeeDataGenerator(random, db, 5000),
                new ReportDataGenerator(random, db, 25000)
            };

            foreach (var generator in listOfGenerators)
            {
                Console.WriteLine("==============================");
                generator.Generate();
                Console.WriteLine("==============================");
                db.SaveChanges();
            }
        }
    }
}
