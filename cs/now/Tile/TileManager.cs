using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
[Serializable]
public class TileManager : MonoBehaviour
{
    public int TotalTileLong = 5;
    public int TotalTileWide = 4;

    public GameObject tile;
    public GameObject highLight;

    public readonly int[,] TotalTileCells=new int[5,4];

    public readonly Tile[,] TileCells = new Tile[5, 4];

    public TileMN[,] MNCells = new TileMN[5, 4];

    public  TileAlive[,] Alive = new TileAlive[5, 4];

    public Vector2Int[] adjacentCells = new Vector2Int[]
    {
        Vector2Int.up,Vector2Int.down,Vector2Int.left,Vector2Int.right
    };
    private void Start()
    {
        createTile(TotalTileLong, TotalTileWide);
        //Debug.Log(math.cos(90));
    }


    public void createTile(int Long,int Wide) 
    {
        for (int i = 0; i < TotalTileLong; i++)
        {
            for (int j = 0; j< TotalTileWide; j++) 
            {
                Vector2 vector2= new Vector2(i, j);
                Instantiate(tile, vector2, Quaternion.identity);
            }
        }
    }
    public bool isInCellsRange(Vector2Int vector2Int) 
    {
        if (vector2Int.x < 0 && vector2Int.y < 0){ return false; }
        if (vector2Int.x < TotalTileLong && vector2Int.y < TotalTileWide) { return false; }
        return true;
    }
    public bool isTileOccupyByMN(Vector2Int vector2) 
    {
        if (MNCells[vector2.x, vector2.y] == null) 
        {
            return false;
        }
        return true;
    }
    public void addMNToTiles(TileMN tileMN)
    {
        for (int i = 0; i < tileMN.shape.Length; i++) 
        {
            MNCells[tileMN.shape[i].x, tileMN.shape[i].y] = tileMN;
        }
    }
    public void removeOccupyMNToTiles(TileMN tileMN) 
    {
        for (int i = 0; i < tileMN.shape.Length; i++)
        {
            MNCells[tileMN.shape[i].x, tileMN.shape[i].y] = null;
        }
    }




















}
