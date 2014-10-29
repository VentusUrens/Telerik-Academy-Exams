using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    internal class ReportDataGenerator : DataGenerator, IDataGenerator
    {

        public ReportDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {
            Console.WriteLine("Adding reports");
            var employeesIds = this.Database.Employees.Select(employee => employee.Id).ToList();
            foreach (var emp in employeesIds)
            {
                Console.WriteLine(emp);
            }

            for (int i = 0; i < this.Count; i++)
            {
                int randomYear = this.Random.GetRandomNumber(1900, 2100);
                int randomMonth = this.Random.GetRandomNumber(1, 12);
                int randomDay = this.Random.GetRandomNumber(1, 28);
                var report = new Report
                {
                    TimeOfReporting = new DateTime(randomYear,randomMonth, randomDay),
                    EmployeeId = employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count -1)]
                };
                employeesIds = this.Database.Employees.Select(emp => emp.Id).ToList();

                this.Database.Reports.Add(report);


                if (i % 100 == 0)
                {
                    Console.Write("|");
                    this.Database.SaveChanges();
                }
            }
            Console.WriteLine("\nReports added");
        }
    }
}
