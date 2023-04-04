using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraphBuilder : UndirectedWeightedGraphBody
{
    
    public void AddNewPoint(int a)
    {
        AdjacencyList[a] = new List<Edge>();
        n += 1;
    }
    public void AddConnection(int a, int b, float w)
    {
        if (!IsInGraph(a)) { Debug.LogWarning("Point " + a + " is not in graph"); return; }
        if (!IsInGraph(b)) { Debug.LogWarning("Point " + b + " is not in graph"); return; }
        if (a == b) { Debug.LogWarning("Can't connect point to itself"); return; }
        if (IsConnected(a, b)) { Debug.LogWarning("Points are already connected"); return; }
        AdjacencyList[a].Add(new Edge(b, w));
        AdjacencyList[b].Add(new Edge(a, w));
    }
    public void RemovePoint(int a)
    {
        ClearPoint(a);
        AdjacencyList.Remove(a);
    }
    public void ClearPoint(int a)
    {
        if (!IsInGraph(a)){ Debug.LogError("Point " + a + " is not in graph"); return; }
        foreach (var edge in GetPointConnections(a))
        {
            AdjacencyList[edge.NextPoint] = (from connection in AdjacencyList[edge.NextPoint] 
                                            where connection.NextPoint != a 
                                            select connection).ToList();
        }
        AdjacencyList[a] = new List<Edge>();
    }
}
