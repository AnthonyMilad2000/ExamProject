using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ExamProject
{
    internal class Exam
    {
        public int QuestionCount { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();

        public void SetExamQuestionNumber(int q)
        {
            QuestionCount = q;
        }

        public void SetExamQuestions()
        {
            for (int i = 0; i < QuestionCount; i++)
            {
                Console.WriteLine($"\nEnter details for Question {i + 1}:");

                Console.WriteLine("Choose question type by enter type number (1: True/False, 2: Multiple Choice, 3: Choose One):");
                int type = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter question level (Easy, Hard):");
                string ql = Console.ReadLine();

                Console.WriteLine("Enter question mark (1, 2, 3):");
                int qm = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter question text:");
                string text = Console.ReadLine();

                if (type == 1)
                {
                    Console.WriteLine("Enter correct answer (true/false):");
                    bool correct = Convert.ToBoolean(Console.ReadLine());
                    Questions.Add(new TrueFalseQuestion(i + 1, ql, qm, text, correct));
                }
                else if (type == 2)
                {
                    Console.Write("How many options? ");
                    int optCount = Convert.ToInt32(Console.ReadLine());
                    List<string> options = new List<string>();

                    for (int j = 0; j < optCount; j++)
                    {
                        Console.Write($"Enter option {j + 1}: ");
                        options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter correct answers (comma separated indexes, starting from 1): ");
                    string[] corrects = Console.ReadLine().Split(',');
                    List<int> correctIndexes = new List<int>();
                    for (int j = 0; j < corrects.Length; j++)
                    {
                        correctIndexes.Add(Convert.ToInt32(corrects[j].Trim()) - 1);
                    }

                    Questions.Add(new MultipleChoiceQuestion(i + 1, ql, qm, text, options, correctIndexes));
                }
                else if (type == 3)
                {
                    Console.Write("How many options? ");
                    int optCount = Convert.ToInt32(Console.ReadLine());
                    List<string> options = new List<string>();

                    for (int j = 0; j < optCount; j++)
                    {
                        Console.Write($"Enter option {j + 1}: ");
                        options.Add(Console.ReadLine());
                    }

                    Console.Write("Enter correct option index (starting from 1): ");
                    int correctIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                    Questions.Add(new ChooseQuestion(i + 1, ql, qm, text, options, correctIndex));
                }
            }
        }

        public void ShowExamQuestions()
        {
            Console.WriteLine("\nYou entered the following questions:");
            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine(Questions[i]);
            }

        }

        public void TakeExam(Student student, string level)
        {
            List<Question> examQuestions = Questions.FindAll(q => q.Level.ToLower() == level.ToLower());
            if (examQuestions.Count == 0)
            {
                Console.WriteLine($"No {level} questions available.");
                return;
            }

            int score = 0;
            int total = 0;

            Console.WriteLine($"\nStarting {level} Exam for {student.Name}...\n");

            for (int i = 0; i < examQuestions.Count; i++)
            {
                Question q = examQuestions[i];
                Console.WriteLine(q.QuestionText);

                if (q is TrueFalseQuestion tf)
                {
                    Console.Write("Enter answer (true/false): ");
                    bool ans = Convert.ToBoolean(Console.ReadLine());
                    if (ans == tf.CorrectAnswer)
                        score += tf.Mark;
                    total += tf.Mark;
                }
                else if (q is ChooseQuestion ch)
                {
                    for (int j = 0; j < ch.Options.Count; j++)
                        Console.WriteLine($"{j + 1}. {ch.Options[j]}");

                    Console.Write("Enter your choice: ");
                    int ans = Convert.ToInt32(Console.ReadLine()) - 1;

                    if (ans == ch.CorrectOptionIndex)
                        score += ch.Mark;
                    total += ch.Mark;
                }
                else if (q is MultipleChoiceQuestion mc)
                {
                    for (int j = 0; j < mc.Options.Count; j++)
                        Console.WriteLine($"{j + 1}. {mc.Options[j]}");

                    Console.Write("Enter your choices (comma separated): ");
                    string[] answers = Console.ReadLine().Split(',');
                    List<int> ansIndexes = new List<int>();

                    for (int k = 0; k < answers.Length; k++)
                        ansIndexes.Add(Convert.ToInt32(answers[k].Trim()) - 1);
                    bool isCorrect = true;

                    for (int l = 0; l < ansIndexes.Count; l++)
                    {
                        if (!mc.CorrectOptions.Contains(ansIndexes[l]))
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                    if (isCorrect && ansIndexes.Count == mc.CorrectOptions.Count)
                        score += mc.Mark;

                    total += mc.Mark;
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Exam Finished! Your Score = {score}/{total}");
        }

    }
}
