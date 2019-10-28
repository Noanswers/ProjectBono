using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Battlemap : MonoSingleton<Battlemap>
{
    public Tilemap _TileMap;

    Dictionary<Color, Vector3Int> _colorTiles = new Dictionary<Color, Vector3Int>();
    public void TileUpColor(Vector2 worldPos, Color color) {

        int x = _TileMap.WorldToCell(worldPos).x;
        int y = _TileMap.WorldToCell(worldPos).y;

        Vector3Int tileVector = new Vector3Int(x, y, 0);
        _TileMap.SetTileFlags(tileVector, TileFlags.None);

        if (_colorTiles.ContainsKey(color)) {
            if (_colorTiles[color] != tileVector) {
                _TileMap.SetColor(_colorTiles[color], Color.white);
                _colorTiles[color] = tileVector;
            }
        } else {
            _colorTiles.Add(color, tileVector);
        }
        _TileMap.SetColor(tileVector, color);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
