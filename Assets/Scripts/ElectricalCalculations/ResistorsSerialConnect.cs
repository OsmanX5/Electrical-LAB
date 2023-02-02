using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorsSerialConnect : GraphCalculator
{

    public static bool IsSerialConnected(int a, int b)
    {
        List<Edge> ConnectedToA = graph.GetPointConnections(a);
        List<Edge> ConnectedToB = graph.GetPointConnections(b);
        if (ConnectedToA.Count != 2 
            || ConnectedToB.Count != 2 
            || !graph.IsConnected(a, b)
            || graph.WeightBetween(a, b) != 0)
            return false;
        return true;
    }
    public static void Connect(int a, int b)
    {
        if (IsSerialConnected(a, b))
        {
            float NewResistance = graph.WeightBetween(a, graph.PairPoint(a)) + graph.WeightBetween(b, graph.PairPoint(b));
            graph.AddConnection(graph.PairPoint(a), graph.PairPoint(b), NewResistance);
            graph.RemovePoint(a);
            graph.RemovePoint(b);
        }
    }
    public static bool CalculateNextSeries()
    {
        List<int> path = graph.GetPath(startID, endID);
        for (int i = 0; i < path.Count - 1; i++)
        {
            if (IsSerialConnected(path[i], path[i + 1]))
            {
                Connect(path[i], path[i + 1]);
                return true;
            }
        }
        return false;
    }

    public static void CalculateAllSeries()
    {
        while (CalculateNextSeries()) ;
    }
}
