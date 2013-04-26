using System;

namespace AngryPigs
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Kernel game = Kernel.Instance)   // access static property to create new instance of Kernel - enforces singleton pattern
            {
                game.Run();
            }
        }
    }
#endif
}

