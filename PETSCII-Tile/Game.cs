using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.IO;

namespace PETSCIITile.Framework
{
    public class Game
    {
        private RenderWindow window;
        private bool isRunning;

        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }
        public Font CurrentFont { get; private set; }

        private Tile[,] map; // 2D array representing the map tiles
        private Renderer renderer; // The renderer for the map

        public Game(int windowWidth, int windowHeight, string windowTitle, Tile[,] initialMap, int tileSize)
        {
            WindowWidth = windowWidth;
            WindowHeight = windowHeight;

            // Create the SFML window
            window = new RenderWindow(new VideoMode((uint)windowWidth, (uint)windowHeight), windowTitle);

            // Load the font using a MemoryStream
            byte[] fontData;
            using (var fontStream = new FileStream("stuff/PixeloidSans.ttf", FileMode.Open))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fontStream.CopyTo(memoryStream);
                    fontData = memoryStream.ToArray();
                }
            }

            CurrentFont = new Font(fontData);

            // Set the initial map
            map = initialMap;

            // Initialize the map renderer with the TileSize
            renderer = new Renderer(window, map, tileSize);

            isRunning = true;
        }

        public void Run()
        {
            const int targetFramerate = 60;
            const float frameTime = 1f / targetFramerate;
            Clock clock = new Clock();
            window.Closed += (sender, e) => isRunning = false; // Set isRunning to false when the window is closed

            while (isRunning)
            {
                window.DispatchEvents();

                // Handle input
                HandleInput();

                // Update game state
                Update();

                // Render the game world
                Render();

                window.Display();

                // Limit the frame rate
                float elapsed = clock.Restart().AsSeconds();
                if (elapsed < frameTime)
                {
                    // Delay to control the frame rate
                    System.Threading.Thread.Sleep((int)((frameTime - elapsed) * 1000));
                }
            }
        }


        private void HandleInput()
        {
            // Handle user input here, e.g., keyboard, mouse, etc.
            // ...
        }

        private void Update()
        {
            // Update the game state here, e.g., entities, collisions, etc.
            // ...
        }

        private void Render()
        {
            // Clear the window
            window.Clear(Color.Black);

            // Draw the game world here, including the Tile renderer, entities, UI, etc.
            renderer.Render(CurrentFont);

            // Optionally, you can add additional rendering logic for entities, UI, etc.
            // ...

            // No need to call window.Display() here, as it's done in the Run() method
        }
    }
}
