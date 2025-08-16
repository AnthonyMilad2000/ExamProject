using System.Security.Principal;

namespace ExamProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account doctor = new Doctor("ASP.net", 20000.0, 1, "Mohammed", "12345", "mohammed@gmail.com", "010", "Doctor");
            Student student = new Student("Computer Science", 8200.0, 1, "Tony", "1234", "tony@gmail.com", "010", "Student");
            Exam exam = new Exam();
            bool endExam = true;
            do
            {
                Console.WriteLine("Login as a:");
                Console.WriteLine("D For Doctor:");
                Console.WriteLine("S For Student:");
                Console.WriteLine("-----------------");
                Console.WriteLine("Press Q to Exit.");

                string role = Console.ReadLine().ToUpper();

                if (role == "Q")
                {
                    endExam = false;
                    continue;
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                Account loginAccount = new Account(1, name, password, "", "", "");

                if (role == "D" && doctor.login(loginAccount))
                {
                    Console.WriteLine("Logged in as a doctor.");
                    Console.WriteLine("=======================");
                    Console.Write("How many questions do you want? ");
                    Console.WriteLine("==============================");

                    int q = Convert.ToInt32(Console.ReadLine());
                    exam.SetExamQuestionNumber(q);

                    Console.WriteLine($"You Entered: {exam.QuestionCount} Question(s).");
                    exam.SetExamQuestions();
                    exam.ShowExamQuestions();
                }

                else if (role == "S" && student.login(loginAccount))
                {
                    Console.WriteLine("Logged in as a student.");
                    Console.Write("Do you want Easy or Hard exam? ");
                    string level = Console.ReadLine();

                    exam.TakeExam(student, level);
                }
                else Console.WriteLine("Invalid Credentials");
                Console.WriteLine("----------------");
            }
            while (endExam);
        }
    }
}
