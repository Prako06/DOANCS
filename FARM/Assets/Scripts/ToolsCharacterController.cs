using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController character;
    Rigidbody2D rb;
    ToolBarController toolbarController;
    Animator animator;
    [SerializeField] MarkerManager markerManager;
    [SerializeField] TileMapController TileMapController;
    [SerializeField] float maxDistance = 1.5f;
    

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolBarController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if (Input.GetMouseButtonDown(0))
        {
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = TileMapController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition,cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolbarController.GetItem;
            if (item == null) { return; }
            if (item.onTileMapAction == null) { return; }

            animator.SetTrigger("act");
            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, TileMapController);

            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    animator.ResetTrigger("act");
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }
            }
        }
    }
}
