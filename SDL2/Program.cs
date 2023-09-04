namespace MonoLife
{
    using System;
    using MonoLife.Client;
    using SDL2;

    internal class MainClass
    {
        protected static SDL.SDL_Event systemEvent;

        [STAThread]
        private static void Main(string[] args)
        {
            DisplayManager.CreateDisplay("Hello Game", 640, 480);
            // game initalization like GL commands for preparations or game's arguments too like for statement with if else etc..


            // end of game initalization
            while (!DisplayManager.WaitForClose)
            {
                DisplayManager.UpdateDisplay();
                // game logic


                // end of game logic
                DisplayManager.InputDisplay(systemEvent);
                // game input manager


                // end of game input managers
            }
            // destory or deletion of game logic like shader.CleanUp or model.CleanUp or GL comand GL.DeleteBuffer(vbo);


            // end of destory or deletion of game logic
            DisplayManager.DestoryDisplay();
        }
    }
}