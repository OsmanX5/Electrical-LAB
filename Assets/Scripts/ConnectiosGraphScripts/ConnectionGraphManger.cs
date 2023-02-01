using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphManger : ConnectionGraphChecker
{
    public void InitlizeGraph(){
        Graph = new ElectricalGraph();
        IsCircuitClosed = false;
        OnGraphUpdated += CheckCircuit;
    }
    public List<NodePoint> GetConnectedNodePoints(Point point)
    {
        if (point is NodePoint)
            return GetConnectedNodePoints(point as NodePoint);
        else if (point is ComponentPoint)
            return GetConnectedNodePoints(point as ComponentPoint);
        return new();
    }
    public List<NodePoint> GetConnectedNodePoints(NodePoint point)
    {
        List<NodePoint> res = new() { point };
        Stack<NodePoint> stack = new();
        stack.Push(point);
        while (stack.Count > 0)
        {
            NodePoint current = stack.Pop();
            foreach (var edge in Graph.GetPointConnections(current.ID))
            {
                if (PointsManger.IsNode(edge.NextPoint))
                {
                    var node = PointsManger.GetPoint(edge.NextPoint) as NodePoint;
                    if (!res.Contains(node))
                    {
                        res.Add(node);
                        stack.Push(node);
                    }
                }
            }
        }
        return res;
    }
    public List<NodePoint> GetConnectedNodePoints(ComponentPoint point)
    {
        List<NodePoint> res = new();
        foreach (Edge next in Graph.GetPointConnections(point.ID))
        {
            if (PointsManger.IsNode(next.NextPoint))
            {
                res.AddRange(GetConnectedNodePoints(PointsManger.GetPoint(next.NextPoint) as NodePoint));
            }
        }
        return res;
    }
}
