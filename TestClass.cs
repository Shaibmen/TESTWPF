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
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }

        public Answer CorrectAnswer { get; set; }

        public TestClass(string name, string description, string firstAnswer, string secondAnswer, string thirdAnswer, Answer correctAnswer)
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
        First = 0,
        Second = 1,
        Third = 2
    }
}
