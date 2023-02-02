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
        return new UndirectedWeightedGraph()
        {
            AdjacencyList = new Dictionary<int, List<Edge>>(AdjacencyList),
            n = n
        };
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        string result = "";
        result += "Graph: \n" +GetAdjacencyListSTR();
        return result;
    }
}
