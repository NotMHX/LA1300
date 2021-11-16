using System;
using System.IO;

namespace helloworld
{
    class Program
    {

        int lives; 

        static void Main(string[] args)
        {
            int lives = 3;
            int round = 1;

            Console.WriteLine("Willkommen zu unserem Geoquiz. [...]\n\n\nSo funktioniert es:\n- Sie starten mit 3 Leben.\n- Eine Frage nach der anderen wird zufällig ausgewählt.\n- Jede Frage hat 3 Antwortmöglichkeiten .\n- Wenn die Frage falsch beantwortet oder die Zeit abgelaufen ist, verlieren Sie ein Leben.\n- Bei 0 Leben endet das Quiz.\n\nDrücken Sie eine beliebige Taste, um das Quiz zu beginnen!");
            Console.ReadKey();
            Console.Clear();
            string filePath = @"C:\Users\micha\OneDrive\Desktop\fragen.csv";
            
            string text = File.ReadAllText(filePath);
            string[] lines = text.Split("\r\n");
            int words = lines.Length;
            string[] questionText = new string[words];
            string[] answerA = new string[words];
            string[] answerB = new string[words];
            string[] answerC = new string[words];
            string[] correctAnswer = new string[words];

            for (int line = 0; line < lines.Length; line++)
            {
                
                string[] items = lines[line].Split(',');
                questionText[line] = items[0];
                answerA[line] = items[1];
                answerB[line] = items[2];
                answerC[line] = items[3];
                correctAnswer[line] = items[4].Replace("\"", string.Empty);
            }

            do
            {
                Random randomNum = new Random();
                int randomQuestion = randomNum.Next(1, 15);
                lives = question(questionText[randomQuestion], answerA[randomQuestion], answerB[randomQuestion], answerC[randomQuestion], correctAnswer[randomQuestion], lives, round);
                round++;
                    
            } while (lives > 0);
            
            Console.WriteLine($"----------\nDas Spiel ist vorbei. Sie haben {round } Runden geschafft.");
            Console.ReadKey();
        }

        public static int question(string questionText, string answerA, string answerB, string answerC, string correctAnswer, int lives,int round)
        {

            while (true)
            {
               
                Console.WriteLine($"----------\nRunde #{round} // {lives} Leben \n----------\n{questionText}\nA. {answerA}  B. {answerB}, C. {answerC}");
                
                    string input = Console.ReadLine();
                    string answer = input.ToUpper();

                if (answer == correctAnswer)
                {
                    Console.WriteLine("----------\nDie Antwort ist richtig!");

                    return lives;
                }
                else if (answer != correctAnswer)
                {
                    Console.WriteLine($"----------\nSie haben eine falsche Antwort gegeben. Die richtige war: {correctAnswer}");
                    lives--;

                    return lives;
                }   
            }
        }
    }
}

