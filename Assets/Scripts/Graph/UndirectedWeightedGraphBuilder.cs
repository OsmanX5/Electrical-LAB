using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraphBuilder : UndirectedWeightedGraph
{
    
    public void AddNewPoint(int a)
    {
        AdjacencyList[a] = new List<Edge>();
        n += 1;
    }
    public void AddConnection(int a, int b, float w)
    {
        if (!IsInGraph(a)) { Debug.LogError("Point " + a + " is not in graph"); return; }
        if (!IsInGraph(b)) { Debug.LogError("Point " + b + " is not in graph"); return; }
        if (a == b) { Debug.LogError("Can't connect point to itself"); return; }
        var edge2B = new Edge(b, w);
        var edge2A = new Edge(a, w);
        if (! IsInList(GetPointConnections(a), edge2B))
            AdjacencyList[a].Add(new Edge(b, w));
        if (!IsInList(GetPointConnections(b), edge2A))
            AdjacencyList[b].Add(edge2A);
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
