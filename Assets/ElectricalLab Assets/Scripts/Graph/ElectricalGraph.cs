using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElectricalGraph 
{
    public UndirectedWeightedGraph UWGraph;
    public ElectricalGraph()
    {
        Debug.Log("New graph");
        UWGraph = new();
    }
    public void AddNewPoint(Point point)=> UWGraph.AddNewPoint(point.ID);
    public void AddConnection(Point a,Point b,float res)=> UWGraph.AddConnection(a.ID, b.ID, res);
    public void RemovePoint(Point a)=> UWGraph.RemovePoint(a.ID);
    public void ClearPoint(Point a)=> UWGraph.ClearPoint(a.ID);
    public bool IsConnected(Point a, Point b) => UWGraph.IsConnected(a.ID, b.ID);
    public List<Point> GetConnectedPointsTo(Point a)
    {
        return UWGraph.GetPointConnections(a.ID)
            .Select((Edge x) => x.NextPoint)
            .Select(id => PointsConverter.ToPoint(id))
            .ToList();
    }
    public override string ToString()
    {
        return UWGraph.ToString();
    }

}
