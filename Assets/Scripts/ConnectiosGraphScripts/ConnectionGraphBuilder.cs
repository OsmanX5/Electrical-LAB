using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionGraphBuilder : MonoBehaviour
{
    private void Start()
    {
        foreach (Point point in Point.Points)
        {
            point.OnPointCreated += OnPointCreatedHandler;
        }
    }
    static void OnPointCreatedHandler(Point point)
    {
        addNewPointToGraph(point);
        ConnectToThePair(point, point.ParentLoad.getResistance()); //if  not created not a problem
    }
    public static void addNewPointToGraph(Point newPoint)
    {
        Debug.Log("Adding new point to graph point ID : "+ newPoint.ID);
        if (ConnectionGraph.AdjacencyList.ContainsKey(newPoint.ID))
        {
            Debug.Log("Point with ID: " + newPoint.ID + " already exists in graph");
            return;
        }
        ConnectionGraph.AdjacencyList.Add(newPoint.ID,new List<ConnectionPoint>());
        ConnectionGraph.DisJointSet.AddPoint(newPoint.ID);
        Debug.Log("POINT WITH ID : " + newPoint.ID + " Added to graph");
        ConnectionGraph.nodesCount += 1;
    }
    public static void AddConnectionBetweenNodes(Point a, Point b)
    {
        if (!ConnectionGraph.AdjacencyList.ContainsKey(a.ID) 
            || !ConnectionGraph.AdjacencyList.ContainsKey(a.ID))
        {
            Debug.LogError("Point with ID: " + a.ID + " does not exist in graph");
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
        AddPointToIDConnections(a.ID, b);
        AddPointToIDConnections(b.ID, a);
        ConnectionGraph.DisJointSet.Union(a.ID, b.ID);
    }
    public static void AddPointToIDConnections(int PointId,Point PointToAdd,float resistance =0 )
    {
        if (PointId == PointToAdd.ID)
        {
            Debug.Log("Cannot connect point with itself");
            return;
        }
        Debug.Log("try Adding point with ID" + PointToAdd.ID + "to ID" + PointId);
        foreach (var connection in ConnectionGraph.AdjacencyList[PointId]){
            if (connection.point.ID == PointToAdd.ID)
            {
                Debug.Log("Point with ID: " + PointToAdd.ID + " already connected here");
                return;
            }
        }
        ConnectionGraph.AdjacencyList[PointId].Add(new ConnectionPoint(PointToAdd,resistance));
        Debug.Log("Successfully  Added point with ID" + PointToAdd.ID + "to ID" + PointId);
    }
 
    public static void ConnectToThePair(Point a,float resistance)
    {
        if (!ConnectionGraph.AdjacencyList.ContainsKey(a.PairPoint.ID))
        {
            Debug.Log("Pair is not Created Yet");
            return;
        }
        AddPointToIDConnections(a.ID, a.PairPoint,resistance);
        AddPointToIDConnections(a.PairPoint.ID, a,resistance);
    }
    public static void RemovePointFromGraph(Point point)
    {
        if(ConnectionGraph.AdjacencyList.ContainsKey(point.ID) == false)
        {
            Debug.Log("no point like this here when try to delet");
            return;
        }
        ConnectionGraph.AdjacencyList.Remove(point.ID);
    }


}
