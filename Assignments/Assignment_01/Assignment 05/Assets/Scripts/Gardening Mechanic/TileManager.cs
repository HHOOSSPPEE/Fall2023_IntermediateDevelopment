using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            //interactableMap.SetTile(position, hiddenInteractableTile);
        }
    }

    public bool IsInteractable(Vector3Int position)
    {
        //TileBase tile = interactableMap.GetTile(position);
        Vector3Int spot = new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0);
        if (position == spot)
        {
            Debug.Log("halfworks");
        }
        //if (tile != null)
        //{
        //    if (tile.name == "interact 200")
        //    {
        //        return true;
        //    }
        //}
        return false;
    }

    public void Update()
    {
        Vector3Int spot = new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0);
        TileBase tile = interactableMap.GetTile(spot);
        //Debug.Log("halfworks");
        interactableMap.SetTile(spot, hiddenInteractableTile);
    }


}

