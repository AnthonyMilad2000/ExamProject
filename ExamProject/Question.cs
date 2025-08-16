using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal abstract class Question
    {
        public int Number { get; set; }
        public string Level { get; set; }
        public int Mark { get; set; }
        public string QuestionText { get; set; }

        public Question(int number, string level, int mark, string text)
        {
            Number = number;
            Level = level;
            Mark = mark;
            QuestionText = text;
        }

        public abstract override string ToString();
    }
}
