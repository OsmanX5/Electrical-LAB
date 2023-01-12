using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    public static event Action<Point> OnAddNewPoint ;
    public static event Action<Point,Point> OnConnectTwoNodes;
    // New Points Functions
    public static void AddNewPoint(Point point)
    {
        bool addingSuccess = addNewPointToGraph(point);
        if (addingSuccess)
        {
            OnAddNewPoint?.Invoke(point);
        }
        connectToPair(point); 
    }
    private static bool addNewPointToGraph(Point newPoint)
    {
        Debug.Log("Adding new point to graph point ID : "+ newPoint.ID);
        if (ConnectionGraph.IsInGraph(newPoint))
        {
            Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
            return false;
        }
        ConnectionGraph.AdjacencyList.Add(newPoint.ID,new List<ConnectionPoint>());
        ConnectionGraph.DisJointSet.AddPoint(newPoint.ID);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
        return true;
    }
    private static bool connectToPair(Point a)
    {
        if (!ConnectionGraph.AdjacencyList.ContainsKey(a.PairPoint.ID))
        {
            Debug.Log("Pair is not Created Yet");
            return false;
        }
        AddPointToID(a.ID, a.PairPoint, a.ParentLoad.getResistance());
        AddPointToID(a.PairPoint.ID, a, a.ParentLoad.getResistance());
        return true;
    }

    // Connect Points Functions
    public static void ConnectNodes(Point a, Point b)
    {
        bool ConnectingSuccess = ConnectNodesInGraph(a, b);
        if(ConnectingSuccess)
        {
            OnConnectTwoNodes?.Invoke(a,b);
        }
    }
    private static bool ConnectNodesInGraph(Point a, Point b)
    {
        if (!ConnectionGraph.IsInGraph(a))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return false;
        }
        if (!ConnectionGraph.IsInGraph(b))
        {
            Debug.LogError("Point with ID: " + b.ID + " does not exist in graph");
            return false;
        }
        if (a == b)
        {
            Debug.Log("Cannot connect point with itself");
            return false;
        }
        if (a == b.PairPoint)
        {
            Debug.Log("Cannot connect point with its pair");
            return false;
        }
        if (ConnectionGraph.DisJointSet.IsConnected(a.ID, b.ID))
        {
            Debug.Log("Points are already connected");
            return false;
        }

        bool addSuccess1 = AddPointToID(a.ID, b);
        bool addSuccess2 =AddPointToID(b.ID, a);
        ConnectionGraph.DisJointSet.Union(a.ID, b.ID);
        return addSuccess1 && addSuccess2;
    }
    public static bool AddPointToID(int PointId,Point PointToAdd,float resistance =0 )
    {
        Debug.Log("try Adding point with ID" + PointToAdd.ID + "to ID" + PointId);
        foreach (var connection in ConnectionGraph.AdjacencyList[PointId]){
            if (connection.point == PointToAdd)
            {
                Debug.Log("Point with ID: " + PointToAdd.ID + " already connected here");
                return false;
            }
        }
        ConnectionGraph.AdjacencyList[PointId].Add(new ConnectionPoint(PointToAdd,resistance));
        Debug.Log("Successfully  Added point with ID" + PointToAdd.ID + "to ID" + PointId);
        return true;
    }
 

}
