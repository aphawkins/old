namespace MonoLife.Client
{
    using System;
    using SDL2;

    public class DisplayManager
    {
        protected static IntPtr window;
        protected static uint windowID;
        protected static IntPtr context;
        protected static bool isClosed = false;

        public static void CreateDisplay(string title, int width, int height)
        {
            if (SDL.SDL_Init(SDL.SDL_INIT_EVERYTHING) != 0)
            {
                Console.WriteLine("SDL_Init Error:", SDL.SDL_GetError());
            }

            window = SDL.SDL_CreateWindow(title, SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, width, height, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
            windowID = SDL.SDL_GetWindowID(window);

            _ = SDL.SDL_GL_CreateContext(window);
        }

        public static void UpdateDisplay()
        {
            SDL.SDL_GL_SwapWindow(window);
            _ = SDL.SDL_UpdateWindowSurface(window);
        }

        public static bool WaitForClose => isClosed;

        public static void InputDisplay(SDL.SDL_Event evt)
        {
            while (SDL.SDL_PollEvent(out evt) != 0)
            {
                if (evt.type == SDL.SDL_EventType.SDL_QUIT)
                {
                    isClosed = true;
                    break;
                }

                if (evt.type == SDL.SDL_EventType.SDL_KEYDOWN)
                {
                    if (evt.key.keysym.sym == SDL.SDL_Keycode.SDLK_ESCAPE)
                    {
                        isClosed = true;
                        break;
                    }
                }

                if (evt.window.windowEvent == SDL.SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED)
                {
                    _ = evt.window.data1;
                    _ = evt.window.data2;
                }
            }
        }

        public static void DestoryDisplay()
        {
            //SDL.SDL_GL_DeleteContext(context);
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }
    }
}