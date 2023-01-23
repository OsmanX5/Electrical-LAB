using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Edge
{
    public int NextPoint;
    public float Weight;
    public Edge(int next, float weight)
    {
        NextPoint = next;
        Weight = weight;
    }
}
public class UndirectedWeightedGraph 
{
    protected int n = 0;
    protected Dictionary<int, List<Edge>> AdjacencyList = new();

    public List<Edge> GetPointConnections(int a)=> AdjacencyList[a];

    public bool IsInList(List<Edge> list, Edge a)
    {
        foreach (var edge in list)
        {
            if (edge.NextPoint == a.NextPoint) return true;
        }
        return false;
    }
    public bool IsInGraph(int a) => AdjacencyList.ContainsKey(a);




}
