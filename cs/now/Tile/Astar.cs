using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class Astar : MonoBehaviour
{
    public List<node> posibleNodes=new List<node>();
    public List<node> happenNodes=new List<node>();
    public List<Vector2Int> finalPath = new List<Vector2Int>();
    public Vector2Int[] adjacentCells = new Vector2Int[]
    {
        Vector2Int.up,Vector2Int.down,Vector2Int.left,Vector2Int.right
    };
    public Vector2Int StartPosition;
    public Vector2Int EndPosition;

    private void Start()
    {
        RunAstar();
    }

    public void RunAstar()
    {
        posibleNodes.Clear();
        happenNodes.Clear();
        finalPath.Clear();
        node startNode = createfirstNode(StartPosition, EndPosition);
        posibleNodes.Add(startNode);
        node resultNode = null;
        while (posibleNodes.Count > 0)
        {
            node current = getBestNode();
            posibleNodes.Remove(current);
            happenNodes.Add(current);
            if (current.vector == EndPosition)
            {
                resultNode = current;
                break;
            }
            addNewAdjacent(EndPosition, current);
        }
        if (resultNode != null)
        {
            result(resultNode);
            Debug.Log("寻路成功！");
        }
        else
        {
            Debug.Log("无路可走");
        }
    }
    public node createfirstNode(Vector2Int start, Vector2Int end) 
    {
        return new node(null, 0, Vector2.Distance(start, end), start);
    }
    public void addNewAdjacent(Vector2Int end, node FatherNode) 
    {
        for (int i = 0; i < adjacentCells.Length; i++) 
        {
            Vector2Int NodeVector = FatherNode.vector + adjacentCells[i];
            if (IsInList(happenNodes, NodeVector)) continue;
            float distenceToFather = FatherNode.distenceToFather + Vector2.Distance(FatherNode.vector, NodeVector);
            float distenceToEnd=Vector2.Distance(end, NodeVector);
            if (!IsInList(posibleNodes, NodeVector))
            {
                posibleNodes.Add(new node(FatherNode, distenceToFather, distenceToEnd, NodeVector));
            }
            else 
            {
                var oldNode = GetNodeByPos(posibleNodes, NodeVector);
                if (distenceToFather < oldNode.distenceToFather)
                {
                    oldNode.beforeThisNode = FatherNode;
                    oldNode.distenceToFather = distenceToFather;
                }
            }

        }
    }
    public node getBestNode() 
    {
        node best = posibleNodes[0];
        foreach (var n in posibleNodes)
        {
            if (n.TotalDistence < best.TotalDistence)
            {
                best = n;
            }
        }
        return best;
    }
    public bool IsInList(List<node> list, Vector2Int pos)
    {
        foreach (var n in list)
        {
            if (n.vector == pos) return true;
        }
        return false;
    }
    public node GetNodeByPos(List<node> list, Vector2Int pos)
    {
        foreach (var n in list)
        {
            if (n.vector == pos) return n;
        }
        return null;
    }
    public void result(node resultNode) 
    {
        while (resultNode != null)
        {
            finalPath.Add(resultNode.vector);
            resultNode = resultNode.beforeThisNode;
        }
        finalPath.Reverse();
        // 打印路径
        foreach (var p in finalPath)
        {
            Debug.Log(p);
        }
    }






}
[Serializable]
public class node 
{
    public Vector2Int vector;
    public float distenceToFather;
    public float distenceToEnd;
    public float TotalDistence;
    public node beforeThisNode;
    public node(node FatherNode, float routeToFather, float routeToEnd, Vector2Int Nodevector) 
    { 
        beforeThisNode = FatherNode;
        distenceToFather = routeToFather;
        distenceToEnd = routeToEnd;
        TotalDistence = routeToFather + distenceToEnd;
        vector = Nodevector;
    }


}