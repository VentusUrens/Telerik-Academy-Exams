using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Company.DataGenerator
{
    using System;
    using System.Collections.Generic;

    using Company.Data;

    internal class EmployeeDataGenerator : DataGenerator, IDataGenerator
    {

        public EmployeeDataGenerator(IRandomDataGenerator randomDataGenerator, CompanyEntities companyEntities, int countOfGeneratedObjects)
            : base(randomDataGenerator, companyEntities, countOfGeneratedObjects)
        {
        }

        public override void Generate()
        {

            Console.WriteLine("Adding employees");
            var employeesIds = this.Database.Employees.Select(employee => employee.Id).ToList();
            var projectsIds = this.Database.Projects.Select(project => project.Id).ToList();
            var departmentsIds = this.Database.Departments.Select(department => department.Id).ToList();
            var reportsIds = this.Database.Projects.Select(report => report.Id).ToList();

            //INSERTING FIRST EMPLOYEE
            var firstEmployee = new Employee
            {
                FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                YearSalary = this.Random.GetRandomNumber(50000, 200000),
                ManagerId = (int?)null, //this.Random.GetRandomNumber(0, 100) > 95 ? (int?)null : employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count)],
                DepartmentId = departmentsIds[this.Random.GetRandomNumber(0, this.Random.GetRandomNumber(0, departmentsIds.Count))],

            };

            this.Database.Employees.Add(firstEmployee);
            //INSERTER FIRST EMPLOYEE

            employeesIds = this.Database.Employees.Select(employee => employee.Id).ToList();

            for (int i = 0; i < this.Count; i++)
            {
                var employee = new Employee
                {
                    FirstName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    LastName = this.Random.GetRandomStringWithRandomLength(5, 20),
                    YearSalary = this.Random.GetRandomNumber(50000, 200000),
                    ManagerId = this.Random.GetRandomNumber(0, 100) < 95 ? (int?)null : employeesIds[this.Random.GetRandomNumber(0, employeesIds.Count - 1)],
                    DepartmentId = departmentsIds[this.Random.GetRandomNumber(0, this.Random.GetRandomNumber(0, departmentsIds.Count - 1))],
                    
                    
                };
                employeesIds = this.Database.Employees.Select(emp => emp.Id).ToList();
                employee.EmployeesProjects.Add(new EmployeesProject()
                {
                    ProjectId = projectsIds[this.Random.GetRandomNumber(0, projectsIds.Count - 1)]
                });
                this.Database.Employees.Add(employee);


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
