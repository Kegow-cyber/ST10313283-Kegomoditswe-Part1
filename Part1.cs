using System;

namespace CyberChatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            KegoCyberChatbot bot = new KegoCyberChatbot();
            bot.Run();
        }
    }

    class KegoCyberChatbot
    {
        private string username = "";
        private string[] topics = { "phishing", "cyber-attacks", "protecting passwords" };
        private bool running = true;

        public void Run()
        {
            DisplayLogo();
            GreetUser();
            DisplayHelp();

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{username}> ");
                Console.ResetColor();
                string input = Console.ReadLine();
                string response = Respond(input);
                if (!string.IsNullOrEmpty(response))
                {
                    Console.WriteLine(response);
                }
            }
        }

        private void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('*', 40));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  ██████╗ ██╗   ██╗███████╗██████╗ ");
            Console.WriteLine(" ██╔═══██╗██║   ██║██╔════╝██╔══██╗");
            Console.WriteLine(" ██║   ██║██║   ██║█████╗  ██████╔╝");
            Console.WriteLine(" ██║   ██║██║   ██║██╔══╝  ██╔═══╝ ");
            Console.WriteLine(" ╚██████╔╝╚██████╔╝███████╗██║     ");
            Console.WriteLine("  ╚═════╝  ╚═════╝ ╚══════╝╚═╝     ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('*', 40));
            Console.ResetColor();
        }

        private void GreetUser()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Hello! What is your name? ");
                Console.ResetColor();
                username = Console.ReadLine().Trim();
                if (!string.IsNullOrEmpty(username))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Nice to meet you, {username}! Welcome to the CYBER chatbot.\n");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name cannot be empty. Please enter your name.");
                    Console.ResetColor();
                }
            }
        }

        private void DisplayHelp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("You can ask me about the following topics:");
            foreach (var topic in topics)
            {
                Console.WriteLine($"- {topic}");
            }
            Console.WriteLine("Other queries like 'how are you?' and 'what's your purpose?' are also supported.");
            Console.WriteLine(new string('-', 50) + "\n");
            Console.ResetColor();
        }

        private string Respond(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                return "You entered nothing. Please type a question or topic.";
            }

            string lowerInput = input.ToLower();

            if (lowerInput.Contains("how are you"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.ResetColor();
                return $"I'm doing well, {username}! Thanks for asking.";
            }
            else if (lowerInput.Contains("purpose"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.ResetColor();
                return "My purpose is to educate users about cybersecurity topics like phishing, cyber-attacks, and password safety.";
            }
            else if (lowerInput.Contains("what can i ask") || lowerInput.Contains("topics"))
            {
                DisplayHelp();
                return "";
            }
            else if (lowerInput.Contains("phishing"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                return "Phishing is a cyber attack where attackers trick users into giving sensitive information, like passwords, via fake emails or websites.";
            }
            else if (lowerInput.Contains("cyber-attack") || lowerInput.Contains("cyber attack"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                return "Cyber-attacks are malicious attempts to damage or gain unauthorized access to computer systems, often using malware, ransomware, or hacking techniques.";
            }
            else if (lowerInput.Contains("password"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                return "Protecting passwords means using strong, unique passwords, enabling two-factor authentication, and avoiding password reuse across multiple sites.";
            }
            else if (lowerInput == "exit" || lowerInput == "quit")
            {
                running = false;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.ResetColor();
                return $"Goodbye, {username}! Stay safe online.";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                return "I don't quite understand that, could you rephrase?";
            }
        }
    }
}