using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    // New Points Functions
    public static void AddNewPoint(Point point)
    {
        Debug.Log("Point catched event with ID: " + point.ID);
        addNewPointToGraph(point);
        connectToPair(point); //if  not created not a problem
    }
    private static void addNewPointToGraph(Point newPoint)
    {
        Debug.Log("Adding new point to graph point ID : "+ newPoint.ID);
        if (ConnectionGraph.IsInGraph(newPoint))
        {
            Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
            return;
        }
        ConnectionGraph.AdjacencyList.Add(newPoint.ID,new List<ConnectionPoint>());
        ConnectionGraph.DisJointSet.AddPoint(newPoint.ID);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
    }
    private static void connectToPair(Point a)
    {
        if (!ConnectionGraph.AdjacencyList.ContainsKey(a.PairPoint.ID))
        {
            Debug.Log("Pair is not Created Yet");
            return;
        }
        AddPointToID(a.ID, a.PairPoint, a.ParentLoad.getResistance());
        AddPointToID(a.PairPoint.ID, a, a.ParentLoad.getResistance());
    }

    // Connect Points Functions
    public static void ConnectNodes(Point a, Point b)
    {
        if (!ConnectionGraph.IsInGraph(a))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
            return;
        }
        if (!ConnectionGraph.IsInGraph(b))
        {
            Debug.LogError("Point with ID: " + b.ID + " does not exist in graph");
            return;
        }
        if (a == b)
        {
            Debug.Log("Cannot connect point with itself");
            return;
        }
        if (a == b.PairPoint)
        {
            Debug.Log("Cannot connect point with its pair");
            return;
        }
        if (ConnectionGraph.DisJointSet.IsConnected(a.ID, b.ID))
        {
            Debug.Log("Points are already connected");
            return;
        }

        AddPointToID(a.ID, b);
        AddPointToID(b.ID, a);
        ConnectionGraph.DisJointSet.Union(a.ID, b.ID);
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
