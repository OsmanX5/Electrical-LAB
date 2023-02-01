using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorsSerialConnect 
{
    public static ElectricalGraph graph;
    public static bool IsSerialConnected(ComponentPoint a, ComponentPoint b)
    {
        List<Point> ConnectedToA = graph.GetConnectedPointsTo(a);
        List<Point> ConnectedToB = graph.GetConnectedPointsTo(b);
        if (ConnectedToA.Count != 2 || ConnectedToB.Count != 2 || !graph.IsConnected(a,b) || a.PairPoint == b)
        {
            return false;
        }
        
        return true;
    }
    public static void Connect(ComponentPoint a, ComponentPoint b)
    {
        if (IsSerialConnected(a, b))
        {
            float NewResistance = ((a.ElectricalComponent) as Load).Resistance + ((b.ElectricalComponent) as Load).Resistance;
            graph.AddConnection(a.PairPoint, b.PairPoint, NewResistance);
            graph.RemovePoint(a);
            graph.RemovePoint(b);
        }
    }
}
