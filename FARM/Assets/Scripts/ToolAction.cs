using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{
    public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapController tileMapController, Item item)
    {
        Debug.LogWarning("OnApplyToTileMap is not implemented");
        return true;
    }

    public virtual void OnItemUsed(Item usedItem, ItemContainer inventory)
    {

    }

    public virtual void OnItemAdd(Item addItem , ItemContainer inventory)
    {

    }
}
