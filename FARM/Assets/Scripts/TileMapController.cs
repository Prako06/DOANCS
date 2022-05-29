using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    public CropsManager cropsManager;
   
    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 wordPosition;
        if (mousePosition)
        {
            wordPosition = Camera.main.ScreenToWorldPoint(position);
        }
        else
        {
            wordPosition = position;
        }

        Vector3Int gridPosition = tilemap.WorldToCell(wordPosition);

        return gridPosition;
    }

    public TileBase GetTileBase(Vector3Int gridPosition, bool mousePosition = false)
    {      
        TileBase tile = tilemap.GetTile(gridPosition);

        return tile;
    }
}
