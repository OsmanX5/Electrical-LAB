using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalGraph : UndirectedWeightedGraphPathProvider
{
    public ElectricalGraph()
    {
        AdjacencyList = new Dictionary<int, List<Edge>>();
    }
    public void AddNewPoint(Point point)
    {
        AddNewPoint(point.ID);
    }
    public void AddConnection(Point a,Point b,float res)
    {
        AddConnection(a.ID, b.ID, res);
    }
    public void RemovePoint(Point a)
    {
        Debug.Log("Removing Point");
        RemovePoint(a.ID);
    }
    public void ClearPoint(Point a)
    {
        ClearPoint(a.ID);
    }
    

    public override string ToString()
    {
        return GetAdjacencyListSTR();
    }
}
