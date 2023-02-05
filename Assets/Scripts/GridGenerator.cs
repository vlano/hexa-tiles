using System;
using Models;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{ 
    [SerializeField] private TileBehaviour _hexPrefab;
    [SerializeField] private Transform _gridContainer;

    private Vector2 _hexSize;
    private HexTileGrid _grid;
    
    
    public void GenerateGrid(HexTileGrid grid)
    {
        _grid = grid;

        var pref = CreateTile(grid.Tiles[0],Vector3.zero);
        _hexSize = GetRendererSize(pref.gameObject.GetComponent<Renderer>());
        
        for (int i = 0; i < 6; i++)
        {
            var pos = GetPositionAroundCircle(i, 6) * _hexSize.y * (1 + _grid.TilePadding);

            CreateTile(grid.Tiles[i+1],pos);
        }
       
        if(grid.Tiles.Length <= 7)
            return;
        
        //current limit is 2 outer rings, for more rings we would need to introduce a more dynamic correction on the tiles that are being generated
        for (int i = 0; i < 12; i++)
        {
            Vector3 pos;
            if (i % 2 == 0)
                pos = GetPositionAroundCircle(i, 12) * _hexSize.y * 2 * (1 + _grid.TilePadding);

            else
                pos = GetPositionAroundCircle(i, 12) * 0.75f * (1 + _grid.TilePadding);
            
            CreateTile(grid.Tiles[7+i],pos);
        }
    }

    private Vector2 GetRendererSize(Renderer rend)
    {
       var bounds = rend.bounds;
       return new Vector2(bounds.size.x,bounds.size.z);
    }

    private Vector3 GetPositionAroundCircle(int number, int segments)
    {
       var angle = 2 * Mathf.PI / segments * number;
       var horizontal = MathF.Cos(angle);
       var vertical = MathF.Sin(angle);
       
       return new Vector3(vertical, 0, horizontal);
    }

    private TileBehaviour CreateTile(HexTile tile, Vector3 pos)
    {
        var hex = Instantiate(_hexPrefab,pos,Quaternion.identity,_gridContainer);
        hex.Init(tile.Index,_grid.DefaultTileColor,tile.ClickedColor);
        return hex;
    }
}
