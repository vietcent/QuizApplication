using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    public class AnswerChoice
    {
        //declare class variables to be used through AnswerChoice class
        public string answerText;
        public int correctChoice;

        //public AnswerChoice()
        //{
        //    this.answerText = "";

        //}

        //AnswerChoice stores answerText to be passed through AnswerText property
        public AnswerChoice(string answerText)
        {
            this.AnswerText = answerText;
        }
        //end of AnswerChoice

        public string AnswerText
        {
            get { return this.answerText; }
            set { this.answerText = value; }
        }
        //end of AnswerText
    }
}
