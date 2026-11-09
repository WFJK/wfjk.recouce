using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public int TileLong;
    public int TileWide;

    public Tile tile;
    public GameObject highLight;

    public void createTile() 
    {
        for (int i = 0; i < TileLong; i++)
        {
            for (int j = 0; j< TileWide;j++) 
            { 
                Vector2 vector2 = new Vector2(i,j);
                Instantiate(tile, vector2, Quaternion.identity);
            }
        }
    }
























}
