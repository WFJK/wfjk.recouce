using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCompute : MonoBehaviour
{
    public TileManager TileManager; 

    public Vector2Int startPoint;


    public Vector2Int overPoint;


    public void rotateMN(int angle, Vector2Int[] shape)
    {
        if (angle / 90 == 1)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                int naka = shape[i].x;
                shape[i].x = shape[i].y;
                shape[i].y = -naka;
            }
        }
        if (angle / 90 == 2)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                shape[i].x = -shape[i].x;
                shape[i].y = -shape[i].y;
            }
        }
        if (angle / 90 == 3)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                int naka = shape[i].x;
                shape[i].x = -shape[i].y;
                shape[i].y = naka;
            }
        }
    }

    public void startToEnd() 
    { 
        
    }



    public Vector2Int[] ComputeATKRange(Vector2Int[] atkRange,Vector2Int atkSoucePosition) 
    {
        Vector2Int[] atkPosition=new Vector2Int[atkRange.Length];
        for (int i = 0; i < atkRange.Length; i++) 
        {
            atkPosition[i] = atkRange[i] + atkSoucePosition;
        }
        return atkPosition;
    }
    public void ComputeMoveRange()
    {

    }
    public void addMNInTiles(TileMN tileMN) 
    {
        for (int i = 0; i < tileMN.shape.Length; i++) 
        {
            if (TileManager.isInCellsRange(tileMN.shape[i]) && !TileManager.isTileOccupyByMN(tileMN.shape[i])) 
            {
                TileManager.addMNToTiles(tileMN);
            }
            else
            {
                Debug.Log($"坐标{tileMN.shape[i]}有问题");
            }
        }

    }








}
