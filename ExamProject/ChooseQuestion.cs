using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class ChooseQuestion : Question
    {
        public List<string> Options { get; set; }
        public int CorrectOptionIndex { get; set; }

        public ChooseQuestion(int number, string level, int mark, string text, List<string> options, int correctIndex)
            : base(number, level, mark, text)
        {
            Options = options;
            CorrectOptionIndex = correctIndex;
        }

        public override string ToString()
        {
            string opts = "";
            for (int i = 0; i < Options.Count; i++)
            {
                opts += Options[i] + ", ";
            }

            return $"Q{Number} [Choose One]: {QuestionText} | Options=({opts}) | Correct={Options[CorrectOptionIndex]} | Level={Level}, Mark={Mark}";
        }
    }
}
