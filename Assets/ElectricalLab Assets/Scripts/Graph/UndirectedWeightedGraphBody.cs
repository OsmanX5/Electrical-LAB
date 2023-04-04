using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Edge
{
    public int NextPoint;
    public float Weight;
    public Edge(int next, float weight)
    {
        NextPoint = next;
        Weight = weight;
    }
    public override string ToString()
    {
        return $"({NextPoint},{Weight})";
    }
}
public class UndirectedWeightedGraphBody 
{
    protected int n = 0;
    protected Dictionary<int, List<Edge>> AdjacencyList = new Dictionary<int, List<Edge>>();

    public List<Edge> GetPointConnections(int a)=> AdjacencyList[a];

    public bool IsInList(List<Edge> list, int a)
    {
        foreach (var edge in list)
        {
            if (edge.NextPoint == a) return true;
        }
        return false;
    }
    public bool IsInGraph(int a) => AdjacencyList.ContainsKey(a);
    public bool IsConnected(int a,int b)
    {
        if (IsInList(AdjacencyList[a], b)) return true;
        if (IsInList(AdjacencyList[b], a)) return true;
        return false;
    }

    public Dictionary<int, List<Edge>> GetAdjacencyList() => AdjacencyList;
    public string GetAdjacencyListSTR()
    {
        string str = "";
        foreach (var item in AdjacencyList)
        {
            str += item.Key + " : ";
            foreach (var edge in item.Value)
            {
                str += "( " + edge.NextPoint + " " + edge.Weight + " ) ";
            }
            str += "\n";
        }
        return str;
    }

}
