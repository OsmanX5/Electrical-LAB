using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UndirectedWeightedGraph : UndirectedWeightedGraphPathProvider,ICloneable
{
    public UndirectedWeightedGraph()
    {
        AdjacencyList = new Dictionary<int, List<Edge>>();
    }

    public object Clone()
    {
        Dictionary<int, List<Edge>> copyDict = new Dictionary<int, List<Edge>>();
        foreach (var item in AdjacencyList)
        {
            copyDict.Add(item.Key, new List<Edge>(item.Value));
        }
        UndirectedWeightedGraph copy = new UndirectedWeightedGraph();
        copy.AdjacencyList = copyDict;
        return copy;
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        string result = "";
        result += "Graph: \n" +GetAdjacencyListSTR();
        return result;
    }
}
