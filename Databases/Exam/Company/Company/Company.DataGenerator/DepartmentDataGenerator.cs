namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;
    
    using Company.Data;
    
    internal class DepartmentDataGenerator : DataGenerator, IDataGenerator
    {

        public DepartmentDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        int index = 0;
        public override void Generate()
        {
            var manufacturersToBeAdded = new HashSet<string>();

            while (manufacturersToBeAdded.Count != this.Count)
            {
                manufacturersToBeAdded.Add(this.Random.GetRandomStringWithRandomLength(10, 50));
            }

            Console.WriteLine("Adding departments");
            foreach (var manufacturerName in manufacturersToBeAdded)
            {
                var department = new Department
                {
                    Name = manufacturerName
                };

                this.Database.Departments.Add(department);

                if (index % 100 == 0)
                {
                    Console.Write("|");
                    this.Database.SaveChanges();
                }
                index++;
            }
            Console.WriteLine("\nDepartments added");
        }
    }
}
