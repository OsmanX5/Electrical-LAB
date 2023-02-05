using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargtedUWGraphResistorsManger {
    
    public HashSet<ResistorEdge> GetGraphResistors(TargtedUWGraph graph)
    {
        HashSet<ResistorEdge> GraphResistors = new HashSet<ResistorEdge>();
        foreach (var point in graph.Graph.GetAdjacencyList())
        {
            int a = point.Key;
            foreach (var edge in point.Value)
            {
                int b = edge.NextPoint;
                float w = edge.Weight;
                if (w >= 0)
                {
                    GraphResistors.Add(new ResistorEdge(a,b,w));
                }
            }

        }
        return GraphResistors;
    }
}
