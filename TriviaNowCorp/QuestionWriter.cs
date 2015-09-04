using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TriviaNowCorp
{
    public class QuestionWriter
    {
        
        // stream reader and writer instance variables
        StreamReader sr;
        StreamWriter sw;

        // input stream
        FileStream input;

        private String LineText = ""; // stores a line of text

       // it will hold a reference to the array of Questions 
       // supplied by the users
        private Question[] QuestionBank;

        // keeps a track of the number of questions
        private int NumofQuestions = 0;

        /// <summary>
        /// Reads the Next Line from the data file
        /// </summary>
        /// <returns>string, representing the line of text just read.</returns>
        private string ReadNextLine()
        {
            try
            {
                do
                {
                    LineText = sr.ReadLine(); // read the next line
                    if (LineText == null) 
                        // if the line text is null, it's end of file. Return.
                        return LineText;

                } while ((LineText.Contains("#") == true)); // read another line if line starts with # since that is a comment.
            }
            catch (IOException)
            {
                // there was an IO error
                Console.WriteLine("There was an File Read Error. Press a key to exit");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                // There was some generic error
                Console.WriteLine("There was an Error. Press a key to exit");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }

            return LineText; // return the line of text that was read
        }


        /// <summary>
        /// Saves the contents of the Question array to file. Question array will need to have been set first by making a call to LoadQuestions
        /// </summary>
        public void SavetoDataFile()
        {
            try
            {
                // create a new file stream
                // it will overwrite the existing Data file
                input = new FileStream("Data.txt", FileMode.Create, FileAccess.Write);
                
                // create a new streamwriter
                sw = new StreamWriter(input);
                    
                // temporary variable to store a Question
                Question tmpQuestion;

                // write the top portion of the data file
                WriteDataFileInstructions();

                // loop through all questions
                for (int i = 0; i < QuestionBank.Length; i++)
                {
                    if (QuestionBank[i] == null)
                        // if we run into a null, then questions are over. Do not loop through the array more.
                        break;
                    else
                    {
                        //set a temporary reference to the current element.
                        tmpQuestion = QuestionBank[i];

                        // write the contents of the array element to the streamwriter.
                        sw.WriteLine(tmpQuestion.Text);
                        sw.WriteLine(tmpQuestion.Choices[0].AnswerText);
                        sw.WriteLine(tmpQuestion.Choices[1].AnswerText);
                        sw.WriteLine(tmpQuestion.Choices[2].AnswerText);
                        sw.WriteLine(tmpQuestion.Choices[3].AnswerText);
                        sw.WriteLine(tmpQuestion.CorrectChoice);
                        sw.WriteLine(tmpQuestion.Feedback);
                        sw.WriteLine("#");
                        sw.WriteLine("#");
                        sw.WriteLine("#");
                    }
                }
                // close the streamwriter and the filestream
                sw.Close();
                input.Close();

                Console.WriteLine("\nSaved to data file.");

            }
            catch (IOException)
            {
                // THere was a file IO exception
                Console.WriteLine("There was an IO error in writing.");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                // there was some other generic exception
                Console.WriteLine("There was an File Read Error. Press a key to exit");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }

        }

        /// <summary>
        ///  This method writes the header of the data file
        /// </summary>
        private void WriteDataFileInstructions()
        {
            try
            {
                // usign the streamwriter object, write out the contents of the array
                sw.WriteLine("# Blank lines or comment lines must start with # sign");
                sw.WriteLine("#");

                sw.WriteLine("#Question Description");
                sw.WriteLine("#Answer choice 0");
                sw.WriteLine("#Answer Choice 1");
                sw.WriteLine("#Answer Choice 2");
                sw.WriteLine("#Answer Choice 3");
                sw.WriteLine("#Correct Answer Number");
                sw.WriteLine("#Feedback");
                sw.WriteLine("#");
                sw.WriteLine("#");
                sw.WriteLine("#");
            }

            catch (IOException)
            {
                // there was a file IO error
                Console.WriteLine("There was an IO error in writing.");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                // there was some other generic exception thrown
                Console.WriteLine("There was an File Read Error. Press a key to exit");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }

        }

        /// <summary>
        /// This method will read the datafile and populate an array of Questions that is given to it as an argument
        /// </summary>
        /// <param name="QuestionBank">An already-instantiated reference to an array of Questions</param>
        /// <param name="QuestionCount">an integer, passed by reference, that will store the count of how many questions were found in the data file</param>
        public void LoadQuestions(Question[] QuestionBank, ref int QuestionCount)
        {
            // Store a reference to the QuestionBank in this instance's instance variables
            this.QuestionBank = QuestionBank;

            // local variables to store question information
            string q = "";
            string a0 = "";
            string a1 = "";
            string a2 = "";
            string a3 = "";
            int intCorrectAnswer;
            string feedback = "";

            // the line of text
            LineText = "";

            // store the value passed as a parameter within the class's instance variable
            NumofQuestions = QuestionCount;

            try
            {

                // create a new file stream 
                input = new FileStream("Data.txt", FileMode.Open, FileAccess.Read);

                // create a new streamreader
                sr = new StreamReader(input);

                while (LineText != null) // keep on going while no null is encountered
                {

                    q = ReadNextLine(); // read the next line
                    if (q == null)

                    {
                        // it was null. Terminate by closing the stream and writer.

                        input.Dispose();
                        sr.Dispose();

                        // end the method.
                        return;

                    }

                    // It wasn't null. Keep on reading the question details line after line.
                    a0 = ReadNextLine();
                    a1 = ReadNextLine();
                    a2 = ReadNextLine();
                    a3 = ReadNextLine();

                    intCorrectAnswer = Convert.ToInt32(ReadNextLine());
                    feedback = ReadNextLine();

                    // Now instantiate the question and provide it with all the values.
                    Question tmpQuestion = new Question(q, a0, a1, a2, a3, intCorrectAnswer, feedback);
                    
                    // put the object into the array
                    QuestionBank[QuestionCount] = tmpQuestion;

                    // increment the question count
                    QuestionCount = QuestionCount + 1;
                }

            }

            catch (IOException)
            {
                // there was a file IO error
                Console.WriteLine("There was an IO error in writing.");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }
            catch (Exception)
            {
                // there was some other generic exception thrown
                Console.WriteLine("There was an File Read Error. Press a key to exit");
                Console.ReadKey(true);
                System.Environment.Exit(0);
            }

        } // end load questions




    }

}
