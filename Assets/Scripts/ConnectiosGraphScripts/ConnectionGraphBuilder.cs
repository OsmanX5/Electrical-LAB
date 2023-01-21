using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : ConnectionGraph
{
    public  event Action OnGraphUpdated;
    public  event Action<Point> OnAddNewPoint ;
    public  event Action<Point,Point> OnConnectTwoNodes;
    public  void AddNewPoint(Point point)
    {
        bool addingSuccess = addNewPointToGraph(point);
        if (addingSuccess)
        {
            OnAddNewPoint?.Invoke(point);
        }
    }
    private  bool addNewPointToGraph(Point newPoint)
    {
        if (graph.IsInGraph(newPoint))
        {
            Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
            return false;
        }
        graph.AddNewPoint(newPoint);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
        return true;
    }
 
    public  void ConnectPoints(Point a, Point b, float res = 0)
    {
        bool ConnectingSuccess = ConnectNodesInGraph(a, b,res);
        if(ConnectingSuccess)
        {
            OnConnectTwoNodes?.Invoke(a,b); 
            OnGraphUpdated?.Invoke();
        }
    }
    private  bool ConnectNodesInGraph(Point a, Point b,float res = 0)
    {
        if (!graph.IsInGraph(a))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return false;
        }
        if (!graph.IsInGraph(b))
        {
            Debug.LogError("Point with ID: " + b.ID + " does not exist in graph");
            return false;
        }
        if (a == b)
        {
            Debug.Log("Cannot connect point with itself");
            return false;
        }
        graph.AddConnection(a,b,res );
        Debug.Log("Points connected" + a.ID + "  " + b.ID);
        return true;
    }
 

}
