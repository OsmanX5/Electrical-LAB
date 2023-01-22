using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UndirectedWeightedGraphBuilder : UndirectedWeightedGraph
{
    
    public void addPoint(int a)
    {
        AdjacencyList[a] = new List<Tuple<int, float>>();
        n += 1;
    }
    public void AddConnection(int a, int b, float w)
    {
        if (!IsInGraph(a)) addPoint(a);
        if (!IsInGraph(b)) addPoint(b);

        List<Tuple<int, float>> aConnections = AdjacencyList[a];
        List<Tuple<int, float>> bConnections = AdjacencyList[b];
        AdjacencyList[a].Add(new Tuple<int, float>(b, w));
        AdjacencyList[b].Add(new Tuple<int, float>(a, w));
    }
    public void RemovePoint(int a)
    {
        foreach (var ConnectedPoint in AdjacencyList[a])
        {
            int ConnectedPointID = ConnectedPoint.Item1;
            var ConnectionAfterRemoving = (from point in AdjacencyList[ConnectedPointID]
                                           where point.Item1 != a
                                           select point).ToList();
            AdjacencyList[ConnectedPointID] = ConnectionAfterRemoving;
        }
        AdjacencyList.Remove(a);
    }
    
}
