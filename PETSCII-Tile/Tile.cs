using System.Collections.Generic;

namespace PETSCIITile.Framework
{
    public class Tile
    {
        // Base properties
        public char AsciiSymbol { get; private set; }
        public string GraphicAssetPath { get; private set; } // Replace with proper graphic asset data if using SFML sprites or textures

        // Modular properties stored in a dictionary
        private Dictionary<string, object> properties;

        public Tile(char asciiSymbol, string graphicAssetPath)
        {
            AsciiSymbol = asciiSymbol;
            GraphicAssetPath = graphicAssetPath;
            properties = new Dictionary<string, object>();

        }

        // Method to add or modify a modular property
        public void SetProperty(string key, object value)
        {
            properties[key] = value;
        }

        // Method to get a modular property; returns null if the property doesn't exist
        public object GetProperty(string key)
        {
            if (properties.TryGetValue(key, out object value))
            {
                return value;
            }
            return null;
        }

        // Method to remove a modular property
        public bool RemoveProperty(string key)
        {
            return properties.Remove(key);
        }
    }
}
