using PETSCIITile.Framework;

namespace DemoGame
{
    public class DemoGame
    {
        private static void Main()
        {
            // Initialize your tile-based game framework objects and resources here
            // ...

            // Create a map with tiles and entities using your framework
            Tile[,] map = InitializeMap(); // Replace InitializeMap() with your map setup method

            // Create the game object using your framework
            Game game = new Game(windowWidth: 800, windowHeight: 600, windowTitle: "Demo Game", initialMap: map, tileSize: 16);

            // Run the game loop
            game.Run();
        }

        // Replace this method with your own map setup logic using your tile-based game framework
        private static Tile[,] InitializeMap()
        {
            // Create a 2D array of Tile objects representing your game map
            // For simplicity, you can create a simple map manually here, or generate it procedurally using your framework's map generation capabilities.

            // Example: creating a 5x5 map with some basic tiles and setting the TileSize
            int tileSize = 32; // Set the desired size of each tile in pixels
            Tile[,] map = new Tile[5, 5];

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    char asciiSymbol = 'X';
                    string graphicAssetPath = null; // Set this to your graphical asset path if using SFML sprites or textures
                    map[x, y] = new Tile(asciiSymbol, graphicAssetPath);
                }
            }


            // Customize the map by adding properties to specific tiles, e.g., walls, entities, etc.

            // map[2, 2].SetProperty("Wall", true);
            // map[3, 3].SetProperty("Entity", "Player");

            return map;
        }
    }
}
