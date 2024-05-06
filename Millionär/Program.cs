using System;
using System.Linq;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        string playAgainResponse;

        do
        {
            DisplayTitle("Willkommen bei Wer wird Millionär", ConsoleColor.Yellow);
            Console.WriteLine();

            PlayGame();

            Console.WriteLine();
            Console.Write("Möchtest du nochmal spielen? (Ja/Nein): ");
            playAgainResponse = Console.ReadLine().Trim();

            if (playAgainResponse.Equals("Ja", StringComparison.OrdinalIgnoreCase) || playAgainResponse.Equals("J", StringComparison.OrdinalIgnoreCase))
            {
                playAgainResponse = "Ja";
            }
            else if (playAgainResponse.Equals("Nein", StringComparison.OrdinalIgnoreCase) || playAgainResponse.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                playAgainResponse = "Nein";
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte gib Ja (J) oder Nein (N) ein.");
            }
        } while (playAgainResponse.Equals("Ja", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Vielen Dank fürs Spielen. Auf Wiedersehen!");
    }

    private static void DisplayTitle(string title, ConsoleColor color)
    {
        Console.Clear();
        Console.ForegroundColor = color;

        Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
        Console.WriteLine(title);

        Console.ResetColor();
    }

    private static void PlayGame()
    {
        string[,] questions = {
            { "Was ist die größte Insel der Welt?", "Grönland", "Australien", "Madagaskar", "Neuseeland" },
            { "Welches dieser Tiere ist kein Säugetier?", "Krokodil", "Wal", "Fledermaus", "Ameise" },
            { "Welche Farbe hat Pikachu aus Pokemon?", "Gelb", "Orange", "Rot", "Grün" },
            { "Wer malte die Mona Lisa?", "Leonardo da Vinci", "Michelangelo", "Vincent van Gogh", "Pablo Picasso" },
            { "Wer war der erste Mensch auf dem Mond?", "Keiner", "Neil Armstrong", "Buzz Aldrin", "Juri Gagarin" },
            { "Wie viele Bundesländer hat Deutschland?", "16", "17", "18", "19" },
            { "Wer War von 2005 bis 2021 Deutscher Bundeskanzler?", "Angela Merkel", "Angelo Merte", "Hitler", "Olaf Cumex Scholz" },
            { "Wie heißt die Hauptstadt der Niederlande?", "Amsterdam", "Rotterdam", "Den Haag", "Utrecht" },
            { "In welchem Jahr begann der Zweite Weltkrieg?", "1939", "1940", "1941", "1942" },
            { "Wer schrieb 'Faust'?", "Johann Wolfgang von Goethe", "Friedrich Schiller", "Heinrich Heine", "Friedrich Nietzsche" }
        };

        int score = 0;
        Random random = new Random();

        int totalQuestions = questions.GetLength(0);

        for (int currentQuestion = 0; currentQuestion < totalQuestions; currentQuestion++)
        {
            int questionAmount = GetQuestionAmount(currentQuestion + 1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"({questionAmount.ToString("N0", CultureInfo.GetCultureInfo("de-DE"))} Euro Frage)");
            Console.ResetColor();

            string question = questions[currentQuestion, 0];
            string correctAnswer = questions[currentQuestion, 1];
            string[] options = { questions[currentQuestion, 1], questions[currentQuestion, 2], questions[currentQuestion, 3], questions[currentQuestion, 4] };
            options = options.OrderBy(option => random.Next()).ToArray();

            Console.WriteLine(question);

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            string userInput;
            bool validInput = false;

            do
            {
                Console.Write("Antwort eingeben (1-4): ");
                userInput = Console.ReadLine();

                if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4")
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1, 2, 3 oder 4 aus.");
                    Console.ResetColor();
                }
            } while (!validInput);

            int answerIndex = int.Parse(userInput) - 1;
            string selectedAnswer = options[answerIndex];

            if (selectedAnswer == correctAnswer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Richtig!");
                Console.ResetColor();
                score++;

                if (score == totalQuestions)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Herzlichen Glückwunsch, Sie haben alle Fragen richtig beantwortet!");
                    Console.ResetColor();

                    DisplayAsciiArt(GetAsciiArt());
                    break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Leider falsch. Das Spiel ist vorbei.");
                Console.ResetColor();
                break;
            }

            Console.WriteLine();
        }
    }

    private static int GetQuestionAmount(int questionNumber)
    {
        switch (questionNumber)
        {
            case 1: return 1000;
            case 2: return 4000;
            case 3: return 8000;
            case 4: return 16000;
            case 5: return 32000;
            case 6: return 64000;
            case 7: return 125000;
            case 8: return 250000;
            case 9: return 500000;
            case 10: return 1000000;
            default: return 0;
        }
    }

    private static string GetAsciiArt()
    {
        return @"
                ⠸⣷⣦⠤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣠⣤⠀⠀⠀
⠀                ⠙⣿⡄⠈⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⠊⠉⣿⡿⠁⠀⠀⠀
⠀⠀                 ⠈⠣⡀⠀⠀⠑⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⠊⠁⠀⠀⣰⠟⠀⠀⠀⣀⣀
⠀⠀⠀                 ⠀⠈⠢⣄⠀⡈⠒⠊⠉⠁⠀⠈⠉⠑⠚⠀⠀⣀⠔⢊⣠⠤⠒⠊⠉⠀⡜
⠀⠀⠀⠀⠀⠀                  ⠀⡽⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠩⡔⠊⠁⠀⠀⠀⠀⠀⠀⠇
⠀⠀⠀⠀⠀⠀⠀                  ⡇⢠⡤⢄⠀⠀⠀⠀⠀⡠⢤⣄⠀⡇⠀⠀⠀⠀⠀⠀⠀⢰⠀
⠀⠀⠀⠀⠀⠀                  ⢀⠇⠹⠿⠟⠀⠀⠤⠀⠀⠻⠿⠟⠀⣇⠀⠀⡀⠠⠄⠒⠊⠁⠀
⠀⠀⠀⠀⠀⠀                  ⢸⣿⣿⡆⠀⠰⠤⠖⠦⠴⠀⢀⣶⣿⣿⠀⠙⢄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀                  ⠀⠀⢻⣿⠃⠀⠀⠀⠀⠀⠀⠀⠈⠿⡿⠛⢄⠀⠀⠱⣄⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀                  ⢸⠈⠓⠦⠀⣀⣀⣀⠀⡠⠴⠊⠹⡞⣁⠤⠒⠉⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀                  ⣠⠃⠀⠀⠀⠀⡌⠉⠉⡤⠀⠀⠀⠀⢻⠿⠆⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀                  ⠰⠁⡀⠀⠀⠀⠀⢸⠀⢰⠃⠀⠀⠀⢠⠀⢣⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀                  ⠀⢶⣗⠧⡀⢳⠀⠀⠀⠀⢸⣀⣸⠀⠀⠀⢀⡜⠀⣸⢤⣶⠀⠀⠀⠀⠀⠀
⠀⠀⠀                  ⠈⠻⣿⣦⣈⣧⡀⠀⠀⢸⣿⣿⠀⠀⢀⣼⡀⣨⣿⡿⠁⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀                   ⠈⠻⠿⠿⠓⠄⠤⠘⠉⠙⠤⢀⠾⠿⣿⠟⠋

 _    _                                                  _  _      _     _  _
| |  | |                                                | |(_)    | |   (_)| |
| |  | |  ___  __      __    _   _   ___   _   _      __| | _   __| |    _ | |_
| |/\| | / _ \ \ \ /\ / /   | | | | / _ \ | | | |    / _` || | / _` |   | || __|
\  /\  /| (_) | \ V  V /    | |_| || (_) || |_| |   | (_| || || (_| |   | || |_
 \/  \/  \___/   \_/\_/      \__, | \___/  \__,_|    \__,_||_| \__,_|   |_| \__|
                              __/ |
                             |___/
";
    }

    private static void DisplayAsciiArt(string asciiArt)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine(asciiArt);
    }
}