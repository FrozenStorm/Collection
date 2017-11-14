using System;

namespace Gravitation
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //if (args.Length > 0)
            {

                //if (args[0].ToLower() == "/s")
                {
                    using (Game1 game = new Game1())
                    {
                        game.Run();
                    }
                }
            }
        }
    }
#endif
}

