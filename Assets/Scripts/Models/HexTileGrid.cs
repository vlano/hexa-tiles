using UnityEngine;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class HexTileGrid
    {
        public float TileSize;
        public float TilePadding;
        [JsonProperty("DefaultTileColor")] public string DefaultTileColorString;
        public HexTile[] Tiles;
        public Color DefaultTileColor;

        public HexTileGrid(float tileSize = 0f, float tilePadding = 0f, string defaultTileColor = default,
            HexTile[] tiles = default)
        {
            TileSize = tileSize;
            TilePadding = tilePadding;
            DefaultTileColorString = defaultTileColor;
            Tiles = tiles;

            ColorUtility.TryParseHtmlString($"#{DefaultTileColor}", out DefaultTileColor);
        }
    }
}