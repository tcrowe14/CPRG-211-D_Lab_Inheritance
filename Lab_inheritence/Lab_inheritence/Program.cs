using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_inheritence
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Employee> employeeList = new List<Employee>(); // create a list for employee objects
            string filepath = @"employees.txt"; // declare the file

            List<string> lines = new List<string>(File.ReadAllLines(filepath)); // read the file into a list
            string[] data;
            string id;
            string name;
            string address;
            string phone;
            long SIN;
            string dob;
            string department;
            double salary;
            double rate;
            int hours;
            foreach (var line in lines) // loop throught the data splitting it accordingly
            {
                data = line.Split(':');
                id = data[0];
                name = data[1];
                address = data[2];
                phone = data[3];
                SIN = long.Parse(data[4]);
                dob = data[5];
                department = data[6];


                if (int.Parse(line.Substring(0, 1)) >= 0 && int.Parse(line.Substring(0, 1)) <= 4) // for salary
                {
                    salary = double.Parse(data[7]);
                    employeeList.Add(new Salaried(id, name, address, phone, SIN, dob, department, salary));
                }
                else if (int.Parse(line.Substring(0, 1)) >= 5 && int.Parse(line.Substring(0, 1)) <= 7) // for waged
                {
                    hours = int.Parse(data[8]);
                    rate = double.Parse(data[7]);
                    employeeList.Add(new Wages(id, name, address, phone, SIN, dob, department, rate, hours));
                }
                else if (int.Parse(line.Substring(0, 1)) >= 8 && int.Parse(line.Substring(0, 1)) <= 9) // for part time
                {
                    hours = int.Parse(data[8]);
                    rate = double.Parse(data[7]);
                    employeeList.Add(new PartTime(id, name, address, phone, SIN, dob, department, rate, hours));
                }

            }

            double total = employeeList.Count; // variable for total employee objects in the list


            // Display employees information
            foreach (var employee in employeeList)
            {
                employee.ToString();
            }
            Console.WriteLine("");
            Console.ReadLine();


            // Display pay
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"{employee.displayName()} Weekly pay: {employee.getPay().ToString("C")}");
            }
            Console.WriteLine("");
            Console.ReadLine();


            // Average Weekly
            double weeklyPay = 0;
            foreach (var employee in employeeList)
            {
                weeklyPay += employee.getPay();
            }
            double average = weeklyPay / total;
            Console.WriteLine($"Average weekly pay is {average.ToString("C")}");
            Console.WriteLine("");
            Console.ReadLine();


            // Wage employees paid the highest
            double highestWage = 0; // declare a low number to compare to
            string highestWageEmployee = ""; // variable to store the highest paid wage employee

            foreach (var employee in employeeList)
            {

                if (employee is Wages && employee.getPay() > highestWage)
                {
                    highestWage = employee.getPay();
                    highestWageEmployee = $"Highest weekly paid Wage employee is {employee.Name} with Pay: {employee.getPay().ToString("C")}";
                }

            }
            Console.WriteLine(highestWageEmployee);
            Console.WriteLine("");
            Console.ReadLine();


            // Salary employees paid the lowest
            double lowestSalary = 9999999999; // declare a high number to compare to
            string lowestSalaryEmployee = ""; // variable to store the lowest paid salary employee
            foreach (var employee in employeeList)
            {

                if (employee is Salaried && employee.getPay() < lowestSalary)
                {
                    lowestSalary = employee.getPay();
                    lowestSalaryEmployee = $"Lowest weekly paid Salary employee is {employee.Name} with Pay: {employee.getPay().ToString("C")}";
                }

            }
            Console.WriteLine(lowestSalaryEmployee);
            Console.WriteLine("");
            Console.ReadLine();


            // percentage calculations
            double salcount = 0;
            double wagecount = 0;
            double ptcount = 0;

            foreach (var employee in employeeList)
            {

                if (employee is Salaried)
                {
                    salcount++;
                }
                if (employee is Wages)
                {
                    wagecount++;
                }
                if (employee is PartTime)
                {
                    ptcount++;
                }

            }

            Console.WriteLine("Percentage of salaried employees is " + (salcount / total).ToString("P"));
            Console.WriteLine("Percentage of wage employees is " + (wagecount / total).ToString("P"));
            Console.WriteLine("Percentage of part time employees is " + (ptcount / total).ToString("P"));

            Console.ReadLine();

        }
    }
}
        
    



