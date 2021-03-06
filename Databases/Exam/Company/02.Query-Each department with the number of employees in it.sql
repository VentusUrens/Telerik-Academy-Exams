/****** Script for SelectTopNRows command from SSMS  ******/
/*2.	Get all departments and how many employees there are in each one.
 Sort the result by the number of employees in descending order.*/

 SELECT d.Name, Count(*) as CountOfEmployees
 from [company].[dbo].[Employees] e
 INNER JOIN [Company].[dbo].[Departments] d
 ON e.DepartmentId = d.Id
 GROUP BY d.Name
 ORDER BY CountOfEmployees DESC