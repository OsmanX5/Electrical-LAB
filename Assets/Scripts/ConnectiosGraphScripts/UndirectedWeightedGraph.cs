using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraph 
{
    protected int n = 0;
    public Dictionary<int,List<Tuple<int, float>>> AdjacencyList = new Dictionary<int, List<Tuple<int, float>>>();

    public bool IsInGraph(int a)=> AdjacencyList.ContainsKey(a);

    public List<Tuple<int,float>> GetPointConnections(int a)=>AdjacencyList[a];

    public bool IsInList(List<Tuple<int, float>> list, Tuple<int, float> a)
    {
        foreach (var point in list)
        {
            if (point.Item1 == a.Item1) return true;
        }
        return false;
    }

    

    
}
