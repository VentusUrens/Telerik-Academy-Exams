/****** Script for SelectTopNRows command from SSMS  ******/
SELECT e.FirstName + ' ' + e.Lastname as FullName, e.YearSalary as Salary
  FROM [Company].[dbo].[Employees] e
  WHERE e.YearSalary BETWEEN 100000 AND 150000
  ORDER BY Salary ASC