using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalGraph : UndirectedWeightedGraphPathProvider
{
    public DisJointSet DisJointSet;
    public ElectricalGraph() : base()
    {
        DisJointSet = new DisJointSet(0);
    }
    public bool IsInGraph(Point point) => IsInGraph(point.ID);
    public void AddNewPoint(Point point)
    {
        addPoint(point.ID);
        DisJointSet.AddPoint(point.ID);
    }
    public void AddConnection(Point a,Point b,float res)
    {
        AddConnection(a.ID, b.ID, res);
        DisJointSet.Union(a.ID, b.ID);
    }
    public void RemovePoint(Point a)
    {
        RemovePoint(a.ID);
    }


}
