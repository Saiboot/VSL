using System;

/****
 *   Don't touch this file unless you absolutely need to. 
 ******/

namespace VSL
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new VSL())
                game.Run();
        }
    }
#endif
}
