using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flow : MonoBehaviour
{
    public int width = 30;
    public int height = 30;
    public float cellSize = 1f;

    public Vector2Int targetGrid;

    private Cell[,] flowField;

    private List<Cell> openList;
    // 8方向
    private readonly Vector2Int[] dir8 =
    {
        new(-1,0), new(1,0), new(0,-1), new(0,1),
        new(-1,-1), new(-1,1), new(1,-1), new(1,1)
    };

    void Start()
    {
        InitGridField();
        RunFlowField(targetGrid);
    }

    public void FlowOnEnemy(Transform transform) 
    {
        var cell = GetCellByWorldPos(transform.position);
        if (cell == null) return;
        Vector3 vector3 = new Vector3(cell.ToNextVector.x, cell.ToNextVector.y, 0);
        transform.position += vector3;
    }
    void InitGridField()// 初始化cost=1,distance=999,到下一个格子的向量=0
    {
        flowField = new Cell[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                flowField[x, y] = new Cell(new Vector2Int(x, y), 1, int.MaxValue, Vector2Int.zero);
            }
        }
    }

    public void RunFlowField(Vector2Int target)//给每个格子赋值
    {
        ResetDistance();
        openList = new List<Cell>();

        Cell targetCell = flowField[target.x, target.y];
        targetCell.distance = 0;
        openList.Add(targetCell);

        while (openList.Count > 0)
        {
            Cell ClosestCell = FindClosestCell();
            foreach (Cell neighbor in NeighborsList(ClosestCell))
            {
                int newDist = ClosestCell.distance + neighbor.cost;
                if (newDist < neighbor.distance)
                {
                    neighbor.distance = newDist;
                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }
        computeToNextVector();
    }
    Cell FindClosestCell()
    {
        Cell best = openList[0];
        foreach (var c in openList)
        {
            if (c.distance < best.distance) best = c;
        }
        openList.Remove(best);
        return best;
    }
    public List<Cell> NeighborsList(Cell cell) 
    {
        List<Cell> res = new List<Cell>();
        for (int i=0; i<dir8.Length;i++)
        {
            Vector2Int nextvector = cell.gridPos + dir8[i];
            if (IsInRange(nextvector))
            {
                res.Add(flowField[nextvector.x,nextvector.y]);
            }
        
        }
        return res;
    }

    void computeToNextVector()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = flowField[x, y];
                // 墙跳过
                if (cell.cost >= 9999) continue;

                Cell bestNeighbor = null;
                int minDist = cell.distance;

                // 找邻居里距离最小的那一个
                foreach (var Neighbor in NeighborsList(cell))
                {
                    if (Neighbor.distance < minDist)
                    {
                        minDist = Neighbor.distance;
                        bestNeighbor = Neighbor;
                    }
                }
                if (bestNeighbor != null)
                {
                    // 向量 = 邻居格子坐标 - 当前格子坐标
                    Vector2Int dir = bestNeighbor.gridPos - cell.gridPos;
                    cell.ToNextVector = dir;
                }
                Debug.Log($"坐标{flowField[x,y].gridPos},离终点的距离{ flowField[x, y].distance}，到下个格子的向量{cell.ToNextVector}");
            }
        }
    }


    // 根据世界坐标拿格子，怪物移动用
    public Cell GetCellByWorldPos(Vector2 worldPos)
    {
        int x = Mathf.RoundToInt(worldPos.x / cellSize);
        int y = Mathf.RoundToInt(worldPos.y / cellSize);
        if (x >= 0 && x < width && y >= 0 && y < height)
            return flowField[x, y];
        return null;
    }

    void ResetDistance()
    {
        foreach (var cell in flowField)
        {
            cell.distance = int.MaxValue;
            cell.ToNextVector = Vector2Int.zero;
        }
    }
    bool IsInRange(Vector2Int p)
    {
        return p.x >= 0 && p.x < width && p.y >= 0 && p.y < height;
    }
}
public class Cell
{
    public Vector2Int gridPos;   // 格子坐标
    public int cost;             // 通行代价，墙=9999
    public int distance;         // 到目标距离
    public Vector2Int ToNextVector;      // 流方向向量（重点！）
    public Cell(Vector2Int theGridPos, int theCost, int theDistance, Vector2Int theFlowDir) 
    {
        gridPos = theGridPos;
        cost = theCost;
        distance = theDistance;
        ToNextVector = theFlowDir;
    }
}