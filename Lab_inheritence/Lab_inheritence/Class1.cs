using System;

namespace Lab_inheritence
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }


        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;

        }

        public string displayName()
        {
            return Name;
        }
        public virtual void ToString()
        {
            
        }
        public virtual double getPay()
        {
            return 0.0;
        }
    }

    public class Salaried : Employee
    {

        public double Salary { get; set; }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
            : base(id, name, address, phone, sin, dob, dept)
        {

            Salary = salary;
        }
        public override double getPay()
        {
            return Salary;
        }
        public override void ToString()
        {
            Console.WriteLine($"{Id} {Name} {Address} {Phone} {Sin} {Dob} {Dept} {Salary}");
        }
    }
    public class PartTime : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
            : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;
        }
        public override double getPay()
        {
            return Rate * Hours;
        }
        public override void ToString()
        {
            Console.WriteLine($"{Id} {Name} {Address} {Phone} {Sin} {Dob} {Dept} {Rate} {Hours}");
        }
    }
    public class Wages : Employee
    {
        public double Rate { get; set; }
        public double Hours { get; set; }
        public double Regular { get; set; }
        public double Ot { get; set; }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
            : base(id, name, address, phone, sin, dob, dept)
        {
            Rate = rate;
            Hours = hours;

        }
        public override double getPay()
        {
            if (Hours > 40)
            {
                Ot = (Hours - 40) * (Rate * 1.5);
                Regular = (40 * Rate);
 
                return (Ot + Regular);
            }
            else
            return Rate * Hours;
        }
        public override void ToString()
        {
            Console.WriteLine($"{Id} {Name} {Address} {Phone} {Sin} {Dob} {Dept} {Rate} {Hours}");
        }
    }
}



