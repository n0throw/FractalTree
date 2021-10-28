using SFML.Graphics;
using SFML.Window;

using System;

namespace FractalTree
{
    class Program
    {
        private static RenderWindow window;
        private static Game game;
        private static string error = "";

        static void Main(string[] args)
        {
            Init(args);

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Black);
                window.Draw(new Text()
                {
                    FillColor = Color.Red,
                    DisplayedString = error,
                    Font = new Font($"{Environment.CurrentDirectory}\\Font.otf"),
                    CharacterSize = 20
                });
                window.Draw(game);
                window.Display();
            }
        }

        private static void Init(string[] args)
        {
            window = new(new VideoMode(1200, 1200), "Fractal Tree");
            game = new Game(new Creator(LoadSettings(args)));

            window.SetFramerateLimit(60u);
            AddEvent();
        }

        private static Settings LoadSettings(string[] args)
        {
            try
            {
                if (args.Length != 0)
                {
                    return Settings.LoadJson(args[0]);
                }
                else
                    throw new Exception("");
            }
            catch (Exception ex)
            {
                error = ex.Message;
                Console.WriteLine(error);
                return Settings.GetDefaulthSettings();
            }
        }

        private static void AddEvent()
        {
            window.Closed += (_, __) => window.Close();
            window.KeyPressed += Window_KeyPressed;
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
                window.Close();
        }
    }
}
