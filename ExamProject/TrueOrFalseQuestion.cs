using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class TrueFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }

        public TrueFalseQuestion(int number, string level, int mark, string text, bool correctAnswer)
            : base(number, level, mark, text)
        {
            CorrectAnswer = correctAnswer;
        }

        public override string ToString()
        {
            return $"Q{Number} [True/False]: {QuestionText} | Level={Level}, Mark={Mark}, Correct={CorrectAnswer}";
        }
    }
}
