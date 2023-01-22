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
        ClearPoint(a);
       // AdjacencyList.Remove(a);
    }
    
    public void ClearPoint(int a)
    {
        List<Tuple<int, float>> aConnections = AdjacencyList[a];
        foreach (var Connection in aConnections)
        {
            int ConnectedPointID = Connection.Item1;
            float ConnectedPointWeight = Connection.Item2;
            if (ConnectedPointWeight != 0) continue;
            List<Tuple<int, float>> ConnectedPointConnections = AdjacencyList[ConnectedPointID];
            List<Tuple<int, float>> ConnectionAfterRemoving =
                                    ConnectedPointConnections.Where(x =>
                                    x.Item1 != a).ToList();
            AdjacencyList[ConnectedPointID] = ConnectionAfterRemoving;
        }
    }
}
