using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElectricalGraph : UndirectedWeightedGraphPathProvider, ICloneable
{
    public ElectricalGraph()
    {
        AdjacencyList = new Dictionary<int, List<Edge>>();
    }
    public void AddNewPoint(Point point)=> AddNewPoint(point.ID);
    public void AddConnection(Point a,Point b,float res)=>AddConnection(a.ID, b.ID, res);
    public void RemovePoint(Point a)=>RemovePoint(a.ID);
    public void ClearPoint(Point a)=>ClearPoint(a.ID);
    public bool IsConnected(Point a, Point b) => IsConnected(a.ID, b.ID);
    public List<Point> GetConnectedPointsTo(Point a)
    {
        return GetPointConnections(a.ID)
            .Select((Edge x) => x.NextPoint)
            .Select(id => PointsConverter.ToPoint(id))
            .ToList();
    }
    

    public override string ToString()
    {
        string result = "";
        result += "Graph: \n" + GetAdjacencyListSTR();
        return result;
    }

    public object Clone()
    {
        ElectricalGraph newGraph = new ElectricalGraph();
        newGraph.AdjacencyList = new Dictionary<int, List<Edge>>(AdjacencyList);
        return newGraph;
        throw new NotImplementedException();
    }
}
