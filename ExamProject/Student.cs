using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class Student : Account
    {
        public string Major { get; set; }

        public double TuitionFees { get; set; }

        public Student(string major, double tFees, int id, string name,
            string password, string email, string phone, string role) : base(id, name, password, email, phone, role)
        {

            Major = major;
            TuitionFees = tFees;
        }
    }
}
