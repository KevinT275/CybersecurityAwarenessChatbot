using System;
using System.Media;      // Used for playing sound (voice greeting)
using System.Threading;  // Used for typing effect delay

class Program
{
    static void Main()
    {
        // Set console title and colour
        Console.Title = "Cybersecurity Awareness Bot";
        Console.ForegroundColor = ConsoleColor.Cyan;

        // Play voice greeting and display ASCII logo
        PlayVoiceGreeting();
        ShowAsciiArt();

        // Welcome message
        Console.WriteLine("\nWelcome to the Cybersecurity Awareness Bot!");
        Console.Write("\nPlease enter your name: ");

        // Read user name (?? "" prevents null errors)
        string name = Console.ReadLine() ?? "";

        // Input validation: ensure name is not empty
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("Name cannot be empty. Please enter your name: ");
            name = Console.ReadLine() ?? "";
        }

        // Personalised greeting
        Console.WriteLine($"\nHello, {name}! I'm here to help you stay safe online.\n");

        // Start chatbot interaction
        ChatLoop();
    }

    // Method to play voice greeting when program starts
    static void PlayVoiceGreeting()
    {
        try
        {
            // Get full path to WAV file
            string path = AppDomain.CurrentDomain.BaseDirectory + "greeting.wav";

            // Check if file exists before playing
            if (System.IO.File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync(); // Play sound and wait until finished
            }
            else
            {
                Console.WriteLine("(Voice file not found)");
            }
        }
        catch (Exception ex)
        {
            // Handle any errors when playing sound
            Console.WriteLine("(Error playing audio: " + ex.Message + ")");
        }
    }

    // Method to display ASCII art logo
    static void ShowAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine(@"
   ____       _                 ____        _   
  / ___| ___ | |__   ___ _ __  | __ )  ___ | |_ 
 | |  _ / _ \| '_ \ / _ \ '__| |  _ \ / _ \| __|
 | |_| | (_) | |_) |  __/ |    | |_) | (_) | |_ 
  \____|\___/|_.__/ \___|_|    |____/ \___/ \__|

   CYBERSECURITY AWARENESS BOT
        ");

        Console.ResetColor(); // Reset colour back to default
    }

    // Main chatbot loop (runs until user types "exit")
    static void ChatLoop()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nYou: ");

            // Read user input and convert to lowercase
            string input = (Console.ReadLine() ?? "").ToLower();

            // Handle empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Bot: I didn’t quite understand that. Could you rephrase?");
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            // Predefined chatbot responses
            if (input.Contains("how are you"))
            {
                TypeText("Bot: I'm just a program, but I'm here to help you!");
            }
            else if (input.Contains("purpose"))
            {
                TypeText("Bot: My purpose is to educate you about cybersecurity and keep you safe online.");
            }
            else if (input.Contains("password"))
            {
                TypeText("Bot: Use strong passwords with letters, numbers, and symbols. Never share them!");
            }
            else if (input.Contains("phishing"))
            {
                TypeText("Bot: Phishing is when scammers trick you into giving personal info. Always check links!");
            }
            else if (input.Contains("safe browsing"))
            {
                TypeText("Bot: Use secure websites (https), avoid unknown downloads, and update your browser.");
            }
            else if (input.Contains("exit"))
            {
                TypeText("Bot: Goodbye! Stay safe online 👋");
                break; // Exit loop and end program
            }
            else
            {
                // Default response if input not recognised
                TypeText("Bot: I didn’t understand that. Ask about passwords, phishing, or safe browsing.");
            }
        }
    }

    // Method to simulate typing effect
    static void TypeText(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(20); // Delay between characters
        }
        Console.WriteLine();
    }
}