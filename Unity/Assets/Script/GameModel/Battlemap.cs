using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Battlemap : MonoSingleton<Battlemap>
{
    public Tilemap _TileMap;

    public void TileUp(Vector2 worldPos) {

        int x = _TileMap.WorldToCell(worldPos).x;
        int y = _TileMap.WorldToCell(worldPos).y;

        Vector3Int tileVector = new Vector3Int(x, y, 0);
        _TileMap.SetTileFlags(tileVector, TileFlags.None);
        _TileMap.SetColor(tileVector, Color.red);
        
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
