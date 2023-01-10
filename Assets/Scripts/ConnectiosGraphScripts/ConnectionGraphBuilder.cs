using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    void addNewPointToGraph(Point newPoint)
    {
        if (ConnectionGraph.AdjacencyList.ContainsKey(newPoint)){
            Debug.Log("this point is already here");
            return;
        }
        ConnectionGraph.AdjacencyList.Add(newPoint,new List<ConnectioPoint>());
        ConnectionGraph.nodesCount += 1;
    }
    void addNewConnectioBetween2NodesInGraph(Point a,Point b)
    {
        if (ConnectionGraph.AdjacencyList.ContainsKey(a) == false)
            addNewPointToGraph(a);
        if (ConnectionGraph.AdjacencyList.ContainsKey(b) == false)
            addNewPointToGraph(b);
        ConnectionGraph.AdjacencyList[a].Add(new ConnectioPoint(b,0));


    }
    void RemovePointFromGraph(Point point)
    {
        if(ConnectionGraph.AdjacencyList.ContainsKey(point) == false)
        {
            Debug.Log("no point like this here when try to delet");
            return;
        }
        ConnectionGraph.AdjacencyList.Remove(point);
    }
}
