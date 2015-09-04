//Spring 2015 Final Project, Vincent Nguyen, CIS 345 Tues/Thurs 3pm

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaNowCorp
{
    class TriviaApp
    {
        //static class variables and objects to be used throughout the main app.
        public static Question[] questionBank = new Question[20];
        public static QuestionWriter writeQuestion = new QuestionWriter();
        public static int questionCount;
        static void Main(string[] args)
        {
            writeQuestion.LoadQuestions(questionBank, ref questionCount);
            bool showMenu = true;
            int menuOption;
            TriviaApp game = new TriviaApp();

            //do-while loop helps with not needing to call TriviaMenu multiple times
            do
            {
                game.TriviaMenu();
                menuOption = Utilities.validateInt("\n\nSelect Menu Option: ");
                switch (menuOption)
                {
                    case 1: game.DisplayQuestions();
                        break;
                    case 2: game.FindQuestion();
                        break;
                    case 3: game.AddQuestion();
                        break;
                    case 4: game.EditQuestion();
                        break;
                    case 5: game.SaveToFile();
                        break;
                    case 6: game.PlayTrivia();
                        break;
                    case 7: showMenu = false;
                        break;
                    default: Console.WriteLine("That is an invalid command. Try Again");
                        break;
                }
            } while (showMenu == true);
            //end of do-loop
        }


        public void TriviaMenu()
        {
            Utilities.header();
            Console.WriteLine("1. Display Questions\n2. Find Questions\n3. Add Question\n4. Edit Question\n5. Save To Data File\n6. Play Trivia\n7. Exit");
        }
        //end of Trivia Menu

        public void DisplayQuestions()
        {
            Utilities.header("Display Questions");
            Console.WriteLine();
            ListQuestions();

            //give user option to see contents of question
            Console.WriteLine("\nDo you want to see the details of a question?");
            Console.Write("\nPress 'Y/y' for yes or enter to exit: ");
            string displayOption = Console.ReadLine();

            //store user's input into variable and "y" or "Y" will not matter and would still work
            switch (displayOption)
            {
                case "y":
                case "Y":

                    //store user input in variable to be used for header method and questionBank array.
                    int questionSelect = Utilities.validateInt("Which question? ");
                    questionSelect--;
                    Utilities.header(questionSelect);
                    Console.WriteLine("\nQuestion {0}: {1}\n\nChoice 1: {2}\nChoice 2: {3}\nChoice 3: {4}\nChoice 4: {5}\n\nCorrect Choice: {6}\n\nFeedback: {7}\n", questionSelect + 1, questionBank[questionSelect].Text, questionBank[questionSelect].Choices[0].answerText, questionBank[questionSelect].Choices[1].answerText, questionBank[questionSelect].Choices[2].answerText, questionBank[questionSelect].Choices[3].answerText, questionBank[questionSelect].CorrectChoice, questionBank[questionSelect].Feedback);
                    break;
                default:
                    break;
            }
            //end of switch

            Utilities.PressAnyKey();
        }
        //end of DisplayQuestion
        public void AddQuestion()
        {
            //store temporary strings of user input to then be stored in Question instance
            Utilities.header("Add Question");
            Console.Write("\n\nWhat is the question: ");
            string tmpQuestion = Console.ReadLine();
            Console.Write("\nEnter Choice 1: ");
            string choiceOne = Console.ReadLine();
            Console.Write("\nEnter Choice 2: ");
            string choiceTwo = Console.ReadLine();
            Console.Write("\nEnter Choice 3: ");
            string choiceThree = Console.ReadLine();
            Console.Write("\nEnter Choice 4: ");
            string choiceFour = Console.ReadLine();
            int rightChoice = Utilities.validateInt("\nGood. Now which choice is correct? (1-4):\nEnter correct choice: ");
            Console.Write("\n\nNow leave some feedback for the player to understand the answer!\nEnter Feedback: ");
            string newFeedback = Console.ReadLine();

            //insert temporary strings into parameters to be accepted as a new question in array
            questionBank[questionCount] = new Question(tmpQuestion, choiceOne, choiceTwo, choiceThree, choiceFour, rightChoice, newFeedback);

            //increment QuestionBank so user can add additional questions
            questionCount++;

            Console.WriteLine("\nThis question has been added!\n");
            Utilities.PressAnyKey();

        }
        //end of AddQuestion

        public void FindQuestion()
        {
            Utilities.header("Find Question");
            Console.Write("\n\nEnter a search string, we will return anything familiar: ");

            //store user input in string variable. loop through all questions in questionBank
            //using .Contains method to search through strings in each question to find similar string
            string stringSearch = Console.ReadLine();
            Console.WriteLine("\n\n\t\t\tSEARCH RESULTS FOR '{0}' in QuestionBank", stringSearch);
            for (int i = 0; i < questionCount; i++)
            {
                if (questionBank[i].Text.Contains(stringSearch))
                {
                    Console.WriteLine("\n{0}. {1}\n", i + 1, questionBank[i].Text);
                }
            }
            Utilities.PressAnyKey();
        }
        //end of FindQuestion

        public void EditQuestion()
        {

            bool editQ = true;
            do
            {
                Utilities.header("Edit Question");
                Console.WriteLine();
                ListQuestions();
                Console.WriteLine();
                int questionSelect = Utilities.validateInt("Which question do you want to edit: ");
                questionSelect--;
                Utilities.header(questionSelect);
                Console.WriteLine("\nQuestion Text: {0}", questionBank[questionSelect].Text);
                Console.WriteLine("\nChoice 1: {0}", questionBank[questionSelect].Choices[0].AnswerText);
                Console.WriteLine("\nChoice 2: {0}", questionBank[questionSelect].Choices[1].AnswerText);
                Console.WriteLine("\nChoice 3: {0}", questionBank[questionSelect].Choices[2].AnswerText);
                Console.WriteLine("\nChoice 4: {0}", questionBank[questionSelect].Choices[3].AnswerText);
                Console.WriteLine("\nCorrect Answer: {0}", questionBank[questionSelect].CorrectChoice);
                Console.WriteLine("\nFeedback: {0}\n", questionBank[questionSelect].Feedback);

                //store user input for switch statement
                int editSelect = Utilities.validateInt("\nI want to edit...\n1.Question Text\n2.Choices\n3.Correct Answer\n4.Feedback\n5.I've changed my mind\n\nSelection: ");
                switch (editSelect)
                {
                    //change Question Text of a question
                    case 1:
                        Utilities.header("Question Text");
                        Console.WriteLine("Original Question Text:\n{0}", questionBank[questionSelect].Text);
                        Console.WriteLine("New Origional Text:\n");
                        questionBank[questionSelect].Text = Console.ReadLine();
                        break;
                    //end of case 1

                    //change Choices Text of a question
                    case 2:
                        Utilities.header("Choices");
                        Console.WriteLine("1.{0}\n2.{1}\n3.{2}\n4.{3}", questionBank[questionSelect].Choices[0].AnswerText, questionBank[questionSelect].Choices[1].AnswerText, questionBank[questionSelect].Choices[2].AnswerText, questionBank[questionSelect].Choices[3].AnswerText);
                        Console.WriteLine("Choice 1: ");
                        questionBank[questionSelect].Choices[0].AnswerText = Console.ReadLine();
                        Console.WriteLine("Choice 2: ");
                        questionBank[questionSelect].Choices[0].AnswerText = Console.ReadLine();
                        Console.WriteLine("Choice 3: ");
                        questionBank[questionSelect].Choices[0].AnswerText = Console.ReadLine();
                        Console.WriteLine("Choice 4: ");
                        questionBank[questionSelect].Choices[0].AnswerText = Console.ReadLine();
                        break;
                    //end of case 2

                    //change Correct Answer text of a question
                    case 3:
                        Utilities.header("Correct Answer");
                        Console.WriteLine("Origional Correct Answer:\n{0}", questionBank[questionSelect].CorrectChoice);
                        int choiceSelect = Utilities.validateInt("New Correct Answer (1-4):\n");
                        if (!(choiceSelect > 0 && choiceSelect < 5))
                        {
                            Console.WriteLine("Please enter a number between 1 and 4");
                        }
                        else
                        { questionBank[questionSelect].CorrectChoice = choiceSelect; }
                        break;
                    //end of case 3

                    //change Feedback text of a question
                    case 4:
                        Utilities.header("Feedback");
                        Console.WriteLine("Original Feedback:\n{0}", questionBank[questionSelect].Feedback);
                        Console.WriteLine("New Feedback:\n");
                        questionBank[questionSelect].Feedback = Console.ReadLine();
                        break;
                    //end of case 4

                    //user exits edit menu due to bool requirements.
                    case 5:
                        editQ = false;
                        break;
                    //end of case 5

                    //any key that is not 1-5 is considered an exit key
                    default:
                        editQ = false;
                        break;
                }

            } while (editQ == true);
            // end of do loop

            Console.WriteLine("Edits Saved!");
            Utilities.PressAnyKey();
        }
        //end of EditQuestion

        public void SaveToFile()
        {
            //call QuestionWriter method to save any changes to data.txt file
            Utilities.header("Saving Data File");
            writeQuestion.SavetoDataFile();
            Utilities.PressAnyKey();
        }
        //end of SavetToFile

        public void PlayTrivia()
        {
            Utilities.header("Time to Play!");
            int playerScore = 0;
            Random triviaMix = new Random();
            for (int i = 0; i < 5; i++)
            {
                //store random method of triviaMix in trivia select to choose random question
                int triviaSelect = triviaMix.Next(0, questionCount);
                Console.WriteLine("\n\nQuestion {0}: {1}\n\n1. {2}\n2. {3}\n3. {4}\n4. {5}", i + 1, questionBank[triviaSelect].Text, questionBank[triviaSelect].Choices[0].AnswerText, questionBank[triviaSelect].Choices[1].AnswerText, questionBank[triviaSelect].Choices[2].AnswerText, questionBank[triviaSelect].Choices[3].AnswerText);

                //store user answer choice to be used to test if it is correct
                int playerSelect = Utilities.validateInt("\nWhat is your answer?(1-4): ");

                //test user input and compare it to correctChoice property of question
                //increment player score since they are right
                //use else statement to tell them they are wrong. does not increment score
                if (playerSelect == (questionBank[triviaSelect].CorrectChoice))
                {
                    playerScore++;
                    Console.WriteLine("\nCORRECT!");
                    Console.WriteLine("\nYour Score: {0} out of 5", playerScore);
                    Console.WriteLine("\nFeedback: {0} ", questionBank[triviaSelect].Feedback);
                }
                else
                {
                    Console.WriteLine("\nWRONG! You know nothing, user. The correct answer was {0}", questionBank[triviaSelect].CorrectChoice);
                    Console.WriteLine("\nYour Score: {0} out of 5", playerScore);
                    Console.WriteLine("\nFeedback: {0} ", questionBank[triviaSelect].Feedback);
                }
                //end of if-else statement
            }

            Console.WriteLine("\nThanks for playing!");
            Utilities.PressAnyKey();

        }
        //end of PlayTrivia


        public void ListQuestions()
        {
            //ListQuestions is seperated from DisplayQuestions to be reusable
            //Loop through array to display all question texts
            for (int i = 0; i < questionCount; i++)
            {
                Console.WriteLine("{0}. \t{1}", i + 1, questionBank[i].Text);
            }
        }
        //end of ListQuestions
    }
}
