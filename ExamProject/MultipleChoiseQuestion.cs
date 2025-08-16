using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    internal class MultipleChoiceQuestion : Question
    {
        public List<string> Options { get; set; }
        public List<int> CorrectOptions { get; set; }

        public MultipleChoiceQuestion(int number, string level, int mark, string text, List<string> options, List<int> correctOptions)
            : base(number, level, mark, text)
        {
            Options = options;
            CorrectOptions = correctOptions;
        }

        public override string ToString()
        {
            string opts = "";
            for (int i = 0; i < Options.Count; i++)
            {
                opts += Options[i] + ", ";
            }
            string correct = string.Join(", ", CorrectOptions.ConvertAll(i => Options[i]));
            return $"Q{Number} [Multiple Choice]: {QuestionText} | Options=({opts}) | Correct=({correct}) | Level={Level}, Mark={Mark}";
        }
    }
}
