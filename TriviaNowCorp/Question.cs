using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    public class Question
    {
        //declare variables to be used as properties
        private AnswerChoice[] choice = new AnswerChoice[4];
        private string text;
        private int correctChoice;
        private string feedBack;
        public Question()
        {

        }

        //grab references and store in local constructor from QuestionWriter to use in the main application 
        public Question(string questionText, string firstChoice, string secondChoice, string thirdChoice, string fourthChoice, int correctAnswer, string feedBack)
        {
            this.choice[0] = new AnswerChoice(firstChoice);
            this.choice[1] = new AnswerChoice(secondChoice);
            this.choice[2] = new AnswerChoice(thirdChoice);
            this.choice[3] = new AnswerChoice(fourthChoice);
            this.text = questionText;
            this.CorrectChoice = correctAnswer;
            this.feedBack = feedBack;
        }
        //end of Question


        public AnswerChoice[] Choices
        {
            get { return choice; }
            set { choice = value; }
        }
        //end of Choices 

        public int CorrectChoice
        {
            get { return correctChoice; }
            set { correctChoice = value; }
        }
        //end of CorrectChoice
        public string Text
        {
            get { return this.text; }
            set { this.text = value; }
        }
        //end of Text

        public string Feedback
        {
            get { return this.feedBack; }
            set { this.feedBack = value; }
        }
        //end of Feedback
    }
}
