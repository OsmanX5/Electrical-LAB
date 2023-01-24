using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : ConnectionGraph
{
    public event Action OnGraphUpdated;
    public event Action<Point> OnPointDeleted;
    public event Action<Point> OnAddNewPoint;
    public event Action<Point, Point> OnConnectTwoNodes;

    public  void AddNewPoint(Point point)
    {
        
        bool addingSuccess = AddNewPointToGraph(point);
        if (addingSuccess)
        {
            OnAddNewPoint?.Invoke(point);
        }
    }
    private bool AddNewPointToGraph(Point newPoint)
    {
        Debug.Log("Adding New Point to electric graph  with ID"+newPoint.ID);
        Graph.AddNewPoint(newPoint);
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
        if (!Graph.IsInGraph(a.ID))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return false;
        }
        if (!Graph.IsInGraph(b.ID))
        {
            Debug.LogError("Point with ID: " + b.ID + " does not exist in graph");
            return false;
        }
        if (a == b)
        {
            Debug.Log("Cannot connect point with itself");
            return false;
        }
        Graph.AddConnection(a,b,res );
        Debug.Log("Points connected" + a.ID + "  " + b.ID);
        return true;
    }

    public void DisconnectPoint(Point a)
    {
        bool DisconnectingSuccess = DisconnectNodeInGraph(a);
        if (DisconnectingSuccess)
        {
            Debug.Log("Points disconnected" + a.ID);
            OnPointDeleted?.Invoke(a);
            OnGraphUpdated?.Invoke();
        }
    }

    private bool DisconnectNodeInGraph(Point a)
    {
        if (!Graph.IsInGraph(a.ID))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return false;
        }
        Graph.RemovePoint(a);
        return true;
        throw new NotImplementedException();
    }
}
