using UnityEngine;


namespace Models
{
    [System.Serializable]
    public class HexTile
    {
        public int Index;
        public string ClickedColorString;
        public Color ClickedColor;
        
        public HexTile(int index = -1, string clickedColor = default)
        {
            Index = index;
            ClickedColorString = clickedColor;

            ColorUtility.TryParseHtmlString($"#{ClickedColorString}", out ClickedColor);
        }
    }
}