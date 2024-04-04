using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestikC
{
    public class TestClass
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int FirstAnswer { get; set; }
        public int SecondAnswer { get; set; }
        public int ThirdAnswer { get; set; }

        public Answer CorrectAnswer { get; set; }

        public TestClass(string name, string description, int firstAnswer, int secondAnswer, int thirdAnswer, Answer correctAnswer)
        {
            Name = name;
            Description = description;
            FirstAnswer = firstAnswer;
            SecondAnswer = secondAnswer;
            ThirdAnswer = thirdAnswer;
            CorrectAnswer = correctAnswer;
        }
    }
    public enum Answer
    {
        FirstAnswer,
        SecondAnswer,
        ThirdAnswer
    }
}
