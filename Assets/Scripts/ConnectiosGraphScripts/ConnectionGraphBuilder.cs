using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    public static event Action OnGraphUpdated;
    public static event Action<Point> OnAddNewPoint ;
    public static event Action<Point,Point> OnConnectTwoNodes;
    public static void AddNewPoint(Point point)
    {
        bool addingSuccess = addNewPointToGraph(point);
        if (addingSuccess)
        {
            OnAddNewPoint?.Invoke(point);
        }
    }
    private static bool addNewPointToGraph(Point newPoint)
    {
        if (ConnectionGraph.graph.IsInGraph(newPoint))
        {
            Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
            return false;
        }
        ConnectionGraph.graph.AddNewPoint(newPoint);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
        return true;
    }
 
    public static void ConnectPoints(Point a, Point b, float res = 0)
    {
        bool ConnectingSuccess = ConnectNodesInGraph(a, b,res);
        if(ConnectingSuccess)
        {
            OnConnectTwoNodes?.Invoke(a,b); 
            OnGraphUpdated?.Invoke();
        }
    }
    private static bool ConnectNodesInGraph(Point a, Point b,float res = 0)
    {
        if (!ConnectionGraph.graph.IsInGraph(a))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return false;
        }
        if (!ConnectionGraph.graph.IsInGraph(b))
        {
            Debug.LogError("Point with ID: " + b.ID + " does not exist in graph");
            return false;
        }
        if (a == b)
        {
            Debug.Log("Cannot connect point with itself");
            return false;
        }
        if (ConnectionGraph.graph.DisJointSet.IsConnected(a.ID, b.ID))
        {
            Debug.Log("Points are already connected");
            return false;
        }
        ConnectionGraph.graph.AddConnection(a,b,res );
        return true;
    }
 

}
