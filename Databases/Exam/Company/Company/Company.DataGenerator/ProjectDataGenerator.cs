namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    internal class ProjectDataGenerator : DataGenerator, IDataGenerator
    {

        public ProjectDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities toyStoreEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, toyStoreEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding projects");
            for (int i = 0; i < this.Count; i++)
            {
                var category = new Project
                {
                    Name = this.Random.GetRandomStringWithRandomLength(5, 50)
                };

                this.Database.Projects.Add(category);
                

                if (i % 100 == 0)
                {
                    Console.Write("|");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nProjects added");
        }
    }
}
