using SFML.Graphics;
using SFML.System;

namespace PETSCIITile.Framework
{
    public class Renderer
    {
        private RenderWindow window;
        private Tile[,] tiles; // 2D array representing the map tiles

        // Set the size of each tile (in pixels)
        public int TileSize { get; private set; }

        public Renderer(RenderWindow window, Tile[,] tiles, int tilesize)
        {
            this.window = window;
            this.tiles = tiles;
            this.TileSize = tilesize;
        }
        

        public void Render(Font font)
        {

            // Render the map
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    // Calculate the position for each tile based on its index
                    Vector2f tilePosition = new Vector2f(x * TileSize, y * TileSize);

                    // Get the character or graphical representation for the tile
                    char tileChar = tiles[x, y].AsciiSymbol; // Or use tiles[x, y].Sprite if you have graphical tiles

                    // Render the tile (ASCII representation)
                    Text tileText = new Text(tileChar.ToString(), font, 20);
                    tileText.Position = tilePosition;
                    tileText.Color = Color.White;
                    window.Draw(tileText);

                    // Render entities or other visuals on the tile
                    // ...

                    // You can add additional rendering logic based on the properties of the tile and its entities
                }
            }

            
        }
    }
}
