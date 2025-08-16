using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class Doctor : Account
    {
        public string Course { get; set; }

        public double Salary { get; set; }

        public Doctor(string course, double salary, int id, string name, string password,
            string email, string phone, string role): base (id,  name, password, email, phone, role)
        {
            this.Course = course;
            this.Salary = salary;
        }

        



    }
}
